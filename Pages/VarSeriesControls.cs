using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using MetroFramework.Controls;
using MathStatRGR.Utils;

namespace MathStatRGR.Pages
{
    public partial class VarSeriesControls : MetroUserControl
    {
        private List<(double Value, double Frequency)> calculatedData = new List<(double, double)>();
        private bool isContinuous = false;
        private List<string> continuousIntervals = new List<string>();

        private Form chartForm;
        private Chart chart;
        private ComboBox chartTypeSelector;

        public VarSeriesControls()
        {
            InitializeComponent();
            System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            System.Threading.Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
            InitializeControlState();
        }

        private void InitializeControlState()
        {
            discreteRadio.Checked = true;
            isContinuous = false;
            UpdateGridColumns();
            ClearResultLabels();
            if (showChartButton != null) showChartButton.Enabled = false;
        }

        private void UpdateGridColumns()
        {
            dataGrid.Rows.Clear();
            dataGrid.Columns.Clear();
            calculatedData.Clear();
            continuousIntervals.Clear();
            if (showChartButton != null) showChartButton.Enabled = false;

            if (isContinuous)
            {
                dataGrid.Columns.Add("Interval", "Интервал");
                dataGrid.Columns.Add("Midpoint", "Середина (авто)");
                dataGrid.Columns.Add("Frequency", "Частота");
            }
            else
            {
                dataGrid.Columns.Add("Value", "Значение");
                dataGrid.Columns.Add("Frequency", "Частота");
            }
            dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is MetroRadioButton radioButton && radioButton.Checked)
            {
                isContinuous = (radioButton == continuousRadio);
                UpdateGridColumns();
                ClearResultLabels();
            }
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Data Files (*.xlsx;*.xls;*.xlsb;*.csv;*.txt)|*.xlsx;*.xls;*.xlsb;*.csv;*.txt" +
                                        "|Excel Files (*.xlsx;*.xls;*.xlsb)|*.xlsx;*.xls;*.xlsb" +
                                        "|CSV Files (*.csv)|*.csv" +
                                        "|Text Files (*.txt)|*.txt" +
                                        "|All Files (*.*)|*.*";
                openFileDialog.Title = "Выберите файл данных (Excel, CSV, TXT)";
                openFileDialog.FilterIndex = 1;
                openFileDialog.CheckFileExists = true;
                openFileDialog.CheckPathExists = true;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() != DialogResult.OK) return;

                string filePath = openFileDialog.FileName;
                string fileExtension = Path.GetExtension(filePath).ToLowerInvariant();

