using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MathStatRGR.Utils;
using MetroFramework.Controls;
using MathNet.Numerics.Distributions;

namespace MathStatRGR.Pages
{
    public partial class AnovaControls : MetroUserControl
    {
        private enum AnovaType
        {
            OneWay,
            TwoWayNoRepeats,
            TwoWayWithRepeats
        }

        private string factorAColName;
        private string factorBColName;
        private string valueColName;

        private bool isAdjustingSelections = false;

        public AnovaControls()
        {
            InitializeComponent();
            InitializeAnovaTypes();
            UpdateColumnMappingControls();
            browseButton.Click += BrowseButton_Click;
            calculateButton.Click += CalculateButton_Click;
            anovaTypeComboBox.SelectedIndexChanged += AnovaTypeComboBox_SelectedIndexChanged;
            factorAComboBox.SelectedIndexChanged += FactorComboBox_SelectedIndexChanged;
            factorBComboBox.SelectedIndexChanged += FactorComboBox_SelectedIndexChanged;
            valueComboBox.SelectedIndexChanged += FactorComboBox_SelectedIndexChanged;
        }

        private void InitializeAnovaTypes()
        {
            anovaTypeComboBox.Items.Add("Однофакторный");
            anovaTypeComboBox.Items.Add("Двухфакторный без повторений");
            anovaTypeComboBox.Items.Add("Двухфакторный с повторениями");
            anovaTypeComboBox.SelectedIndex = 0;
        }

        private void AnovaTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateColumnMappingControls();
        }

        private void UpdateColumnMappingControls()
        {
            isAdjustingSelections = true;

            AnovaType selectedType = (AnovaType)anovaTypeComboBox.SelectedIndex;
            bool hasColumns = dataGrid.Columns.Count > 0;

            factorALabel.Visible = true;
            factorAComboBox.Visible = true;
            factorAComboBox.Enabled = hasColumns;

            valueLabel.Visible = true;
            valueComboBox.Visible = true;
            valueComboBox.Enabled = hasColumns;

            switch (selectedType)
            {
                case AnovaType.OneWay:
                    factorBLabel.Visible = false;
                    factorBComboBox.Visible = false;
                    factorBComboBox.Enabled = false;
                    factorALabel.Text = "Столбец фактора (группы):";
                    valueLabel.Text = "Столбец измеряемых значений:";
                    break;
                case AnovaType.TwoWayNoRepeats:
                case AnovaType.TwoWayWithRepeats:
                    factorBLabel.Visible = true;
                    factorBComboBox.Visible = true;
                    factorBComboBox.Enabled = hasColumns;
                    factorALabel.Text = "Столбец фактора A:";
                    factorBLabel.Text = "Столбец фактора B:";
                    valueLabel.Text = "Столбец измеряемых значений:";
                    break;
            }
            PopulateColumnComboBoxes();

            isAdjustingSelections = false;
        }

