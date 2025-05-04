using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;
using System.Globalization;

namespace MathStatRGR
{
    public class VarSeriesControl : UserControl
    {
        private MetroRadioButton discreteRadio;
        private MetroRadioButton continuousRadio;
        private MetroButton browseButton;
        private DataGridView dataGrid;
        private MetroLabel meanLabel;
        private MetroLabel medianLabel;
        private MetroLabel modeLabel;
        private MetroLabel meanAbsoluteDeviationLabel;
        private MetroLabel sampleVarianceLabel;
        private MetroLabel standardDeviationLabel;
        private MetroLabel coefficientOfVariationLabel;
        private MetroLabel initialMoment1Label;
        private MetroLabel centralMoment1Label;
        private MetroLabel initialMoment2Label;
        private MetroLabel centralMoment2Label;
        private MetroLabel initialMoment3Label;
        private MetroLabel centralMoment3Label;
        private MetroLabel initialMoment4Label;
        private MetroLabel centralMoment4Label;
        private MetroLabel skewnessLabel;
        private MetroLabel kurtosisLabel;
        private MetroButton calculateButton;
        private MetroButton showChartButton;

        private TableLayoutPanel mainTableLayout;
        private Panel inputPanel;
        private Panel resultsPanel;
        private GroupBox statisticsGroupBox;
        private GroupBox momentsGroupBox;

        private Form chartForm;
        private Chart chart;
        private ComboBox chartTypeSelector;

        private List<(double Value, double Frequency)> calculatedData = new List<(double, double)>();
        private bool isContinuous = false;
        private List<string> continuousIntervals = new List<string>();

        public VarSeriesControl()
        {
            InitializeComponents();
            System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            System.Threading.Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
        }

        private void InitializeComponents()
        {
            mainTableLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 1,
                Padding = new Padding(10),
            };

            mainTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40));
            mainTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60));
            mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

            inputPanel = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                Padding = new Padding(5)
            };

            resultsPanel = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                Padding = new Padding(5)
            };

            discreteRadio = new MetroRadioButton
            {
                Text = "Дискретный ряд",
                Name = "discreteRadio",
                Size = new Size(300, 30),
                Checked = true
            };
            discreteRadio.CheckedChanged += RadioButton_CheckedChanged;

            continuousRadio = new MetroRadioButton
            {
                Text = "Непрерывный ряд",
                Name = "continuousRadio",
                Size = new Size(300, 30)
            };
            continuousRadio.CheckedChanged += RadioButton_CheckedChanged;

            browseButton = new MetroButton
            {
                Text = "ВЫБРАТЬ ФАЙЛ",
                Size = new Size(300, 30),
                FontWeight = MetroFramework.MetroButtonWeight.Regular,
                Highlight = true
            };
            browseButton.Click += BrowseButton_Click;

            dataGrid = new DataGridView
            {
                Size = new Size(300, 200),
                AllowUserToAddRows = true,
                AllowUserToDeleteRows = true,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.White,
                RowHeadersVisible = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                GridColor = Color.LightGray
            };

            calculateButton = new MetroButton
            {
                Text = "РАССЧИТАТЬ",
                Size = new Size(300, 30),
                FontWeight = MetroFramework.MetroButtonWeight.Bold,
                Highlight = true
            };
            calculateButton.Click += CalculateButton_Click;

            showChartButton = new MetroButton
            {
                Text = "ПОКАЗАТЬ ГРАФИК",
                Size = new Size(300, 30),
                FontWeight = MetroFramework.MetroButtonWeight.Bold,
                Highlight = true,
                Enabled = false
            };
            showChartButton.Click += ShowChartButton_Click;

            UpdateGridColumns();

            statisticsGroupBox = new GroupBox
            {
                Text = "Основные характеристики",
                Dock = DockStyle.Top,
                AutoSize = true,
                Padding = new Padding(10)
            };

            momentsGroupBox = new GroupBox
            {
                Text = "Моменты распределения",
                Dock = DockStyle.Top,
                AutoSize = true,
                Padding = new Padding(10)
            };

            meanLabel = CreateStyledLabel("Средняя арифметическая: ");
            medianLabel = CreateStyledLabel("Медиана: ");
            modeLabel = CreateStyledLabel("Мода: ");
            meanAbsoluteDeviationLabel = CreateStyledLabel("Среднее линейное отклонение: ");
            sampleVarianceLabel = CreateStyledLabel("Выборочная дисперсия: ");
            standardDeviationLabel = CreateStyledLabel("Среднее квадратическое отклонение: ");
            coefficientOfVariationLabel = CreateStyledLabel("Коэффициент вариации: ");
            skewnessLabel = CreateStyledLabel("Коэффициент асимметрии: ");
            kurtosisLabel = CreateStyledLabel("Коэффициент эксцесса: ");

            initialMoment1Label = CreateStyledLabel("Начальный момент порядка 1: ");
            initialMoment2Label = CreateStyledLabel("Начальный момент порядка 2: ");
            initialMoment3Label = CreateStyledLabel("Начальный момент порядка 3: ");
            initialMoment4Label = CreateStyledLabel("Начальный момент порядка 4: ");
            centralMoment1Label = CreateStyledLabel("Центральный момент порядка 1: ");
            centralMoment2Label = CreateStyledLabel("Центральный момент порядка 2: ");
            centralMoment3Label = CreateStyledLabel("Центральный момент порядка 3: ");
            centralMoment4Label = CreateStyledLabel("Центральный момент порядка 4: ");

            FlowLayoutPanel inputFlowPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                AutoSize = true,
                WrapContents = false
            };

            inputFlowPanel.Controls.Add(new Label { Text = "Тип вариационного ряда:", AutoSize = true, Margin = new Padding(0, 10, 0, 5) });
            inputFlowPanel.Controls.Add(discreteRadio);
            inputFlowPanel.Controls.Add(continuousRadio);
            inputFlowPanel.Controls.Add(new Label { Text = " ", AutoSize = true, Height = 10 });
            inputFlowPanel.Controls.Add(browseButton);
            inputFlowPanel.Controls.Add(new Label { Text = "Данные:", AutoSize = true, Margin = new Padding(0, 10, 0, 5) });
            inputFlowPanel.Controls.Add(dataGrid);
            inputFlowPanel.Controls.Add(new Label { Text = " ", AutoSize = true, Height = 10 });
            inputFlowPanel.Controls.Add(calculateButton);
            inputFlowPanel.Controls.Add(new Label { Text = " ", AutoSize = true, Height = 10 });
            inputFlowPanel.Controls.Add(showChartButton);

            inputPanel.Controls.Add(inputFlowPanel);

            TableLayoutPanel statsTable = new TableLayoutPanel { Dock = DockStyle.Fill, AutoSize = true, ColumnCount = 1, RowCount = 9, Padding = new Padding(5) };
            statsTable.Controls.Add(meanLabel, 0, 0);
            statsTable.Controls.Add(medianLabel, 0, 1);
            statsTable.Controls.Add(modeLabel, 0, 2);
            statsTable.Controls.Add(meanAbsoluteDeviationLabel, 0, 3);
            statsTable.Controls.Add(sampleVarianceLabel, 0, 4);
            statsTable.Controls.Add(standardDeviationLabel, 0, 5);
            statsTable.Controls.Add(coefficientOfVariationLabel, 0, 6);
            statsTable.Controls.Add(skewnessLabel, 0, 7);
            statsTable.Controls.Add(kurtosisLabel, 0, 8);
            statisticsGroupBox.Controls.Add(statsTable);

            TableLayoutPanel momentsTable = new TableLayoutPanel { Dock = DockStyle.Fill, AutoSize = true, ColumnCount = 2, RowCount = 4, Padding = new Padding(5) };
            momentsTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            momentsTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            momentsTable.Controls.Add(initialMoment1Label, 0, 0);
            momentsTable.Controls.Add(centralMoment1Label, 1, 0);
            momentsTable.Controls.Add(initialMoment2Label, 0, 1);
            momentsTable.Controls.Add(centralMoment2Label, 1, 1);
            momentsTable.Controls.Add(initialMoment3Label, 0, 2);
            momentsTable.Controls.Add(centralMoment3Label, 1, 2);
            momentsTable.Controls.Add(initialMoment4Label, 0, 3);
            momentsTable.Controls.Add(centralMoment4Label, 1, 3);
            momentsGroupBox.Controls.Add(momentsTable);

            resultsPanel.Controls.Add(momentsGroupBox);
            resultsPanel.Controls.Add(statisticsGroupBox);

            mainTableLayout.Controls.Add(inputPanel, 0, 0);
            mainTableLayout.Controls.Add(resultsPanel, 1, 0);

            Controls.Add(mainTableLayout);

            AutoScroll = true;
            Size = new Size(1000, 600);
        }

        private MetroLabel CreateStyledLabel(string text)
        {
            return new MetroLabel
            {
                Text = text,
                AutoSize = true,
                Margin = new Padding(0, 5, 0, 5),
                FontWeight = MetroFramework.MetroLabelWeight.Regular
            };
        }

        private void UpdateGridColumns()
        {
            dataGrid.Rows.Clear();
            dataGrid.Columns.Clear();
            calculatedData.Clear();
            continuousIntervals.Clear();
            showChartButton.Enabled = false;

            if (continuousRadio.Checked)
            {
                dataGrid.Columns.Add("Interval", "Интервал");
                dataGrid.Columns.Add("Midpoint", "Середина (авто)");
                dataGrid.Columns.Add("Frequency", "Частота");
                dataGrid.Columns["Midpoint"].ReadOnly = true;
                dataGrid.Columns["Midpoint"].DefaultCellStyle.BackColor = Color.LightGray;
            }
            else
            {
                dataGrid.Columns.Add("Value", "Число");
                dataGrid.Columns.Add("Frequency", "Частота");
            }
            isContinuous = continuousRadio.Checked;
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (((MetroRadioButton)sender).Checked)
            {
                UpdateGridColumns();
                ClearResultLabels();
            }
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "CSV Files (*.csv)|*.csv|Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                openFileDialog.Title = "Выберите файл данных";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        LoadDataFromFile(openFileDialog.FileName);
                        ClearResultLabels();
                        showChartButton.Enabled = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка загрузки данных: {ex.Message}\n\nУбедитесь, что файл имеет правильный формат (значение,частота или интервал,частота).",
                                        "Ошибка файла", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            if (TryParseDataFromGrid())
            {
                CalculateAndDisplayStatistics();
                showChartButton.Enabled = calculatedData.Any();
            }
            else
            {
                showChartButton.Enabled = false;
                ClearResultLabels();
            }
        }

        private void ShowChartButton_Click(object sender, EventArgs e)
        {
            ShowChart();
        }

        private void LoadDataFromFile(string filePath)
        {
            dataGrid.Rows.Clear();
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                string[] values = line.Split(',', ';', '\t');

                if (continuousRadio.Checked)
                {
                    if (values.Length >= 2 && !string.IsNullOrWhiteSpace(values[0]) && !string.IsNullOrWhiteSpace(values[1]))
                    {
                        string interval = values[0].Trim();
                        string frequency = values[1].Trim();
                        string midpointDisplay = CalculateMidpointDisplay(interval);

                        dataGrid.Rows.Add(interval, midpointDisplay, frequency);
                    }
                    else
                    {
                        Console.WriteLine($"Skipping invalid line (continuous): {line}");
                    }
                }
                else
                {
                    if (values.Length >= 2 && !string.IsNullOrWhiteSpace(values[0]) && !string.IsNullOrWhiteSpace(values[1]))
                    {
                        dataGrid.Rows.Add(values[0].Trim(), values[1].Trim());
                    }
                    else
                    {
                        Console.WriteLine($"Skipping invalid line (discrete): {line}");
                    }
                }
            }
            calculateButton.PerformClick();
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


        private bool TryParseDataFromGrid()
        {
            calculatedData.Clear();
            continuousIntervals.Clear();
            List<string> errorMessages = new List<string>();
            isContinuous = continuousRadio.Checked;

            for (int i = 0; i < dataGrid.Rows.Count; i++)
            {
                DataGridViewRow row = dataGrid.Rows[i];
                if (row.IsNewRow) continue;

                double value = double.NaN;
                double frequency = double.NaN;
                bool rowValid = false;

                try
                {
                    if (isContinuous)
                    {
                        string intervalStr = row.Cells[0].Value?.ToString();
                        string freqStr = row.Cells[2].Value?.ToString();

                        if (!string.IsNullOrWhiteSpace(intervalStr) && !string.IsNullOrWhiteSpace(freqStr))
                        {
                            if (TryParseInterval(intervalStr, out double lower, out double upper) &&
                                double.TryParse(freqStr, NumberStyles.Any, CultureInfo.InvariantCulture, out frequency) &&
                                frequency >= 0)
                            {
                                value = (lower + upper) / 2.0;
                                continuousIntervals.Add(intervalStr);
                                rowValid = true;
                            }
                        }
                    }
                    else
                    {
                        string valStr = row.Cells[0].Value?.ToString();
                        string freqStr = row.Cells[1].Value?.ToString();

                        if (!string.IsNullOrWhiteSpace(valStr) && !string.IsNullOrWhiteSpace(freqStr))
                        {
                            if (double.TryParse(valStr, NumberStyles.Any, CultureInfo.InvariantCulture, out value) &&
                                double.TryParse(freqStr, NumberStyles.Any, CultureInfo.InvariantCulture, out frequency) &&
                                frequency >= 0)
                            {
                                rowValid = true;
                            }
                        }
                    }

                    if (rowValid)
                    {
                        calculatedData.Add((value, frequency));
                    }
                    else if (!row.Cells.Cast<DataGridViewCell>().All(c => c.Value == null || string.IsNullOrWhiteSpace(c.Value.ToString())))
                    {
                        errorMessages.Add($"Ошибка в строке {i + 1}: Неверный формат числа или частоты.");
                    }
                }
                catch (Exception ex)
                {
                    errorMessages.Add($"Ошибка в строке {i + 1}: {ex.Message}");
                }
            }

            if (errorMessages.Any())
            {
                MessageBox.Show("Обнаружены ошибки в данных:\n\n" + string.Join("\n", errorMessages) +
                                "\n\nПожалуйста, исправьте данные и попробуйте снова.",
                                "Ошибка данных", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!calculatedData.Any())
            {
                MessageBox.Show("Нет данных для расчета. Введите данные или загрузите файл.",
                                "Нет данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            calculatedData = calculatedData.OrderBy(p => p.Value).ToList();

            return true;
        }

        private void CalculateAndDisplayStatistics()
        {
            if (!calculatedData.Any()) return;

            double totalFrequency = calculatedData.Sum(p => p.Frequency);
            if (totalFrequency <= 0)
            {
                MessageBox.Show("Общая частота равна нулю или отрицательна. Расчет невозможен.", "Ошибка данных", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ClearResultLabels();
                showChartButton.Enabled = false;
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

            double skewness = CalculateSkewness(centralMoment3, standardDeviation);
            double kurtosis = CalculateKurtosis(centralMoment4, standardDeviation);

            meanLabel.Text = $"Средняя арифметическая: {FormatResult(mean)}";
            medianLabel.Text = $"Медиана: {FormatResult(median)}";
            modeLabel.Text = $"Мода: {FormatResult(mode)}";
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
            skewnessLabel.Text = $"Коэффициент асимметрии: {FormatResult(skewness)}";
            kurtosisLabel.Text = $"Коэффициент эксцесса: {FormatResult(kurtosis)}";
        }

        private string FormatResult(double value, string suffix = "", string format = "F4")
        {
            if (double.IsNaN(value) || double.IsInfinity(value))
            {
                return "Не определено";
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
            skewnessLabel.Text = $"Коэффициент асимметрии: {na}";
            kurtosisLabel.Text = $"Коэффициент эксцесса: {na}";
        }

        private double CalculateMean(List<(double Value, double Frequency)> data)
        {
            double sum = data.Sum(p => p.Value * p.Frequency);
            double totalFrequency = data.Sum(p => p.Frequency);
            return totalFrequency == 0 ? double.NaN : sum / totalFrequency;
        }

        private double CalculateMedian(List<(double Value, double Frequency)> sortedData)
        {
            double totalFrequency = sortedData.Sum(p => p.Frequency);
            if (totalFrequency == 0) return double.NaN;

            double halfFrequency = totalFrequency / 2.0;
            double cumulativeFrequency = 0;

            for (int i = 0; i < sortedData.Count; i++)
            {
                double prevCumulativeFrequency = cumulativeFrequency;
                cumulativeFrequency += sortedData[i].Frequency;

                if (cumulativeFrequency >= halfFrequency)
                {
                    if (totalFrequency % 2 == 0 && Math.Abs(cumulativeFrequency - halfFrequency) < 1e-9 && i > 0)
                    {
                        return sortedData[i].Value;
                    }
                    else if (prevCumulativeFrequency < halfFrequency)
                    {
                        return sortedData[i].Value;
                    }
                }
            }
            return sortedData.LastOrDefault().Value;
        }

        private double CalculateMode(List<(double Value, double Frequency)> data)
        {
            if (!data.Any()) return double.NaN;

            double maxFrequency = -1;
            double modeValue = double.NaN;
            bool multipleModes = false;

            var frequencyGroups = data.GroupBy(p => p.Value)
                                      .Select(g => new { Value = g.Key, TotalFrequency = g.Sum(p => p.Frequency) })
                                      .OrderByDescending(g => g.TotalFrequency)
                                      .ToList();

            if (!frequencyGroups.Any()) return double.NaN;

            maxFrequency = frequencyGroups[0].TotalFrequency;
            modeValue = frequencyGroups[0].Value;

            if (frequencyGroups.Count > 1 && frequencyGroups[1].TotalFrequency == maxFrequency)
            {
                multipleModes = true;
            }

            if (frequencyGroups.All(g => g.TotalFrequency == maxFrequency))
            {
                return double.NaN;
            }


            return modeValue;
        }

        private double CalculateMeanAbsoluteDeviation(List<(double Value, double Frequency)> data, double mean)
        {
            if (double.IsNaN(mean)) return double.NaN;
            double sum = data.Sum(p => Math.Abs(p.Value - mean) * p.Frequency);
            double totalFrequency = data.Sum(p => p.Frequency);
            return totalFrequency == 0 ? double.NaN : sum / totalFrequency;
        }

        private double CalculateSampleVariance(List<(double Value, double Frequency)> data, double mean)
        {
            if (double.IsNaN(mean)) return double.NaN;
            double totalFrequency = data.Sum(p => p.Frequency);
            if (totalFrequency <= 1) return double.NaN;

            double sum = data.Sum(p => Math.Pow(p.Value - mean, 2) * p.Frequency);
            return sum / (totalFrequency - 1);
        }

        private double CalculateStandardDeviation(double sampleVariance)
        {
            if (double.IsNaN(sampleVariance) || sampleVariance < 0) return double.NaN;
            return Math.Sqrt(sampleVariance);
        }

        private double CalculateCoefficientOfVariation(double standardDeviation, double mean)
        {
            if (double.IsNaN(standardDeviation) || double.IsNaN(mean) || Math.Abs(mean) < 1e-9)
            {
                return double.NaN;
            }
            return (standardDeviation / mean) * 100.0;
        }

        private double CalculateInitialMoment(List<(double Value, double Frequency)> data, int order)
        {
            double sum = data.Sum(p => Math.Pow(p.Value, order) * p.Frequency);
            double totalFrequency = data.Sum(p => p.Frequency);
            return totalFrequency == 0 ? double.NaN : sum / totalFrequency;
        }

        private double CalculateCentralMoment(List<(double Value, double Frequency)> data, double mean, int order)
        {
            if (double.IsNaN(mean)) return double.NaN;
            double sum = data.Sum(p => Math.Pow(p.Value - mean, order) * p.Frequency);
            double totalFrequency = data.Sum(p => p.Frequency);
            return totalFrequency == 0 ? double.NaN : sum / totalFrequency;
        }

        private double CalculateSkewness(double centralMoment3, double standardDeviation)
        {
            if (double.IsNaN(centralMoment3) || double.IsNaN(standardDeviation) || Math.Abs(standardDeviation) < 1e-9)
            {
                return double.NaN;
            }
            return centralMoment3 / Math.Pow(standardDeviation, 3);
        }

        private double CalculateKurtosis(double centralMoment4, double standardDeviation)
        {
            if (double.IsNaN(centralMoment4) || double.IsNaN(standardDeviation) || Math.Abs(standardDeviation) < 1e-9)
            {
                return double.NaN;
            }
            double stdDevPow4 = Math.Pow(standardDeviation, 4);
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
                StartPosition = FormStartPosition.CenterParent
            };

            Form mainWin = this.FindForm();
            if (mainWin != null)
            {
                chartForm.Owner = mainWin;
            }

            chartForm.FormClosed += (s, args) => { chartForm = null; };

            chart = new Chart { Dock = DockStyle.Fill };
            chart.ChartAreas.Add(new ChartArea("MainArea"));
            chart.Legends.Add(new Legend("Legend"));

            chart.ChartAreas["MainArea"].AxisX.Title = isContinuous ? "Середина интервала / Интервал" : "Значения";
            chart.ChartAreas["MainArea"].AxisY.Title = "Частота";
            chart.ChartAreas["MainArea"].AxisX.LabelStyle.Format = "G";
            chart.ChartAreas["MainArea"].AxisY.LabelStyle.Format = "G";
            chart.ChartAreas["MainArea"].AxisX.IsMarginVisible = true;
            chart.ChartAreas["MainArea"].AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
            chart.ChartAreas["MainArea"].AxisX.IsStartedFromZero = false;
            chart.ChartAreas["MainArea"].AxisY.IsStartedFromZero = true;

            chartTypeSelector = new ComboBox
            {
                Location = new Point(110, 7),
                Width = 200,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            chartTypeSelector.Items.Clear();

            chartTypeSelector.Items.Add("Столбчатый график (Гистограмма)");
            if (isContinuous)
            {
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

            Panel topPanel = new Panel { Dock = DockStyle.Top, Height = 40, BackColor = Color.LightGray };
            Label labelChartType = new Label { Text = "Тип графика:", AutoSize = true, Location = new Point(10, 10) };
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
            if (chart == null || chartTypeSelector == null || chartTypeSelector.SelectedItem == null) return;

            string selectedType = chartTypeSelector.SelectedItem.ToString();

            chart.Series.Clear();

            chart.ChartAreas["MainArea"].AxisX.LabelStyle.IsStaggered = false;
            chart.ChartAreas["MainArea"].AxisX.Interval = 0;
            chart.ChartAreas["MainArea"].AxisX.LabelAutoFitStyle = LabelAutoFitStyles.WordWrap | LabelAutoFitStyles.StaggeredLabels | LabelAutoFitStyles.LabelsAngleStep45;


            if (isContinuous)
            {
                switch (selectedType)
                {
                    case "Столбчатый график (Гистограмма)":
                        DrawIntervalHistogram();
                        break;
                    case "Кумулята (Огива)":
                        DrawCumulativeChart();
                        break;
                }
            }
            else
            {
                switch (selectedType)
                {
                    case "Столбчатый график (Гистограмма)":
                        DrawDiscreteColumnChart();
                        break;
                    case "Линейчатый график":
                        DrawDiscreteBarChart();
                        break;
                    case "Полигон частот":
                        DrawDiscreteLineChart();
                        break;
                    case "Кумулята":
                        DrawCumulativeChart();
                        break;
                }
            }
            chart.Invalidate();
        }

        private void ConfigureSeriesBasics(Series series, string name)
        {
            series.Name = name;
            series.Legend = "Legend";
            series.IsValueShownAsLabel = true;
            series.LabelFormat = "G3";
            series.ToolTip = "#VALY (#VALX)";
        }

        private void DrawIntervalHistogram()
        {
            var series = new Series { ChartType = SeriesChartType.Column };
            ConfigureSeriesBasics(series, "Гистограмма частот");
            series.SetCustomProperty("PixelPointWidth", "50");

            foreach (var point in calculatedData)
            {
                if (!double.IsNaN(point.Value) && !double.IsNaN(point.Frequency))
                {
                    series.Points.AddXY(point.Value, point.Frequency);
                }
            }
            if (continuousIntervals.Count == calculatedData.Count)
            {
                chart.ChartAreas["MainArea"].AxisX.LabelStyle.IsStaggered = true;
                for (int i = 0; i < series.Points.Count; i++)
                {
                    series.Points[i].AxisLabel = continuousIntervals[i];
                }
            }

            chart.Series.Add(series);
        }

        private void DrawDiscreteColumnChart()
        {
            var series = new Series { ChartType = SeriesChartType.Column };
            ConfigureSeriesBasics(series, "Столбчатый график");

            foreach (var point in calculatedData)
            {
                if (!double.IsNaN(point.Value) && !double.IsNaN(point.Frequency))
                {
                    series.Points.AddXY(point.Value, point.Frequency);
                }
            }
            chart.Series.Add(series);
        }

        private void DrawDiscreteBarChart()
        {
            var series = new Series { ChartType = SeriesChartType.Bar };
            ConfigureSeriesBasics(series, "Линейчатый график");
            chart.ChartAreas["MainArea"].AxisX.Title = "Частота";
            chart.ChartAreas["MainArea"].AxisY.Title = "Значения";

            foreach (var point in calculatedData)
            {
                if (!double.IsNaN(point.Value) && !double.IsNaN(point.Frequency))
                {
                    series.Points.AddXY(point.Value, point.Frequency);
                }
            }
            chart.Series.Add(series);
        }

        private void DrawDiscreteLineChart()
        {
            var series = new Series { ChartType = SeriesChartType.Line };
            ConfigureSeriesBasics(series, "Полигон частот");
            series.BorderWidth = 2;
            series.MarkerStyle = MarkerStyle.Circle;
            series.MarkerSize = 7;

            foreach (var point in calculatedData)
            {
                if (!double.IsNaN(point.Value) && !double.IsNaN(point.Frequency))
                {
                    series.Points.AddXY(point.Value, point.Frequency);
                }
            }
            chart.Series.Add(series);
        }

        private void DrawCumulativeChart()
        {
            string seriesName = isContinuous ? "Кумулята (Огива)" : "Кумулята";
            var series = new Series { ChartType = SeriesChartType.Line };
            ConfigureSeriesBasics(series, seriesName);
            series.BorderWidth = 2;
            series.MarkerStyle = MarkerStyle.Diamond;
            series.MarkerSize = 7;
            chart.ChartAreas["MainArea"].AxisY.Title = "Накопленная частота";


            double cumulativeFrequency = 0;

            foreach (var point in calculatedData)
            {
                if (!double.IsNaN(point.Value) && !double.IsNaN(point.Frequency))
                {
                    cumulativeFrequency += point.Frequency;
                    double xValue = point.Value;
                    series.Points.AddXY(xValue, cumulativeFrequency);
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
            }
            base.Dispose(disposing);
        }
    }
}