                try
                {
                    dataGrid.Rows.Clear();
                    calculatedData.Clear();
                    continuousIntervals.Clear();
                    ClearResultLabels();
                    if (showChartButton != null) showChartButton.Enabled = false;

                    List<string> loadErrors = new List<string>();
                    bool loadSuccess = false;

                    if (fileExtension == ".csv" || fileExtension == ".txt")
                    {
                        loadSuccess = LoadDataFromCsvOrTxt(filePath, loadErrors);
                    }
                    else if (fileExtension == ".xlsx" || fileExtension == ".xls" || fileExtension == ".xlsb")
                    {
                        loadSuccess = LoadDataFromExcel(filePath, loadErrors);
                    }
                    else
                    {
                        MessageBox.Show($"Неподдерживаемый тип файла: {fileExtension}", "Ошибка файла", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (loadErrors.Any())
                    {
                        MessageBox.Show("При загрузке данных из файла возникли следующие проблемы:\n\n" + string.Join("\n", loadErrors) +
                                       "\n\nНекорректные строки были пропущены.",
                                       "Предупреждение при загрузке", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    if (!loadSuccess || dataGrid.Rows.Cast<DataGridViewRow>().Count(r => !r.IsNewRow) == 0)
                    {
                        if (loadSuccess && !loadErrors.Any())
                        {
                            MessageBox.Show("Файл пуст или не содержит данных в ожидаемом формате.", "Файл пуст", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        ClearResultLabels();
                        if (showChartButton != null) showChartButton.Enabled = false;
                    }

                }
                catch (IOException ioEx)
                {
                    MessageBox.Show($"Ошибка доступа к файлу: {ioEx.Message}\n\nВозможно, файл открыт в другой программе.",
                                    "Ошибка файла", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ClearResultLabels();
                    if (showChartButton != null) showChartButton.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Неожиданная ошибка при загрузке данных из файла: {ex.Message}",
                                    "Ошибка загрузки", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ClearResultLabels();
                    if (showChartButton != null) showChartButton.Enabled = false;
                }
            }
        }

        private bool LoadDataFromExcel(string filePath, List<string> loadErrors)
        {
            var dataTableCollection = ExcelTableReader.GetAllDataTables(filePath, true);

            if (dataTableCollection == null || dataTableCollection.Count == 0)
            {
                loadErrors.Add("Не удалось прочитать данные из файла Excel или файл пуст.");
                return false;
            }

            int sheetIndex;
            if (dataTableCollection.Count == 1)
            {
                sheetIndex = 0;
            }
            else
            {
                sheetIndex = ExcelTableReader.GetSheetIndex(dataTableCollection.Count);
                if (sheetIndex == -1)
                {
                    loadErrors.Add("Выбор листа отменен пользователем.");
                    return false;
                }
            }

            LoadDataFromDataTable(dataTableCollection[sheetIndex], loadErrors);
            return true;
        }

        private void LoadDataFromDataTable(DataTable table, List<string> loadErrors)
        {
            if (table.Columns.Count < 2)
            {
                loadErrors.Add("Выбранный лист Excel должен содержать как минимум 2 колонки (Значение/Интервал и Частота).");
                return;
            }

            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow row = table.Rows[i];
                if ((row[0] == DBNull.Value || string.IsNullOrWhiteSpace(row[0]?.ToString())) &&
                    (row[1] == DBNull.Value || string.IsNullOrWhiteSpace(row[1]?.ToString())))
                {
                    continue;
                }

                string valueOrIntervalRaw = row[0]?.ToString().Trim();
                string frequencyRaw = row[1]?.ToString().Trim();

                ProcessAndAddGridRow(valueOrIntervalRaw, frequencyRaw, $"Строка {i + 1} (Excel)", loadErrors);
            }
        }

        private bool LoadDataFromCsvOrTxt(string filePath, List<string> loadErrors)
        {
            char[] delimiters = { ',', ';', '\t', '|' };
            string[] lines;

            try
            {
                lines = File.ReadAllLines(filePath);
            }
            catch (Exception ex)
            {
                loadErrors.Add($"Ошибка чтения файла {Path.GetFileName(filePath)}: {ex.Message}");
                return false;
            }

            if (!lines.Any())
            {
                return true;
            }

            bool skipHeader = false;
            string[] firstLineParts = lines[0].Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            if (firstLineParts.Length >= 2)
            {
                if (!double.TryParse(firstLineParts[1].Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out _))
                {
                    skipHeader = true;
                }
            }

            for (int i = (skipHeader ? 1 : 0); i < lines.Length; i++)
            {
                string line = lines[i];
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                string[] parts = line.Split(delimiters);

                if (parts.Length < 2)
                {
                    loadErrors.Add($"Строка {i + 1} (Файл): Недостаточно столбцов (ожидается минимум 2, разделители: ',', ';', '\\t', '|'). Строка: '{line}'");
                    continue;
                }

                string valueOrIntervalRaw = parts[0]?.Trim();
                string frequencyRaw = parts[1]?.Trim();

                ProcessAndAddGridRow(valueOrIntervalRaw, frequencyRaw, $"Строка {i + 1} (Файл)", loadErrors);
            }
            return true;
        }


        private void ProcessAndAddGridRow(string valueOrIntervalRaw, string frequencyRaw, string rowIdentifier, List<string> loadErrors)
        {
            if (string.IsNullOrWhiteSpace(valueOrIntervalRaw) && string.IsNullOrWhiteSpace(frequencyRaw))
            {
                return;
            }
            if (string.IsNullOrWhiteSpace(valueOrIntervalRaw) || string.IsNullOrWhiteSpace(frequencyRaw))
            {
                loadErrors.Add($"{rowIdentifier}: Пропущена строка. Необходимо заполнить и значение/интервал, и частоту.");
                return;
            }

            if (!double.TryParse(frequencyRaw, NumberStyles.Any, CultureInfo.InvariantCulture, out double frequency) || frequency < 0)
            {
                loadErrors.Add($"{rowIdentifier}: Неверный формат частоты '{frequencyRaw}'. Укажите неотрицательное число.");
                return;
            }
            string frequencyStr = frequency.ToString(CultureInfo.InvariantCulture);

            if (isContinuous)
            {
                if (!TryParseInterval(valueOrIntervalRaw, out _, out _))
                {
                    loadErrors.Add($"{rowIdentifier}: Неверный формат интервала '{valueOrIntervalRaw}'. Используйте формат 'число-число', где левое число не больше правого.");
                    return;
                }
                string midpointDisplay = CalculateMidpointDisplay(valueOrIntervalRaw);
                dataGrid.Rows.Add(valueOrIntervalRaw, midpointDisplay, frequencyStr);

            }
            else
            {
                if (!double.TryParse(valueOrIntervalRaw, NumberStyles.Any, CultureInfo.InvariantCulture, out _))
                {
                    loadErrors.Add($"{rowIdentifier}: Неверный формат значения '{valueOrIntervalRaw}'. Укажите число.");
                    return;
                }
                dataGrid.Rows.Add(valueOrIntervalRaw, frequencyStr);
            }
        }


        private void CalculateButton_Click(object sender, EventArgs e)
        {
            if (TryParseDataFromGrid())
            {
                CalculateAndDisplayStatistics();
                if (showChartButton != null) showChartButton.Enabled = calculatedData.Any();
            }
            else
            {
                if (showChartButton != null) showChartButton.Enabled = false;
                ClearResultLabels();
            }
        }

        private void ShowChartButton_Click(object sender, EventArgs e)
        {
            ShowChart();
        }

        private bool TryParseDataFromGrid()
        {
            calculatedData.Clear();
            continuousIntervals.Clear();
            List<string> errorMessages = new List<string>();

            for (int i = 0; i < dataGrid.Rows.Count; i++)
            {
                DataGridViewRow row = dataGrid.Rows[i];
                if (row.IsNewRow) continue;

                bool isRowEmptyOrIncomplete;
                if (isContinuous)
                {
                    isRowEmptyOrIncomplete = (row.Cells["Interval"]?.Value == null || string.IsNullOrWhiteSpace(row.Cells["Interval"].Value.ToString()))
                                          && (row.Cells["Frequency"]?.Value == null || string.IsNullOrWhiteSpace(row.Cells["Frequency"].Value.ToString()));
                }
                else
                {
                    isRowEmptyOrIncomplete = (row.Cells["Value"]?.Value == null || string.IsNullOrWhiteSpace(row.Cells["Value"].Value.ToString()))
                                          && (row.Cells["Frequency"]?.Value == null || string.IsNullOrWhiteSpace(row.Cells["Frequency"].Value.ToString()));
                }

                if (isRowEmptyOrIncomplete) continue;


                double value = double.NaN;
                double frequency = double.NaN;
                bool rowValid = false;
                string valueOrIntervalStr = "";
                string freqStr = "";

                try
                {
                    if (isContinuous)
                    {
                        valueOrIntervalStr = row.Cells["Interval"]?.Value?.ToString();
                        freqStr = row.Cells["Frequency"]?.Value?.ToString();

                        if (string.IsNullOrWhiteSpace(valueOrIntervalStr) || string.IsNullOrWhiteSpace(freqStr))
                        {
                            errorMessages.Add($"Строка {i + 1}: Необходимо заполнить и интервал, и частоту.");
                            if (dataGrid.Columns.Contains("Midpoint")) row.Cells["Midpoint"].Value = string.Empty;
                            continue;
                        }

                        if (TryParseInterval(valueOrIntervalStr, out double lower, out double upper) &&
                            double.TryParse(freqStr, NumberStyles.Any, CultureInfo.InvariantCulture, out frequency) &&
                            frequency >= 0)
                        {
                            value = (lower + upper) / 2.0;
                            continuousIntervals.Add(valueOrIntervalStr);
                            row.Cells["Midpoint"].Value = value.ToString(CultureInfo.InvariantCulture);
                            rowValid = true;
                        }
                        else
                        {
                            if (!TryParseInterval(valueOrIntervalStr, out _, out _))
                                errorMessages.Add($"Строка {i + 1}: Неверный формат интервала '{valueOrIntervalStr}'. Используйте формат 'число-число', где левое число не больше правого.");
                            if (!double.TryParse(freqStr, NumberStyles.Any, CultureInfo.InvariantCulture, out double parsedFreq) || parsedFreq < 0)
                                errorMessages.Add($"Строка {i + 1}: Неверный формат частоты '{freqStr}'. Укажите неотрицательное число.");

                            if (dataGrid.Columns.Contains("Midpoint")) row.Cells["Midpoint"].Value = "Ошибка";
                        }
                    }
                    else
                    {
                        valueOrIntervalStr = row.Cells["Value"]?.Value?.ToString();
                        freqStr = row.Cells["Frequency"]?.Value?.ToString();

                        if (string.IsNullOrWhiteSpace(valueOrIntervalStr) || string.IsNullOrWhiteSpace(freqStr))
                        {
                            errorMessages.Add($"Строка {i + 1}: Необходимо заполнить и значение, и частоту.");
                            continue;
                        }

                        if (double.TryParse(valueOrIntervalStr, NumberStyles.Any, CultureInfo.InvariantCulture, out value) &&
                            double.TryParse(freqStr, NumberStyles.Any, CultureInfo.InvariantCulture, out frequency) &&
                            frequency >= 0)
                        {
                            rowValid = true;
                        }
                        else
                        {
                            if (!double.TryParse(valueOrIntervalStr, NumberStyles.Any, CultureInfo.InvariantCulture, out _))
                                errorMessages.Add($"Строка {i + 1}: Неверный формат значения '{valueOrIntervalStr}'. Укажите число.");
                            if (!double.TryParse(freqStr, NumberStyles.Any, CultureInfo.InvariantCulture, out double parsedFreq) || parsedFreq < 0)
                                errorMessages.Add($"Строка {i + 1}: Неверный формат частоты '{freqStr}'. Укажите неотрицательное число.");
                        }
                    }

                    if (rowValid)
                    {
                        calculatedData.Add((value, frequency));
                    }
                }
                catch (Exception ex)
                {
                    errorMessages.Add($"Строка {i + 1}: Неожиданная ошибка при обработке данных ({ex.Message})");
                    if (isContinuous && dataGrid.Columns.Contains("Midpoint"))
                    {
                        row.Cells["Midpoint"].Value = "Ошибка";
                    }
                }
            }

            if (errorMessages.Any())
            {
                MessageBox.Show("Обнаружены ошибки в данных таблицы:\n\n" + string.Join("\n", errorMessages) +
                                "\n\nПожалуйста, исправьте данные и попробуйте выполнить расчет снова.",
                                "Ошибка данных", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                calculatedData.Clear();
                continuousIntervals.Clear();
                return false;
            }

            if (!calculatedData.Any())
            {
                bool gridHadData = dataGrid.Rows.Cast<DataGridViewRow>().Any(r => !r.IsNewRow &&
                                  r.Cells.Cast<DataGridViewCell>().Any(c => c.Value != null && !string.IsNullOrWhiteSpace(c.Value.ToString())));
                if (gridHadData || !gridHadData)
                {
                    MessageBox.Show("Нет данных для расчета. Введите данные или загрузите файл.",
                              "Нет данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                return false;
            }

            calculatedData = calculatedData.OrderBy(p => p.Value).ToList();

            if (isContinuous)
            {
                var validIntervals = new List<string>();
                var originalIntervals = new List<string>(continuousIntervals);
                continuousIntervals.Clear();

                foreach (var dataPoint in calculatedData)
                {
                    string foundInterval = originalIntervals.FirstOrDefault(interval => {
                        if (TryParseInterval(interval, out double l, out double u))
                        {
                            return Math.Abs(((l + u) / 2.0) - dataPoint.Value) < 1e-9;
                        }
                        return false;
                    });
                    if (foundInterval != null)
                    {
                        continuousIntervals.Add(foundInterval);
                    }
                    else
                    {
                        continuousIntervals.Add($"Ошибка поиска: {dataPoint.Value}");
                    }
                }
            }

            return true;
        }


        private string CalculateMidpointDisplay(string interval)
        {
            if (TryParseInterval(interval, out double lower, out double upper))
            {
                return ((lower + upper) / 2).ToString(CultureInfo.InvariantCulture);
            }
            return "Ошибка";
        }

        private bool TryParseInterval(string interval, out double lower, out double upper)
        {
            lower = double.NaN;
            upper = double.NaN;
            if (string.IsNullOrWhiteSpace(interval)) return false;

            string[] parts = interval.Split('-');
            if (parts.Length == 2 &&
                double.TryParse(parts[0].Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out lower) &&
                double.TryParse(parts[1].Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out upper) &&
                lower <= upper)
            {
                return true;
            }
            return false;
        }


        private void CalculateAndDisplayStatistics()
        {
            if (!calculatedData.Any()) return;

            double totalFrequency = calculatedData.Sum(p => p.Frequency);
            if (totalFrequency <= 0)
            {
                MessageBox.Show("Общая частота равна нулю или отрицательна. Расчет невозможен.", "Ошибка данных", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ClearResultLabels();
                if (showChartButton != null) showChartButton.Enabled = false;
                return;
            }

            double mean = CalculateMean(calculatedData);
            double median = CalculateMedian(calculatedData);
            double mode = CalculateMode(calculatedData);
            double sampleVariance = CalculateSampleVariance(calculatedData, mean);
            double standardDeviation = CalculateStandardDeviation(sampleVariance);
            double meanAbsoluteDeviation = CalculateMeanAbsoluteDeviation(calculatedData, mean);
            double coefficientOfVariation = CalculateCoefficientOfVariation(standardDeviation, mean);

            double initialMoment1 = CalculateInitialMoment(calculatedData, 1);
            double initialMoment2 = CalculateInitialMoment(calculatedData, 2);
            double initialMoment3 = CalculateInitialMoment(calculatedData, 3);
            double initialMoment4 = CalculateInitialMoment(calculatedData, 4);

            double centralMoment1 = CalculateCentralMoment(calculatedData, mean, 1);
            double centralMoment2 = CalculateCentralMoment(calculatedData, mean, 2);
            double centralMoment3 = CalculateCentralMoment(calculatedData, mean, 3);
            double centralMoment4 = CalculateCentralMoment(calculatedData, mean, 4);

            double biasedVariance = centralMoment2;
            double biasedStdDev = CalculateStandardDeviation(biasedVariance);

            double skewness = CalculateSkewness(centralMoment3, biasedStdDev);
            double kurtosis = CalculateKurtosis(centralMoment4, biasedStdDev);

            meanLabel.Text = $"Средняя арифметическая: {FormatResult(mean)}";
            medianLabel.Text = $"Медиана: {FormatResult(median)}";
            modeLabel.Text = $"Мода: {FormatResult(mode, multipleModesPossible: true)}";
            meanAbsoluteDeviationLabel.Text = $"Среднее линейное отклонение: {FormatResult(meanAbsoluteDeviation)}";
            sampleVarianceLabel.Text = $"Выборочная дисперсия (s²): {FormatResult(sampleVariance)}";
            standardDeviationLabel.Text = $"Среднее квадратическое отклонение (s): {FormatResult(standardDeviation)}";
            coefficientOfVariationLabel.Text = $"Коэффициент вариации: {FormatResult(coefficientOfVariation, "%")}";

            initialMoment1Label.Text = $"Начальный момент порядка 1 (m₁): {FormatResult(initialMoment1)}";
            initialMoment2Label.Text = $"Начальный момент порядка 2 (m₂): {FormatResult(initialMoment2)}";
            initialMoment3Label.Text = $"Начальный момент порядка 3 (m₃): {FormatResult(initialMoment3)}";
            initialMoment4Label.Text = $"Начальный момент порядка 4 (m₄): {FormatResult(initialMoment4)}";

            centralMoment1Label.Text = $"Центральный момент порядка 1 (μ₁): {FormatResult(centralMoment1)}";
            centralMoment2Label.Text = $"Центральный момент порядка 2 (μ₂): {FormatResult(centralMoment2)}";
            centralMoment3Label.Text = $"Центральный момент порядка 3 (μ₃): {FormatResult(centralMoment3)}";
            centralMoment4Label.Text = $"Центральный момент порядка 4 (μ₄): {FormatResult(centralMoment4)}";

            skewnessLabel.Text = $"Коэффициент асимметрии (As): {FormatResult(skewness)}";
            kurtosisLabel.Text = $"Коэффициент эксцесса (Ex): {FormatResult(kurtosis)}";
        }

        private string FormatResult(double value, string suffix = "", string format = "F4", bool multipleModesPossible = false)
        {
            if (double.IsNaN(value))
            {
                if (multipleModesPossible && modeLabel != null)
                {
                    double currentMode = CalculateMode(calculatedData);
                    if (double.IsNaN(currentMode))
                    {
                        if (calculatedData.Any())
                        {
                            double maxFreq = calculatedData.Max(p => p.Frequency);
                            int modeCount = calculatedData.Count(p => Math.Abs(p.Frequency - maxFreq) < 1e-9);
                            if (modeCount > 1 && modeCount < calculatedData.Count) return "Несколько мод";
                            if (modeCount == calculatedData.Count && calculatedData.Count > 1) return "Не определена (равномерно)";
                        }
                    }
                    return "Не определена";
                }
                return "Не определено";
            }
            if (double.IsInfinity(value))
            {
                return "Бесконечность";
            }
            return value.ToString(format, CultureInfo.InvariantCulture) + suffix;
        }

        private void ClearResultLabels()
        {
            string na = "N/A";
            meanLabel.Text = $"Средняя арифметическая: {na}";
            medianLabel.Text = $"Медиана: {na}";
            modeLabel.Text = $"Мода: {na}";
            meanAbsoluteDeviationLabel.Text = $"Среднее линейное отклонение: {na}";
            sampleVarianceLabel.Text = $"Выборочная дисперсия (s²): {na}";
            standardDeviationLabel.Text = $"Среднее квадратическое отклонение (s): {na}";
            coefficientOfVariationLabel.Text = $"Коэффициент вариации: {na}";
            initialMoment1Label.Text = $"Начальный момент порядка 1 (m₁): {na}";
            initialMoment2Label.Text = $"Начальный момент порядка 2 (m₂): {na}";
            initialMoment3Label.Text = $"Начальный момент порядка 3 (m₃): {na}";
            initialMoment4Label.Text = $"Начальный момент порядка 4 (m₄): {na}";
            centralMoment1Label.Text = $"Центральный момент порядка 1 (μ₁): {na}";
            centralMoment2Label.Text = $"Центральный момент порядка 2 (μ₂): {na}";
            centralMoment3Label.Text = $"Центральный момент порядка 3 (μ₃): {na}";
            centralMoment4Label.Text = $"Центральный момент порядка 4 (μ₄): {na}";
            skewnessLabel.Text = $"Коэффициент асимметрии (As): {na}";
            kurtosisLabel.Text = $"Коэффициент эксцесса (Ex): {na}";
        }


        private double CalculateMean(List<(double Value, double Frequency)> data)
        {
            if (!data.Any()) return double.NaN;
            double sum = data.Sum(p => p.Value * p.Frequency);
            double totalFrequency = data.Sum(p => p.Frequency);
            return totalFrequency == 0 ? double.NaN : sum / totalFrequency;
        }

        private double CalculateMedian(List<(double Value, double Frequency)> sortedData)
        {
            if (!sortedData.Any()) return double.NaN;
            double totalFrequency = sortedData.Sum(p => p.Frequency);
            if (totalFrequency <= 0) return double.NaN;

            double halfFrequency = totalFrequency / 2.0;
            double cumulativeFrequency = 0;

            if (!isContinuous)
            {
                for (int i = 0; i < sortedData.Count; i++)
                {
                    cumulativeFrequency += sortedData[i].Frequency;

                    if (cumulativeFrequency >= halfFrequency)
                    {
                        if (Math.Abs(cumulativeFrequency - halfFrequency) < 1e-9 && (totalFrequency % 2 == 0 || Math.Abs(totalFrequency % 2) < 1e-9) && i + 1 < sortedData.Count)
                        {
                            return (sortedData[i].Value + sortedData[i + 1].Value) / 2.0;
                        }
                        else
                        {
                            return sortedData[i].Value;
                        }
                    }
                }
                return sortedData.LastOrDefault().Value;
            }
            else
            {
                int medianIntervalIndex = -1;
                cumulativeFrequency = 0;
                double prevCumulativeFrequency = 0;

                for (int i = 0; i < sortedData.Count; i++)
                {
                    prevCumulativeFrequency = cumulativeFrequency;
                    cumulativeFrequency += sortedData[i].Frequency;
                    if (cumulativeFrequency >= halfFrequency)
                    {
                        medianIntervalIndex = i;
                        break;
                    }
                }

                if (medianIntervalIndex == -1) return double.NaN;

                if (medianIntervalIndex >= continuousIntervals.Count) return double.NaN;

                string intervalStr = continuousIntervals[medianIntervalIndex];
                if (!TryParseInterval(intervalStr, out double lowerBound, out double upperBound))
                {
                    return double.NaN;
                }

                double intervalWidth = upperBound - lowerBound;
                double medianIntervalFrequency = sortedData[medianIntervalIndex].Frequency;

                if (medianIntervalFrequency <= 0)
                {
                    return lowerBound;
                }

                return lowerBound + ((halfFrequency - prevCumulativeFrequency) / medianIntervalFrequency) * intervalWidth;
            }
        }

        private double CalculateMode(List<(double Value, double Frequency)> sortedData)
        {
            if (!sortedData.Any()) return double.NaN;

            double maxFrequency = 0;
            bool hasPositiveFrequency = false;
            foreach (var p in sortedData)
            {
                if (!double.IsNaN(p.Frequency) && p.Frequency > 0) hasPositiveFrequency = true;
                if (!double.IsNaN(p.Frequency) && p.Frequency > maxFrequency) maxFrequency = p.Frequency;
            }

            if (maxFrequency <= 0 && !hasPositiveFrequency) return double.NaN;
            if (maxFrequency <= 0 && hasPositiveFrequency) return double.NaN;

            var modesInfo = sortedData.Where(p => Math.Abs(p.Frequency - maxFrequency) < 1e-9).ToList();

            if (modesInfo.Count == 1)
            {
                var modePoint = modesInfo[0];
                if (isContinuous)
                {
                    int modeSortedIndex = sortedData.FindIndex(p => Math.Abs(p.Value - modePoint.Value) < 1e-9);
                    if (modeSortedIndex == -1) return double.NaN;

                    if (modeSortedIndex >= continuousIntervals.Count) return double.NaN;
                    string intervalStr = continuousIntervals[modeSortedIndex];

                    if (!TryParseInterval(intervalStr, out double lowerBound, out double upperBound)) return double.NaN;

                    double intervalWidth = upperBound - lowerBound;
                    double modeFrequency = modePoint.Frequency;

                    double prevFrequency = (modeSortedIndex > 0) ? sortedData[modeSortedIndex - 1].Frequency : 0;
                    double nextFrequency = (modeSortedIndex < sortedData.Count - 1) ? sortedData[modeSortedIndex + 1].Frequency : 0;

                    double delta1 = modeFrequency - prevFrequency;
                    double delta2 = modeFrequency - nextFrequency;

                    double denominator = delta1 + delta2;

                    if (Math.Abs(denominator) < 1e-9 || delta1 < 0 || delta2 < 0)
                    {
                        return modePoint.Value;
                    }

                    return lowerBound + (delta1 / denominator) * intervalWidth;
                }
                else
                {
                    return modePoint.Value;
                }
            }
            else
            {
                if (modesInfo.Count == sortedData.Count && maxFrequency > 0) return double.NaN;

                return double.NaN;
            }
        }

        private double CalculateMeanAbsoluteDeviation(List<(double Value, double Frequency)> data, double mean)
        {
            if (double.IsNaN(mean) || !data.Any()) return double.NaN;
            double totalFrequency = data.Sum(p => p.Frequency);
            if (totalFrequency <= 0) return double.NaN;
            double sum = data.Sum(p => Math.Abs(p.Value - mean) * p.Frequency);
            return sum / totalFrequency;
        }

        private double CalculateSampleVariance(List<(double Value, double Frequency)> data, double mean)
        {
            if (double.IsNaN(mean) || !data.Any()) return double.NaN;
            double totalFrequency = data.Sum(p => p.Frequency);
            if (totalFrequency <= 1) return double.NaN;

            double sum = data.Sum(p => Math.Pow(p.Value - mean, 2) * p.Frequency);
            return sum / (totalFrequency - 1);
        }

        private double CalculateStandardDeviation(double variance)
        {
            if (double.IsNaN(variance) || variance < 0) return double.NaN;
            return Math.Sqrt(variance);
        }

        private double CalculateCoefficientOfVariation(double standardDeviation, double mean)
        {
            if (double.IsNaN(standardDeviation) || double.IsNaN(mean) || Math.Abs(mean) < 1e-9)
            {
                return double.NaN;
            }
            return (standardDeviation / Math.Abs(mean)) * 100.0;
        }

        private double CalculateInitialMoment(List<(double Value, double Frequency)> data, int order)
        {
            if (!data.Any()) return double.NaN;
            double totalFrequency = data.Sum(p => p.Frequency);
            if (totalFrequency <= 0) return double.NaN;
            double sum = data.Sum(p => Math.Pow(p.Value, order) * p.Frequency);
            return sum / totalFrequency;
        }

        private double CalculateCentralMoment(List<(double Value, double Frequency)> data, double mean, int order)
        {
            if (double.IsNaN(mean) || !data.Any()) return double.NaN;
            double totalFrequency = data.Sum(p => p.Frequency);
            if (totalFrequency <= 0) return double.NaN;

            double sum = data.Sum(p => Math.Pow(p.Value - mean, order) * p.Frequency);

            if (order == 1) return 0.0;

            return sum / totalFrequency;
        }

        private double CalculateSkewness(double centralMoment3, double biasedStandardDeviation)
        {
            if (double.IsNaN(centralMoment3) || double.IsNaN(biasedStandardDeviation) || Math.Abs(biasedStandardDeviation) < 1e-9)
            {
                return double.NaN;
            }

            double stdDevCubed = Math.Pow(biasedStandardDeviation, 3);
            if (Math.Abs(stdDevCubed) < 1e-9) return double.NaN;

            return centralMoment3 / stdDevCubed;
        }

        private double CalculateKurtosis(double centralMoment4, double biasedStandardDeviation)
        {
            if (double.IsNaN(centralMoment4) || double.IsNaN(biasedStandardDeviation) || Math.Abs(biasedStandardDeviation) < 1e-9)
            {
                return double.NaN;
            }

            double stdDevPow4 = Math.Pow(biasedStandardDeviation, 4);
            if (Math.Abs(stdDevPow4) < 1e-9) return double.NaN;

            return (centralMoment4 / stdDevPow4) - 3.0;
        }

        private void ShowChart()
        {
            if (!calculatedData.Any())
            {
                MessageBox.Show("Нет данных для построения графика.", "Нет данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (chartForm != null && !chartForm.IsDisposed)
            {
                chartForm.Close();
            }

            chartForm = new Form
            {
                Text = "График статистического ряда",
                Width = 900,
                Height = 600,
                StartPosition = FormStartPosition.CenterParent,
                MinimumSize = new Size(500, 400)
            };

            Form mainWin = this.FindForm();
            if (mainWin != null)
            {
                chartForm.Owner = mainWin;
            }

            chartForm.FormClosed += (s, args) => { chartForm = null; chart = null; chartTypeSelector = null; };

            chart = new Chart
            {
                Dock = DockStyle.Fill,
                Palette = ChartColorPalette.Pastel
            };

            ChartArea chartArea = new ChartArea("MainArea");
            chart.ChartAreas.Add(chartArea);

            chart.Legends.Add(new Legend("Legend") { Docking = Docking.Top });

            chartArea.AxisX.Title = isContinuous ? "Интервал / Середина интервала" : "Значение";
            chartArea.AxisY.Title = "Частота";
            chartArea.AxisX.LabelStyle.Format = "G";
            chartArea.AxisY.LabelStyle.Format = "G";
            chartArea.AxisX.IsMarginVisible = true;
            chartArea.AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
            chartArea.AxisX.IsStartedFromZero = false;
            chartArea.AxisY.IsStartedFromZero = true;
            chartArea.AxisX.LabelAutoFitStyle = LabelAutoFitStyles.WordWrap | LabelAutoFitStyles.LabelsAngleStep45 | LabelAutoFitStyles.StaggeredLabels;
            chartArea.AxisY.LabelAutoFitStyle = LabelAutoFitStyles.LabelsAngleStep45;

            chartArea.AxisX.ScaleView.Zoomable = true;
            chartArea.AxisY.ScaleView.Zoomable = true;
            chartArea.CursorX.AutoScroll = true;
            chartArea.CursorY.AutoScroll = true;
            chartArea.CursorX.IsUserSelectionEnabled = true;
            chartArea.CursorY.IsUserSelectionEnabled = true;

            chartTypeSelector = new ComboBox
            {
                Name = "chartTypeSelector",
                Location = new Point(110, 7),
                Width = 250,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            chartTypeSelector.Items.Clear();

            chartTypeSelector.Items.Add("Столбчатый график (Гистограмма частот)");
            if (isContinuous)
            {
                chartTypeSelector.Items.Add("Полигон частот");
                chartTypeSelector.Items.Add("Кумулята (Огива)");
            }
            else
            {
                chartTypeSelector.Items.Add("Линейчатый график");
                chartTypeSelector.Items.Add("Полигон частот");
                chartTypeSelector.Items.Add("Кумулята");
            }
            chartTypeSelector.SelectedIndex = 0;
            chartTypeSelector.SelectedIndexChanged += ChangeChartType;

            Panel topPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 40,
                BackColor = Color.WhiteSmoke
            };
            Label labelChartType = new Label
            {
                Text = "Тип графика:",
                AutoSize = true,
                Location = new Point(10, 10)
            };
            topPanel.Controls.Add(labelChartType);
            topPanel.Controls.Add(chartTypeSelector);

            chartForm.Controls.Add(topPanel);
            chartForm.Controls.Add(chart);
            chart.BringToFront();

            DrawSelectedChartType();

            chartForm.Show();
        }

        private void ChangeChartType(object sender, EventArgs e)
        {
            DrawSelectedChartType();
        }

        private void DrawSelectedChartType()
        {
            if (chart == null || chartTypeSelector == null || chartTypeSelector.SelectedItem == null || !calculatedData.Any()) return;

            string selectedType = chartTypeSelector.SelectedItem.ToString();

            chart.Series.Clear();

            var chartArea = chart.ChartAreas["MainArea"];
            chartArea.AxisX.LabelStyle.IsStaggered = false;
            chartArea.AxisX.Interval = Double.NaN;
            chartArea.AxisX.IntervalOffset = Double.NaN;
            chartArea.AxisX.LabelStyle.Angle = 0;
            chartArea.AxisX.Title = isContinuous ? "Интервал / Середина интервала" : "Значение";
            chartArea.AxisY.Title = "Частота";
            chartArea.AxisX.MajorGrid.Enabled = true;
            chartArea.AxisY.MajorGrid.Enabled = true;
            chartArea.AxisY.Interval = Double.NaN;
            chartArea.AxisY.LabelAutoFitStyle = LabelAutoFitStyles.LabelsAngleStep45;
            chartArea.AxisX.LabelAutoFitStyle = LabelAutoFitStyles.WordWrap | LabelAutoFitStyles.LabelsAngleStep45 | LabelAutoFitStyles.StaggeredLabels;

            switch (selectedType)
            {
                case "Столбчатый график (Гистограмма частот)":
                    if (isContinuous)
                        DrawIntervalHistogram();
                    else
                        DrawDiscreteColumnChart();
                    break;
                case "Полигон частот":
                    DrawFrequencyPolygon();
                    break;
                case "Кумулята (Огива)":
                case "Кумулята":
                    DrawCumulativeChart();
                    break;
                case "Линейчатый график":
                    if (!isContinuous) DrawDiscreteBarChart();
                    break;
            }
            chart.Invalidate();
        }

        private void ConfigureSeriesBasics(Series series, string name)
        {
            series.Name = name;
            series.Legend = "Legend";
            series.IsValueShownAsLabel = true;
            series.LabelFormat = "G3";
            series.ToolTip = "#VALY (#LABEL)";
            series.SmartLabelStyle.Enabled = true;
            series.SmartLabelStyle.AllowOutsidePlotArea = LabelOutsidePlotAreaStyle.Partial;
            series.SmartLabelStyle.MovingDirection = LabelAlignmentStyles.Top;
            series.Font = new System.Drawing.Font("Segoe UI", 8f);
            series.LabelForeColor = System.Drawing.Color.DimGray;
        }

        private void DrawIntervalHistogram()
        {
            if (!isContinuous || !continuousIntervals.Any() || continuousIntervals.Count != calculatedData.Count)
            {
                return;
            }

            var series = new Series { ChartType = SeriesChartType.Column };
            ConfigureSeriesBasics(series, "Гистограмма частот");
            series.SetCustomProperty("PointWidth", "1");
            series.ToolTip = $"Интервал: #LABEL\nЧастота: #VALY{{G}}";

            var chartArea = chart.ChartAreas["MainArea"];
            chartArea.AxisX.LabelStyle.IsStaggered = true;
            chartArea.AxisX.Interval = 1;
            chartArea.AxisX.IntervalOffset = 0;
            chartArea.AxisX.MajorGrid.Enabled = false;
            chartArea.AxisX.LabelStyle.Angle = -45;

            for (int i = 0; i < continuousIntervals.Count; i++)
            {
                string intervalLabel = continuousIntervals[i];
                double frequency = calculatedData[i].Frequency;

                if (!double.IsNaN(frequency))
                {
                    int pointIndex = series.Points.AddXY(i, frequency);
                    DataPoint dataPoint = series.Points[pointIndex];
                    dataPoint.AxisLabel = intervalLabel;
                    dataPoint.Label = frequency.ToString("G3");
                    dataPoint.ToolTip = $"Интервал: {intervalLabel}\nЧастота: {frequency:G}";
                }
            }
            chart.Series.Add(series);

            chartArea.AxisX.Minimum = -0.5;
            chartArea.AxisX.Maximum = continuousIntervals.Count - 0.5;
        }

        private void DrawDiscreteColumnChart()
        {
            var series = new Series { ChartType = SeriesChartType.Column };
            ConfigureSeriesBasics(series, "Столбчатый график");
            series.SetCustomProperty("PixelPointWidth", "50");
            series.ToolTip = $"Значение: #AXISLABEL\nЧастота: #VALY{{G}}";

            var chartArea = chart.ChartAreas["MainArea"];
            chartArea.AxisX.Interval = Double.NaN;
            chartArea.AxisX.LabelStyle.Angle = -45;
            chartArea.AxisX.MajorGrid.Enabled = true;

            foreach (var point in calculatedData)
            {
                if (!double.IsNaN(point.Value) && !double.IsNaN(point.Frequency))
                {
                    string label = point.Value.ToString("G");
                    int pointIndex = series.Points.AddXY(point.Value, point.Frequency);
                    DataPoint dataPoint = series.Points[pointIndex];
                    dataPoint.AxisLabel = label;
                    dataPoint.Label = point.Frequency.ToString("G3");
                    dataPoint.ToolTip = $"Значение: {label}\nЧастота: {point.Frequency:G}";
                }
            }
            chart.Series.Add(series);
        }

        private void DrawDiscreteBarChart()
        {
            var series = new Series { ChartType = SeriesChartType.Bar };
            ConfigureSeriesBasics(series, "Линейчатый график");
            series.ToolTip = $"Значение: #AXISLABEL\nЧастота: #VALY{{G}}";

            var chartArea = chart.ChartAreas["MainArea"];
            chartArea.AxisX.Title = "Частота";
            chartArea.AxisY.Title = "Значение";

            chartArea.AxisY.Interval = Double.NaN;
            chartArea.AxisY.LabelAutoFitStyle = LabelAutoFitStyles.None;
            chartArea.AxisY.IsReversed = false;

            chartArea.AxisX.LabelAutoFitStyle = LabelAutoFitStyles.LabelsAngleStep45;
            chartArea.AxisX.IsStartedFromZero = true;

            foreach (var point in calculatedData)
            {
                if (!double.IsNaN(point.Value) && !double.IsNaN(point.Frequency))
                {
                    string label = point.Value.ToString("G");
                    DataPoint dataPoint = new DataPoint();
                    dataPoint.SetValueXY(point.Value, point.Frequency);
                    dataPoint.AxisLabel = label;

                    dataPoint.Label = point.Frequency.ToString("G3");
                    dataPoint.ToolTip = $"Значение: {label}\nЧастота: {point.Frequency:G}";

                    series.Points.Add(dataPoint);
                }
            }
            chart.Series.Add(series);
        }

        private void DrawFrequencyPolygon()
        {
            string seriesName = "Полигон частот";
            var series = new Series { ChartType = SeriesChartType.Line };
            ConfigureSeriesBasics(series, seriesName);
            series.BorderWidth = 2;
            series.MarkerStyle = MarkerStyle.Circle;
            series.MarkerSize = 7;

            var chartArea = chart.ChartAreas["MainArea"];
            chartArea.AxisX.Interval = Double.NaN;
            chartArea.AxisX.LabelStyle.Angle = -45;

            for (int i = 0; i < calculatedData.Count; i++)
            {
                var point = calculatedData[i];
                if (!double.IsNaN(point.Value) && !double.IsNaN(point.Frequency))
                {
                    int pointIndex = series.Points.AddXY(point.Value, point.Frequency);
                    DataPoint dataPoint = series.Points[pointIndex];

                    string axisLabelStr;
                    string toolTipValueLabel;

                    if (isContinuous)
                    {
                        if (i < continuousIntervals.Count)
                        {
                            axisLabelStr = continuousIntervals[i];
                            toolTipValueLabel = $"Интервал: {axisLabelStr}";
                        }
                        else
                        {
                            axisLabelStr = point.Value.ToString("G");
                            toolTipValueLabel = $"Середина: {axisLabelStr}";
                        }
                        dataPoint.AxisLabel = point.Value.ToString("G");
                    }
                    else
                    {
                        axisLabelStr = point.Value.ToString("G");
                        toolTipValueLabel = $"Значение: {axisLabelStr}";
                        dataPoint.AxisLabel = axisLabelStr;
                    }

                    dataPoint.Label = point.Frequency.ToString("G3");
                    dataPoint.ToolTip = $"{toolTipValueLabel}\nЧастота: {point.Frequency:G}";
                }
            }
            chart.Series.Add(series);
        }


        private void DrawCumulativeChart()
        {
            string seriesName = isContinuous ? "Кумулята (Огива)" : "Кумулята";
            var series = new Series { ChartType = SeriesChartType.StepLine };
            ConfigureSeriesBasics(series, seriesName);
            series.BorderWidth = 2;
            series.MarkerStyle = MarkerStyle.Diamond;
            series.MarkerSize = 7;
            series.MarkerColor = Color.Red;
            series.EmptyPointStyle.MarkerStyle = MarkerStyle.None;

            var chartArea = chart.ChartAreas["MainArea"];
            chartArea.AxisY.Title = "Накопленная частота";
            chartArea.AxisX.Interval = Double.NaN;
            chartArea.AxisX.LabelStyle.Angle = -45;

            double cumulativeFrequency = 0;
            double totalFrequency = calculatedData.Sum(p => p.Frequency);

            chartArea.AxisY.Maximum = totalFrequency > 0 ? totalFrequency * 1.05 : Double.NaN;

            if (isContinuous && calculatedData.Any() && continuousIntervals.Any())
            {
                if (TryParseInterval(continuousIntervals[0], out double firstLower, out _))
                {
                    int pIndex = series.Points.AddXY(firstLower, 0);
                    DataPoint dp = series.Points[pIndex];
                    dp.AxisLabel = firstLower.ToString("G");
                    dp.IsValueShownAsLabel = false;
                    dp.ToolTip = $"Начало ({firstLower:G})\nНакопленная частота: 0";
                }
            }

            for (int i = 0; i < calculatedData.Count; i++)
            {
                var point = calculatedData[i];
                if (!double.IsNaN(point.Value) && !double.IsNaN(point.Frequency))
                {
                    cumulativeFrequency += point.Frequency;

                    double xValue;
                    string axisLabelStr;
                    string toolTipValueLabel;

                    if (isContinuous)
                    {
                        if (i < continuousIntervals.Count && TryParseInterval(continuousIntervals[i], out _, out double upperBound))
                        {
                            xValue = upperBound;
                            axisLabelStr = upperBound.ToString("G");
                            toolTipValueLabel = $"Интервал: {continuousIntervals[i]}";
                        }
                        else
                        {
                            xValue = point.Value;
                            axisLabelStr = point.Value.ToString("G") + " (ошибка интервала)";
                            toolTipValueLabel = $"Середина: {point.Value.ToString("G")}";
                        }
                    }
                    else
                    {
                        xValue = point.Value;
                        axisLabelStr = point.Value.ToString("G");
                        toolTipValueLabel = $"Значение: {axisLabelStr}";
                    }

                    int pointIndex = series.Points.AddXY(xValue, cumulativeFrequency);
                    DataPoint dataPoint = series.Points[pointIndex];
                    dataPoint.AxisLabel = axisLabelStr;
                    dataPoint.Label = cumulativeFrequency.ToString("G3");
                    dataPoint.ToolTip = $"{toolTipValueLabel}\nНакопленная частота: {cumulativeFrequency:G}";
                }
            }
            chart.Series.Add(series);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (chartForm != null && !chartForm.IsDisposed)
                {
                    chartForm.Close();
                }
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
    }
}