        private void PopulateColumnComboBoxes()
        {
            isAdjustingSelections = true;

            string savedFactorA = factorAComboBox.SelectedItem as string;
            string savedFactorB = factorBComboBox.SelectedItem as string;
            string savedValue = valueComboBox.SelectedItem as string;

            factorAComboBox.Items.Clear();
            factorBComboBox.Items.Clear();
            valueComboBox.Items.Clear();

            bool hasColumns = dataGrid.Columns.Count > 0;

            factorAComboBox.Enabled = hasColumns;
            valueComboBox.Enabled = hasColumns;
            factorBComboBox.Enabled = hasColumns && factorBComboBox.Visible;

            if (hasColumns)
            {
                List<string> columnNames = new List<string>();
                foreach (DataGridViewColumn col in dataGrid.Columns)
                {
                    columnNames.Add(col.HeaderText);
                }

                factorAComboBox.Items.AddRange(columnNames.ToArray());
                if (factorBComboBox.Visible)
                    factorBComboBox.Items.AddRange(columnNames.ToArray());
                valueComboBox.Items.AddRange(columnNames.ToArray());

                if (factorAComboBox.Items.Count > 0)
                    factorAComboBox.SelectedIndex = 0;
                if (factorBComboBox.Visible && factorBComboBox.Items.Count > 1)
                    factorBComboBox.SelectedIndex = 1;
                else if (factorBComboBox.Visible && factorBComboBox.Items.Count > 0)
                    factorBComboBox.SelectedIndex = 0;
                if (valueComboBox.Items.Count > 2)
                    valueComboBox.SelectedIndex = 2;
                else if (valueComboBox.Items.Count > 1)
                    valueComboBox.SelectedIndex = 1;
                else if (valueComboBox.Items.Count > 0)
                    valueComboBox.SelectedIndex = 0;

                if (savedFactorA != null && factorAComboBox.Items.Contains(savedFactorA)) factorAComboBox.SelectedItem = savedFactorA;
                if (factorBComboBox.Visible && savedFactorB != null && factorBComboBox.Items.Contains(savedFactorB)) factorBComboBox.SelectedItem = savedFactorB;
                if (savedValue != null && valueComboBox.Items.Contains(savedValue)) valueComboBox.SelectedItem = savedValue;

                EnsureUniqueSelections();
            }
            isAdjustingSelections = false;
        }

        private void FactorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isAdjustingSelections)
            {
                EnsureUniqueSelections();
            }
        }

        private void EnsureUniqueSelections()
        {
            if (isAdjustingSelections) return;
            isAdjustingSelections = true;

            try
            {
                var activeComboBoxes = new List<MetroComboBox> { factorAComboBox, valueComboBox };
                if (factorBComboBox.Visible && factorBComboBox.Enabled)
                {
                    activeComboBoxes.Insert(1, factorBComboBox);
                }
                if (activeComboBoxes.Count < 2 || activeComboBoxes.Any(cb => cb.Items.Count == 0))
                {
                    isAdjustingSelections = false;
                    return;
                }


                bool changed;
                int attempts = 0;
                const int maxAttempts = 5;

                do
                {
                    changed = false;
                    attempts++;
                    var selectionGroups = activeComboBoxes
                        .Where(cb => cb.SelectedItem != null)
                        .GroupBy(cb => cb.SelectedItem.ToString())
                        .Where(g => g.Count() > 1)
                        .ToList();

                    foreach (var group in selectionGroups)
                    {
                        for (int i = 1; i < group.Count(); i++)
                        {
                            MetroComboBox cbToChange = group.ElementAt(i);
                            int currentIdx = cbToChange.SelectedIndex;
                            int itemsCount = cbToChange.Items.Count;
                            if (itemsCount <= 1) continue;

                            int nextIdx = currentIdx;
                            bool foundNew = false;
                            for (int offset = 1; offset < itemsCount; offset++)
                            {
                                nextIdx = (currentIdx + offset) % itemsCount;
                                string nextItem = cbToChange.Items[nextIdx].ToString();
                                if (!activeComboBoxes.Any(cb => cb != cbToChange && cb.SelectedItem != null && cb.SelectedItem.ToString().Equals(nextItem)))
                                {
                                    cbToChange.SelectedIndex = nextIdx;
                                    changed = true;
                                    foundNew = true;
                                    break;
                                }
                            }
                            if (changed) break;
                        }
                        if (changed) break;
                    }

                } while (changed && attempts < maxAttempts);
            }
            finally
            {
                isAdjustingSelections = false;
            }
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Файлы данных (*.xlsx;*.xls;*.xlsb;*.csv;*.txt)|*.xlsx;*.xls;*.xlsb;*.csv;*.txt" +
                                        "|Excel файлы (*.xlsx;*.xls;*.xlsb)|*.xlsx;*.xls;*.xlsb" +
                                        "|CSV файлы (*.csv)|*.csv" +
                                        "|Текстовые файлы (*.txt)|*.txt" +
                                        "|Все файлы (*.*)|*.*";
                openFileDialog.Title = "Выберите файл данных";
                if (openFileDialog.ShowDialog() != DialogResult.OK) return;

                LoadDataFromFile(openFileDialog.FileName);
            }
        }

        private void LoadDataFromFile(string filePath)
        {
            try
            {
                dataGrid.DataSource = null;
                dataGrid.Rows.Clear();
                dataGrid.Columns.Clear();

                string extension = Path.GetExtension(filePath).ToLowerInvariant();
                DataTable dt = new DataTable();

                if (extension == ".csv" || extension == ".txt")
                {
                    dt = LoadCsvOrTxtToDataTable(filePath);
                }
                else if (extension == ".xlsx" || extension == ".xls" || extension == ".xlsb")
                {
                    var dataTableCollection = ExcelTableReader.GetAllDataTables(filePath, true);
                    if (dataTableCollection == null || dataTableCollection.Count == 0)
                    {
                        MessageBox.Show("Не удалось прочитать данные из файла Excel или файл пуст.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    int sheetIndex = 0;
                    if (dataTableCollection.Count > 1)
                    {
                        sheetIndex = ExcelTableReader.GetSheetIndex(dataTableCollection.Count);
                        if (sheetIndex == -1) return;
                    }
                    dt = dataTableCollection[sheetIndex];
                }
                else
                {
                    MessageBox.Show("Неподдерживаемый тип файла.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (dt.Columns.Count == 0)
                {
                    MessageBox.Show("Выбранный лист или файл не содержит данных или заголовков.", "Нет данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Файл содержит только заголовки, но нет строк данных.", "Нет данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                dataGrid.Columns.Clear();
                dataGrid.DataSource = dt;
                PopulateColumnComboBoxes();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке файла: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PopulateColumnComboBoxes();
            }
        }

        private DataTable LoadCsvOrTxtToDataTable(string filePath)
        {
            var dt = new DataTable();
            var lines = File.ReadAllLines(filePath).Where(line => !string.IsNullOrWhiteSpace(line)).ToList();
            if (lines.Count == 0) return dt;

            char[] delimiters = { ',', ';', '\t', '|' };
            char detectedDelimiter = delimiters.FirstOrDefault(d => lines[0].Contains(d));
            if (detectedDelimiter == default(char) && lines[0].Contains(' '))
                detectedDelimiter = ' ';

            string[] headers;
            if (detectedDelimiter != default(char))
                headers = lines[0].Split(detectedDelimiter);
            else
                headers = new string[] { lines[0] };

            foreach (string header in headers)
            {
                string uniqueHeader = header.Trim();
                int suffix = 1;
                while (dt.Columns.Contains(uniqueHeader))
                {
                    uniqueHeader = $"{header.Trim()}_{suffix++}";
                }
                dt.Columns.Add(uniqueHeader);
            }


            for (int i = 1; i < lines.Count; i++)
            {
                string[] rows;
                if (detectedDelimiter != default(char))
                    rows = lines[i].Split(detectedDelimiter);
                else
                    rows = new string[] { lines[i] };

                if (rows.Length < dt.Columns.Count)
                {
                    string[] fullRow = new string[dt.Columns.Count];
                    Array.Copy(rows, fullRow, rows.Length);
                    for (int j = rows.Length; j < dt.Columns.Count; j++)
                        fullRow[j] = string.Empty;
                    rows = fullRow;
                }
                else if (rows.Length > dt.Columns.Count)
                    Array.Resize(ref rows, dt.Columns.Count);

                dt.Rows.Add(rows.Select(r => r.Trim()).ToArray());
            }
            return dt;
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            resultsDataGrid.DataSource = null;
            resultsDataGrid.Rows.Clear();
            resultsDataGrid.Columns.Clear();
            resultsConclusionLabel.Text = "";

            if (dataGrid.Rows.Count == 0 || dataGrid.Columns.Count < 1)
            {
                MessageBox.Show("Нет данных для анализа. Загрузите файл и убедитесь, что он содержит данные.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (factorAComboBox.SelectedItem == null || valueComboBox.SelectedItem == null ||
                (factorBComboBox.Visible && factorBComboBox.Enabled && factorBComboBox.SelectedItem == null))
            {
                MessageBox.Show("Выберите столбцы для всех необходимых факторов и значений.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (factorAComboBox.SelectedItem.ToString() == valueComboBox.SelectedItem.ToString() ||
               (factorBComboBox.Visible && factorBComboBox.Enabled && factorAComboBox.SelectedItem.ToString() == factorBComboBox.SelectedItem.ToString()) ||
               (factorBComboBox.Visible && factorBComboBox.Enabled && factorBComboBox.SelectedItem.ToString() == valueComboBox.SelectedItem.ToString()))
            {
                MessageBox.Show("Столбцы для факторов и значений должны быть уникальными. Проверьте выбор.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (!double.TryParse(alphaTextBox.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out double alpha) || alpha <= 0 || alpha >= 1)
            {
                MessageBox.Show("Уровень значимости Alpha должен быть числом от 0 до 1.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            AnovaType selectedType = (AnovaType)anovaTypeComboBox.SelectedIndex;

            try
            {
                switch (selectedType)
                {
                    case AnovaType.OneWay:
                        PerformOneWayAnova(alpha);
                        break;
                    case AnovaType.TwoWayNoRepeats:
                        PerformTwoWayAnova(alpha, false);
                        break;
                    case AnovaType.TwoWayWithRepeats:
                        PerformTwoWayAnova(alpha, true);
                        break;
                }
            }
            catch (ArgumentException argEx)
            {
                MessageBox.Show($"Ошибка конфигурации столбцов: {argEx.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                resultsConclusionLabel.Text = $"Ошибка конфигурации: {argEx.Message}";
            }
            catch (FormatException formatEx)
            {
                MessageBox.Show($"Ошибка формата данных: {formatEx.Message} Убедитесь, что числовые столбцы содержат только числа.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                resultsConclusionLabel.Text = $"Ошибка формата данных: {formatEx.Message}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при расчете: {ex.Message}\n{ex.StackTrace}", "Критическая ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                resultsConclusionLabel.Text = $"Непредвиденная ошибка: {ex.Message}";
            }
        }

        private List<double> GetColumnData(string columnName)
        {
            var data = new List<double>();
            int colIndex = -1;
            for (int i = 0; i < dataGrid.Columns.Count; i++)
            {
                if (dataGrid.Columns[i].HeaderText == columnName)
                {
                    colIndex = i;
                    break;
                }
            }

            if (colIndex == -1) throw new ArgumentException($"Столбец '{columnName}' не найден.");

            for (int rowIndex = 0; rowIndex < dataGrid.Rows.Count; rowIndex++)
            {
                DataGridViewRow row = dataGrid.Rows[rowIndex];
                if (row.IsNewRow) continue;

                var cellValue = row.Cells[colIndex].Value;
                if (cellValue == null || string.IsNullOrWhiteSpace(cellValue.ToString())) continue;

                if (double.TryParse(cellValue.ToString().Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture, out double val))
                {
                    data.Add(val);
                }
                else
                {
                    throw new FormatException($"Не удалось преобразовать значение '{cellValue}' в столбце '{columnName}' (строка {rowIndex + 1}) в число.");
                }
            }
            return data;
        }
        private List<string> GetFactorLevels(string factorColumnName, bool forPairedValueColumn = false, string valueColumnNameToPair = "")
        {
            var levels = new List<string>();
            int factorColIndex = -1;
            int valueColIndex = -1;

            for (int i = 0; i < dataGrid.Columns.Count; i++)
            {
                if (dataGrid.Columns[i].HeaderText == factorColumnName) factorColIndex = i;
                if (forPairedValueColumn && dataGrid.Columns[i].HeaderText == valueColumnNameToPair) valueColIndex = i;
            }

            if (factorColIndex == -1) throw new ArgumentException($"Столбец фактора '{factorColumnName}' не найден.");
            if (forPairedValueColumn && valueColIndex == -1) throw new ArgumentException($"Парный столбец значений '{valueColumnNameToPair}' не найден.");


            for (int rowIndex = 0; rowIndex < dataGrid.Rows.Count; rowIndex++)
            {
                DataGridViewRow row = dataGrid.Rows[rowIndex];
                if (row.IsNewRow) continue;

                if (forPairedValueColumn)
                {
                    var cellValue = row.Cells[valueColIndex].Value;
                    if (cellValue == null || string.IsNullOrWhiteSpace(cellValue.ToString())) continue;
                    if (!double.TryParse(cellValue.ToString().Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture, out _)) continue;
                }

                var cellFactor = row.Cells[factorColIndex].Value;
                if (cellFactor == null || string.IsNullOrWhiteSpace(cellFactor.ToString())) continue;

                levels.Add(cellFactor.ToString().Trim());
            }
            return levels;
        }


        private void PerformOneWayAnova(double alpha)
        {
            factorAColName = factorAComboBox.SelectedItem.ToString();
            valueColName = valueComboBox.SelectedItem.ToString();

            var factorLevels = GetFactorLevels(factorAColName, true, valueColName);
            var values = GetColumnData(valueColName);

            if (values.Count == 0)
            {
                resultsConclusionLabel.Text = "Нет валидных данных для анализа.";
                return;
            }
            if (factorLevels.Count != values.Count)
            {
                resultsConclusionLabel.Text = "Ошибка: Несоответствие данных после фильтрации.";
                return;
            }

            var groups = new Dictionary<string, List<double>>();
            for (int i = 0; i < factorLevels.Count; i++)
            {
                string level = factorLevels[i];
                if (!groups.ContainsKey(level)) groups[level] = new List<double>();
                groups[level].Add(values[i]);
            }

            groups = groups.Where(g => g.Value.Any()).ToDictionary(g => g.Key, g => g.Value);
            if (groups.Count < 2)
            {
                resultsConclusionLabel.Text = "Для однофакторного ANOVA требуется как минимум две непустые группы.\n";
                return;
            }

            var allValuesFlat = groups.SelectMany(g => g.Value).ToList();
            int N = allValuesFlat.Count;
            int k = groups.Count;
            if (N <= k)
            {
                resultsConclusionLabel.Text = "Недостаточно данных для анализа (общее число наблюдений <= числа групп).\n";
                return;
            }

            double grandMean = allValuesFlat.Average();
            double ssTotal = allValuesFlat.Sum(x => Math.Pow(x - grandMean, 2));
            double ssBetween = groups.Sum(g => g.Value.Count * Math.Pow(g.Value.Average() - grandMean, 2));
            double ssWithin = ssTotal - ssBetween;

            int dfBetween = k - 1;
            int dfWithin = N - k;

            if (dfBetween <= 0) { resultsConclusionLabel.Text = "df межгрупповая <= 0.\n"; return; }
            if (dfWithin <= 0) { resultsConclusionLabel.Text = "df внутригрупповая <= 0.\n"; return; }

            double msBetween = ssBetween / dfBetween;
            double msWithin = ssWithin / dfWithin;
            double F_statistic = (msWithin > 1e-10) ? msBetween / msWithin : double.PositiveInfinity;
            double pValue = 1.0;
            if (msWithin > 1e-10 && F_statistic != double.PositiveInfinity) pValue = 1.0 - FisherSnedecor.CDF(dfBetween, dfWithin, F_statistic);
            else if (F_statistic == double.PositiveInfinity) pValue = 0.0;

            DataTable anovaTable = new DataTable();
            anovaTable.Columns.Add("Источник", typeof(string));
            anovaTable.Columns.Add("SS", typeof(double));
            anovaTable.Columns.Add("df", typeof(int));
            anovaTable.Columns.Add("MS", typeof(double));
            anovaTable.Columns.Add("F", typeof(double));
            anovaTable.Columns.Add("P-value", typeof(double));

            anovaTable.Rows.Add("Межгрупповая", ssBetween, dfBetween, msBetween, F_statistic, pValue);
            anovaTable.Rows.Add("Внутригрупповая", ssWithin, dfWithin, msWithin, DBNull.Value, DBNull.Value);
            anovaTable.Rows.Add("Общая", ssTotal, N - 1, DBNull.Value, DBNull.Value, DBNull.Value);

            BindAndFormatAnovaTable(anovaTable, F_statistic, double.NaN, double.NaN);

            string conclusion = $"Однофакторный ANOVA\nУровень значимости alpha: {alpha}\n";
            conclusion += $"Фактор ({factorAColName}): {(pValue < alpha ? "Значим (p < alpha)." : "Не значим (p >= alpha).")}\n";
            resultsConclusionLabel.Text = conclusion;
        }


        private void PerformTwoWayAnova(double alpha, bool withRepeats)
        {
            factorAColName = factorAComboBox.SelectedItem.ToString();
            factorBColName = factorBComboBox.SelectedItem.ToString();
            valueColName = valueComboBox.SelectedItem.ToString();

            var data = new List<Tuple<string, string, double>>();
            int factorAIndex = dataGrid.Columns[factorAColName].Index;
            int factorBIndex = dataGrid.Columns[factorBColName].Index;
            int valueIndex = dataGrid.Columns[valueColName].Index;

            for (int rowIndex = 0; rowIndex < dataGrid.Rows.Count; rowIndex++)
            {
                DataGridViewRow row = dataGrid.Rows[rowIndex];
                if (row.IsNewRow) continue;
                var cellA = row.Cells[factorAIndex].Value;
                var cellB = row.Cells[factorBIndex].Value;
                var cellVal = row.Cells[valueIndex].Value;
                if (cellA == null || string.IsNullOrWhiteSpace(cellA.ToString()) ||
                    cellB == null || string.IsNullOrWhiteSpace(cellB.ToString()) ||
                    cellVal == null || string.IsNullOrWhiteSpace(cellVal.ToString())) continue;

                string factorA = cellA.ToString().Trim();
                string factorB = cellB.ToString().Trim();
                if (double.TryParse(cellVal.ToString().Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture, out double val))
                    data.Add(Tuple.Create(factorA, factorB, val));
                else
                    throw new FormatException($"Не удалось преобразовать '{cellVal}' в столбце '{valueColName}' (строка {rowIndex + 1}) в число.");
            }

            if (!data.Any()) { resultsConclusionLabel.Text = "Нет валидных данных для анализа.\n"; return; }

            var factorALevels = data.Select(t => t.Item1).Distinct().ToList();
            var factorBLevels = data.Select(t => t.Item2).Distinct().ToList();
            int a = factorALevels.Count;
            int b = factorBLevels.Count;
            int N = data.Count;

            if (a < 2 || b < 2) { resultsConclusionLabel.Text = "Требуется минимум 2 уровня для каждого фактора.\n"; return; }

            double grandTotal = data.Sum(t => t.Item3);
            double grandMean = grandTotal / N;
            double correctionTerm = Math.Pow(grandTotal, 2) / N;
            double ssTotal = data.Sum(t => Math.Pow(t.Item3, 2)) - correctionTerm;

            var sumsA = factorALevels.ToDictionary(lvl => lvl, lvl => data.Where(t => t.Item1 == lvl).Sum(t => t.Item3));
            var countsA = factorALevels.ToDictionary(lvl => lvl, lvl => data.Count(t => t.Item1 == lvl));
            if (countsA.Values.Any(c => c == 0)) { resultsConclusionLabel.Text = "Ошибка: Уровни фактора A без наблюдений.\n"; return; }
            double ssA = sumsA.Sum(kvp => Math.Pow(kvp.Value, 2) / countsA[kvp.Key]) - correctionTerm;

            var sumsB = factorBLevels.ToDictionary(lvl => lvl, lvl => data.Where(t => t.Item2 == lvl).Sum(t => t.Item3));
            var countsB = factorBLevels.ToDictionary(lvl => lvl, lvl => data.Count(t => t.Item2 == lvl));
            if (countsB.Values.Any(c => c == 0)) { resultsConclusionLabel.Text = "Ошибка: Уровни фактора B без наблюдений.\n"; return; }
            double ssB = sumsB.Sum(kvp => Math.Pow(kvp.Value, 2) / countsB[kvp.Key]) - correctionTerm;

            int dfA = a - 1;
            int dfB = b - 1;
            if (dfA <= 0 || dfB <= 0) { resultsConclusionLabel.Text = "df для факторов должны быть > 0.\n"; return; }
            double msA = ssA / dfA;
            double msB = ssB / dfB;

            double ssError, ssInteraction = 0;
            int dfError, dfInteraction = 0;
            double msError = 0, msInteraction = 0;
            double F_A = 0, F_B = 0, F_Interaction = 0;
            double pValue_A = 1.0, pValue_B = 1.0, pValue_Interaction = 1.0;

            var cellData = data.GroupBy(t => new { t.Item1, t.Item2 }).ToDictionary(g => g.Key, g => g.Select(t => t.Item3).ToList());
            int numberOfCells = cellData.Count;

            if (withRepeats)
            {
                if (!cellData.Values.Any(cellVals => cellVals.Count > 1))
                {
                    resultsConclusionLabel.Text = "Нет повторений в ячейках. Переключение на анализ без повторений.\n";
                    PerformTwoWayAnova(alpha, false); return;
                }

                double ssCellsSum = cellData.Sum(kvp => Math.Pow(kvp.Value.Sum(), 2) / kvp.Value.Count);
                ssInteraction = ssCellsSum - correctionTerm - ssA - ssB;
                ssError = ssTotal - ssA - ssB - ssInteraction;

                dfInteraction = (a - 1) * (b - 1);
                dfError = N - numberOfCells;

                if (dfInteraction <= 0) { msInteraction = 0; F_Interaction = 0; pValue_Interaction = 1.0; }
                else msInteraction = ssInteraction / dfInteraction;

                if (dfError <= 0) { resultsConclusionLabel.Text = "df для ошибки <= 0.\n"; return; }
                msError = ssError / dfError;

                F_A = (msError > 1e-10) ? msA / msError : double.PositiveInfinity;
                F_B = (msError > 1e-10) ? msB / msError : double.PositiveInfinity;
                F_Interaction = (msError > 1e-10 && dfInteraction > 0) ? msInteraction / msError : double.PositiveInfinity;

                if (dfError > 0)
                {
                    if (F_A == double.PositiveInfinity) pValue_A = 0.0; else pValue_A = 1.0 - FisherSnedecor.CDF(dfA, dfError, F_A);
                    if (F_B == double.PositiveInfinity) pValue_B = 0.0; else pValue_B = 1.0 - FisherSnedecor.CDF(dfB, dfError, F_B);
                    if (dfInteraction > 0) { if (F_Interaction == double.PositiveInfinity) pValue_Interaction = 0.0; else pValue_Interaction = 1.0 - FisherSnedecor.CDF(dfInteraction, dfError, F_Interaction); }
                }
            }
            else
            {
                if (N != a * b || numberOfCells != a * b)
                {
                    resultsConclusionLabel.Text = $"Ошибка: Для анализа без повторений ожидается {a * b} уникальных комбинаций факторов с одним значением. Найдено {N} наблюдений в {numberOfCells} комбинациях.\n";
                    return;
                }
                ssError = ssTotal - ssA - ssB;
                dfError = (a - 1) * (b - 1);

                if (dfError <= 0) { resultsConclusionLabel.Text = "df для остатка <= 0.\n"; return; }
                msError = ssError / dfError;

                F_A = (msError > 1e-10) ? msA / msError : double.PositiveInfinity;
                F_B = (msError > 1e-10) ? msB / msError : double.PositiveInfinity;

                if (dfError > 0)
                {
                    if (F_A == double.PositiveInfinity) pValue_A = 0.0; else pValue_A = 1.0 - FisherSnedecor.CDF(dfA, dfError, F_A);
                    if (F_B == double.PositiveInfinity) pValue_B = 0.0; else pValue_B = 1.0 - FisherSnedecor.CDF(dfB, dfError, F_B);
                }
            }

            DataTable anovaTable = new DataTable();
            anovaTable.Columns.Add("Источник", typeof(string));
            anovaTable.Columns.Add("SS", typeof(double));
            anovaTable.Columns.Add("df", typeof(int));
            anovaTable.Columns.Add("MS", typeof(double));
            anovaTable.Columns.Add("F", typeof(double));
            anovaTable.Columns.Add("P-value", typeof(double));

            anovaTable.Rows.Add($"Фактор A ({factorAColName})", ssA, dfA, msA, F_A, pValue_A);
            anovaTable.Rows.Add($"Фактор B ({factorBColName})", ssB, dfB, msB, F_B, pValue_B);

            if (withRepeats)
            {
                if (dfInteraction > 0) anovaTable.Rows.Add("Взаимодействие A×B", ssInteraction, dfInteraction, msInteraction, F_Interaction, pValue_Interaction);
                else anovaTable.Rows.Add("Взаимодействие A×B", ssInteraction, dfInteraction, msInteraction, DBNull.Value, DBNull.Value);
                anovaTable.Rows.Add("Ошибка", ssError, dfError, msError, DBNull.Value, DBNull.Value);
            }
            else
            {
                anovaTable.Rows.Add("Остаток (Взаимод.)", ssError, dfError, msError, DBNull.Value, DBNull.Value);
            }
            anovaTable.Rows.Add("Общая", ssTotal, N - 1, DBNull.Value, DBNull.Value, DBNull.Value);

            BindAndFormatAnovaTable(anovaTable, F_A, F_B, F_Interaction);

            string conclusion = $"Двухфакторный ANOVA {(withRepeats ? "с повторениями" : "без повторений")}\nУровень значимости alpha: {alpha}\n";
            if (dfA > 0) conclusion += $"Фактор A: {(pValue_A < alpha ? "Значим (p < alpha)." : "Не значим (p >= alpha).")}\n";
            if (dfB > 0) conclusion += $"Фактор B: {(pValue_B < alpha ? "Значим (p < alpha)." : "Не значим (p >= alpha).")}\n";
            if (withRepeats && dfInteraction > 0) conclusion += $"Взаимодействие A×B: {(pValue_Interaction < alpha ? "Значимо (p < alpha)." : "Не значимо (p >= alpha).")}\n";
            resultsConclusionLabel.Text = conclusion;
        }

        private void BindAndFormatAnovaTable(DataTable anovaTable, double fA, double fB, double fInteraction)
        {
            resultsDataGrid.DataSource = anovaTable;
            foreach (DataGridViewColumn column in resultsDataGrid.Columns)
            {
                if (column.ValueType == typeof(double))
                {
                    if (column.Name == "SS" || column.Name == "MS") column.DefaultCellStyle.Format = "F3";
                    if (column.Name == "F")
                    {
                        column.DefaultCellStyle.Format = "F3";
                        foreach (DataGridViewRow row in resultsDataGrid.Rows)
                        {
                            if (row.Cells["Источник"].Value.ToString().StartsWith("Фактор A") && double.IsInfinity(fA)) row.Cells["F"].Value = "Inf";
                            if (row.Cells["Источник"].Value.ToString().StartsWith("Фактор B") && double.IsInfinity(fB)) row.Cells["F"].Value = "Inf";
                            if (row.Cells["Источник"].Value.ToString().StartsWith("Взаимодействие") && double.IsInfinity(fInteraction)) row.Cells["F"].Value = "Inf";
                        }
                    }
                    if (column.Name == "P-value") column.DefaultCellStyle.Format = "F5";
                }
                if (column.ValueType == typeof(double) || column.ValueType == typeof(int))
                {
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            resultsDataGrid.Columns["Источник"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
    }
}