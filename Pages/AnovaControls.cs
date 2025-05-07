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


        public AnovaControls()
        {
            InitializeComponent();
            InitializeAnovaTypes();
            UpdateColumnMappingControls();
            browseButton.Click += BrowseButton_Click;
            calculateButton.Click += CalculateButton_Click;
            anovaTypeComboBox.SelectedIndexChanged += AnovaTypeComboBox_SelectedIndexChanged;
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
            AnovaType selectedType = (AnovaType)anovaTypeComboBox.SelectedIndex;

            factorALabel.Visible = true;
            factorAComboBox.Visible = true;
            valueLabel.Visible = true;
            valueComboBox.Visible = true;

            switch (selectedType)
            {
                case AnovaType.OneWay:
                    factorBLabel.Visible = false;
                    factorBComboBox.Visible = false;
                    factorALabel.Text = "Столбец фактора:";
                    valueLabel.Text = "Столбец значений:";
                    break;
                case AnovaType.TwoWayNoRepeats:
                case AnovaType.TwoWayWithRepeats:
                    factorBLabel.Visible = true;
                    factorBComboBox.Visible = true;
                    factorALabel.Text = "Фактор A:";
                    factorBLabel.Text = "Фактор B:";
                    valueLabel.Text = "Столбец значений:";
                    break;
            }
            PopulateColumnComboBoxes();
        }

        private void PopulateColumnComboBoxes()
        {
            string selectedFactorA = factorAComboBox.SelectedItem as string;
            string selectedFactorB = factorBComboBox.SelectedItem as string;
            string selectedValue = valueComboBox.SelectedItem as string;

            factorAComboBox.Items.Clear();
            factorBComboBox.Items.Clear();
            valueComboBox.Items.Clear();

            if (dataGrid.Columns.Count > 0)
            {
                foreach (DataGridViewColumn col in dataGrid.Columns)
                {
                    factorAComboBox.Items.Add(col.HeaderText);
                    factorBComboBox.Items.Add(col.HeaderText);
                    valueComboBox.Items.Add(col.HeaderText);
                }

                if (selectedFactorA != null && factorAComboBox.Items.Contains(selectedFactorA))
                    factorAComboBox.SelectedItem = selectedFactorA;
                else if (factorAComboBox.Items.Count > 0)
                    factorAComboBox.SelectedIndex = 0;

                if (selectedFactorB != null && factorBComboBox.Items.Contains(selectedFactorB) && factorBComboBox.Visible)
                    factorBComboBox.SelectedItem = selectedFactorB;
                else if (factorBComboBox.Items.Count > 0 && factorBComboBox.Visible)
                    factorBComboBox.SelectedIndex = Math.Min(1, factorBComboBox.Items.Count - 1);

                if (selectedValue != null && valueComboBox.Items.Contains(selectedValue))
                    valueComboBox.SelectedItem = selectedValue;
                else if (valueComboBox.Items.Count > 0)
                    valueComboBox.SelectedIndex = Math.Min(dataGrid.Columns.Count - 1, valueComboBox.Items.Count - 1);


                if (factorAComboBox.Items.Count > 0 && factorBComboBox.Items.Count > 1 && factorAComboBox.SelectedIndex == factorBComboBox.SelectedIndex && factorBComboBox.Visible)
                {
                    factorBComboBox.SelectedIndex = (factorAComboBox.SelectedIndex + 1) % factorBComboBox.Items.Count;
                }
                if (valueComboBox.Items.Count > 0 && factorAComboBox.SelectedIndex == valueComboBox.SelectedIndex)
                {
                    valueComboBox.SelectedIndex = (factorAComboBox.SelectedIndex + 1) % valueComboBox.Items.Count;
                }
                if (valueComboBox.Items.Count > 0 && factorBComboBox.Visible && factorBComboBox.SelectedIndex == valueComboBox.SelectedIndex)
                {
                    valueComboBox.SelectedIndex = (factorBComboBox.SelectedIndex + 1) % valueComboBox.Items.Count;
                }
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
                    var dataTableCollection = ExcelTableReader.GetAllDataTables(filePath);
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

                if (dt.Rows.Count == 0 && dt.Columns.Count == 0)
                {
                    MessageBox.Show("Выбранный лист или файл не содержит данных.", "Нет данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                dataGrid.Columns.Clear();
                dataGrid.DataSource = dt;
                PopulateColumnComboBoxes();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке файла: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable LoadCsvOrTxtToDataTable(string filePath)
        {
            var dt = new DataTable();
            var lines = File.ReadAllLines(filePath);
            if (lines.Length == 0) return dt;

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
                dt.Columns.Add(header.Trim());
            }

            for (int i = 1; i < lines.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(lines[i])) continue;
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
                    {
                        fullRow[j] = string.Empty;
                    }
                    rows = fullRow;
                }
                else if (rows.Length > dt.Columns.Count)
                {
                    Array.Resize(ref rows, dt.Columns.Count);
                }
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

            if (dataGrid.Rows.Count == 0 || dataGrid.Columns.Count == 0)
            {
                MessageBox.Show("Нет данных для анализа.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            }
            catch (FormatException formatEx)
            {
                MessageBox.Show($"Ошибка формата данных: {formatEx.Message} Убедитесь, что числовые столбцы содержат только числа.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при расчете: {ex.Message}\n{ex.StackTrace}", "Критическая ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            foreach (DataGridViewRow row in dataGrid.Rows)
            {
                if (row.IsNewRow || row.Cells[colIndex].Value == null || string.IsNullOrWhiteSpace(row.Cells[colIndex].Value.ToString())) continue;
                if (double.TryParse(row.Cells[colIndex].Value.ToString().Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture, out double val))
                {
                    data.Add(val);
                }
                else
                {
                    throw new FormatException($"Не удалось преобразовать значение '{row.Cells[colIndex].Value}' в столбце '{columnName}' в число.");
                }
            }
            return data;
        }

        private List<string> GetFactorLevels(string columnName)
        {
            var levels = new List<string>();
            int colIndex = -1;
            for (int i = 0; i < dataGrid.Columns.Count; i++)
            {
                if (dataGrid.Columns[i].HeaderText == columnName)
                {
                    colIndex = i;
                    break;
                }
            }
            if (colIndex == -1) throw new ArgumentException($"Столбец фактора '{columnName}' не найден.");

            foreach (DataGridViewRow row in dataGrid.Rows)
            {
                if (row.IsNewRow || row.Cells[colIndex].Value == null || string.IsNullOrWhiteSpace(row.Cells[colIndex].Value.ToString())) continue;
                levels.Add(row.Cells[colIndex].Value.ToString().Trim());
            }
            return levels;
        }


        private void PerformOneWayAnova(double alpha)
        {
            if (factorAComboBox.SelectedItem == null || valueComboBox.SelectedItem == null)
            {
                MessageBox.Show("Выберите столбец фактора и столбец значений.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            factorAColName = factorAComboBox.SelectedItem.ToString();
            valueColName = valueComboBox.SelectedItem.ToString();

            var factorLevels = GetFactorLevels(factorAColName);
            var values = GetColumnData(valueColName);

            if (factorLevels.Count != values.Count)
            {
                MessageBox.Show("Количество уровней фактора не совпадает с количеством значений. Проверьте данные.", "Ошибка данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                resultsConclusionLabel.Text = "Ошибка: Длина списка факторов не совпадает с длиной списка значений.";
                return;
            }

            var groups = new Dictionary<string, List<double>>();
            for (int i = 0; i < factorLevels.Count; i++)
            {
                string level = factorLevels[i];
                if (!groups.ContainsKey(level))
                {
                    groups[level] = new List<double>();
                }
                groups[level].Add(values[i]);
            }

            groups = groups.Where(g => g.Value.Any()).ToDictionary(g => g.Key, g => g.Value);
            if (groups.Count < 2)
            {
                resultsConclusionLabel.Text = "Для однофакторного ANOVA требуется как минимум две группы с данными.\n";
                return;
            }

            var allValuesFlat = groups.SelectMany(g => g.Value).ToList();
            int N = allValuesFlat.Count;
            int k = groups.Count;
            if (N == 0 || k == 0 || N <= k)
            {
                resultsConclusionLabel.Text = "Недостаточно данных или групп для анализа.\n";
                return;
            }

            double grandMean = allValuesFlat.Average();
            double ssTotal = allValuesFlat.Sum(x => Math.Pow(x - grandMean, 2));

            double ssBetween = groups.Sum(group =>
            {
                if (!group.Value.Any()) return 0;
                double groupMean = group.Value.Average();
                return group.Value.Count * Math.Pow(groupMean - grandMean, 2);
            });

            double ssWithin = ssTotal - ssBetween;

            int dfBetween = k - 1;
            int dfWithin = N - k;

            if (dfBetween <= 0 || dfWithin <= 0)
            {
                resultsConclusionLabel.Text = "Недостаточно степеней свободы для расчета.\n";
                return;
            }

            double msBetween = ssBetween / dfBetween;
            double msWithin = ssWithin / dfWithin;
            double F_statistic = (msWithin > 0) ? msBetween / msWithin : double.PositiveInfinity;
            double pValue = 1.0;
            if (msWithin > 0 && F_statistic != double.PositiveInfinity) pValue = 1.0 - FisherSnedecor.CDF(dfBetween, dfWithin, F_statistic);
            else if (F_statistic == double.PositiveInfinity) pValue = 0.0;

            DataTable anovaTable = new DataTable();
            anovaTable.Columns.Add("Источник", typeof(string));
            anovaTable.Columns.Add("SS", typeof(double));
            anovaTable.Columns.Add("df", typeof(int));
            anovaTable.Columns.Add("MS", typeof(double));
            anovaTable.Columns.Add("F", typeof(double));
            anovaTable.Columns.Add("P-value", typeof(double));

            anovaTable.Rows.Add("Межгрупповая", Math.Round(ssBetween, 3), dfBetween, Math.Round(msBetween, 3), Math.Round(F_statistic, 3), Math.Round(pValue, 5));
            anovaTable.Rows.Add("Внутригрупповая", Math.Round(ssWithin, 3), dfWithin, Math.Round(msWithin, 3), DBNull.Value, DBNull.Value);
            anovaTable.Rows.Add("Общая", Math.Round(ssTotal, 3), N - 1, DBNull.Value, DBNull.Value, DBNull.Value);

            resultsDataGrid.DataSource = anovaTable;
            foreach (DataGridViewColumn column in resultsDataGrid.Columns)
            {
                if (column.ValueType == typeof(double))
                {
                    column.DefaultCellStyle.Format = "F3";
                }
                if (column.Name == "P-value")
                {
                    column.DefaultCellStyle.Format = "F5";
                }
            }

            string conclusion = $"Однофакторный ANOVA\nУровень значимости alpha: {alpha}\n";
            if (pValue < alpha)
                conclusion += "Вывод: Отклоняем нулевую гипотезу (p < alpha). Есть статистически значимые различия между группами.\n";
            else
                conclusion += "Вывод: Не отклоняем нулевую гипотезу (p >= alpha). Нет статистически значимых различий между группами.\n";

            resultsConclusionLabel.Text = conclusion;
        }


        private void PerformTwoWayAnova(double alpha, bool withRepeats)
        {
            if (factorAComboBox.SelectedItem == null || factorBComboBox.SelectedItem == null || valueComboBox.SelectedItem == null)
            {
                MessageBox.Show("Выберите столбцы для Фактора A, Фактора B и Значений.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            factorAColName = factorAComboBox.SelectedItem.ToString();
            factorBColName = factorBComboBox.SelectedItem.ToString();
            valueColName = valueComboBox.SelectedItem.ToString();

            if (factorAColName == factorBColName || factorAColName == valueColName || factorBColName == valueColName)
            {
                MessageBox.Show("Столбцы для факторов и значений должны быть уникальными.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var data = new List<Tuple<string, string, double>>();
            int factorAIndex = dataGrid.Columns[factorAColName].Index;
            int factorBIndex = dataGrid.Columns[factorBColName].Index;
            int valueIndex = dataGrid.Columns[valueColName].Index;

            foreach (DataGridViewRow row in dataGrid.Rows)
            {
                if (row.IsNewRow) continue;
                if (row.Cells[factorAIndex].Value == null || string.IsNullOrWhiteSpace(row.Cells[factorAIndex].Value.ToString()) ||
                    row.Cells[factorBIndex].Value == null || string.IsNullOrWhiteSpace(row.Cells[factorBIndex].Value.ToString()) ||
                    row.Cells[valueIndex].Value == null || string.IsNullOrWhiteSpace(row.Cells[valueIndex].Value.ToString()))
                {
                    continue;
                }

                string factorA = row.Cells[factorAIndex].Value.ToString().Trim();
                string factorB = row.Cells[factorBIndex].Value.ToString().Trim();
                if (double.TryParse(row.Cells[valueIndex].Value.ToString().Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture, out double val))
                {
                    data.Add(Tuple.Create(factorA, factorB, val));
                }
                else
                {
                    throw new FormatException($"Не удалось преобразовать значение '{row.Cells[valueIndex].Value}' в столбце '{valueColName}' в число для строки с факторами '{factorA}', '{factorB}'.");
                }
            }

            if (!data.Any())
            {
                resultsConclusionLabel.Text = "Нет данных для анализа после фильтрации пустых строк/значений.\n";
                return;
            }

            var factorALevels = data.Select(t => t.Item1).Distinct().ToList();
            var factorBLevels = data.Select(t => t.Item2).Distinct().ToList();
            int a_levels_count = factorALevels.Count;
            int b_levels_count = factorBLevels.Count;
            int N = data.Count;

            if (a_levels_count < 2 || b_levels_count < 2)
            {
                resultsConclusionLabel.Text = "Для двухфакторного ANOVA требуется как минимум два уровня для каждого фактора.\n";
                return;
            }

            double grandTotal = data.Sum(t => t.Item3);
            double grandMean = grandTotal / N;
            double ssTotal = data.Sum(t => Math.Pow(t.Item3 - grandMean, 2));

            var sumsA = factorALevels.ToDictionary(
                levelA => levelA,
                levelA => data.Where(t => t.Item1 == levelA).Sum(t => t.Item3)
            );
            var countsA = factorALevels.ToDictionary(
                levelA => levelA,
                levelA => data.Count(t => t.Item1 == levelA)
            );
            if (countsA.Values.Any(c => c == 0)) { resultsConclusionLabel.Text = "Ошибка: есть уровни Фактора А без наблюдений.\n"; return; }
            double ssA = sumsA.Sum(kvp => Math.Pow(kvp.Value, 2) / countsA[kvp.Key]) - Math.Pow(grandTotal, 2) / N;

            var sumsB = factorBLevels.ToDictionary(
                levelB => levelB,
                levelB => data.Where(t => t.Item2 == levelB).Sum(t => t.Item3)
            );
            var countsB = factorBLevels.ToDictionary(
                levelB => levelB,
                levelB => data.Count(t => t.Item2 == levelB)
            );
            if (countsB.Values.Any(c => c == 0)) { resultsConclusionLabel.Text = "Ошибка: есть уровни Фактора B без наблюдений.\n"; return; }
            double ssB = sumsB.Sum(kvp => Math.Pow(kvp.Value, 2) / countsB[kvp.Key]) - Math.Pow(grandTotal, 2) / N;

            int dfA = a_levels_count - 1;
            int dfB = b_levels_count - 1;
            double msA = (dfA > 0) ? ssA / dfA : 0;
            double msB = (dfB > 0) ? ssB / dfB : 0;

            double ssError, ssInteraction = 0;
            int dfError, dfInteraction = 0;
            double msError, msInteraction = 0;
            double F_A, F_B, F_Interaction = 0;
            double pValue_A = 1.0, pValue_B = 1.0, pValue_Interaction = 1.0;


            if (withRepeats)
            {
                var cellData = data.GroupBy(t => new { FactorA = t.Item1, FactorB = t.Item2 })
                                   .ToDictionary(g => g.Key, g => g.Select(t => t.Item3).ToList());

                if (!cellData.Values.Any(cellVals => cellVals.Count > 1))
                {
                    resultsConclusionLabel.Text = "Для анализа с повторениями необходимо, чтобы хотя бы одна комбинация факторов имела более одного наблюдения. Переключаюсь на анализ без повторений.\n";
                    PerformTwoWayAnova(alpha, false);
                    return;
                }

                double ssCellsSum = 0;
                foreach (var cellKey in cellData.Keys)
                {
                    if (cellData[cellKey].Any())
                    {
                        double cellSum = cellData[cellKey].Sum();
                        ssCellsSum += Math.Pow(cellSum, 2) / cellData[cellKey].Count;
                    }
                }

                ssInteraction = ssCellsSum - Math.Pow(grandTotal, 2) / N - ssA - ssB;
                ssError = ssTotal - ssA - ssB - ssInteraction;

                dfInteraction = (a_levels_count - 1) * (b_levels_count - 1);
                dfError = N - (a_levels_count * b_levels_count);
                if (cellData.Count < a_levels_count * b_levels_count)
                {
                    dfError = N - cellData.Count;
                }


                if (dfError <= 0)
                {
                    resultsConclusionLabel.Text = "Недостаточно степеней свободы для ошибки (dfError <= 0).\n";
                    return;
                }
                msError = ssError / dfError;

                if (dfInteraction > 0) msInteraction = ssInteraction / dfInteraction; else msInteraction = 0;

                F_A = (msError > 0 && dfA > 0) ? msA / msError : double.PositiveInfinity;
                F_B = (msError > 0 && dfB > 0) ? msB / msError : double.PositiveInfinity;
                F_Interaction = (msError > 0 && dfInteraction > 0) ? msInteraction / msError : double.PositiveInfinity;

                if (dfA > 0 && dfError > 0) { if (F_A == double.PositiveInfinity) pValue_A = 0.0; else pValue_A = 1.0 - FisherSnedecor.CDF(dfA, dfError, F_A); }
                if (dfB > 0 && dfError > 0) { if (F_B == double.PositiveInfinity) pValue_B = 0.0; else pValue_B = 1.0 - FisherSnedecor.CDF(dfB, dfError, F_B); }
                if (dfInteraction > 0 && dfError > 0) { if (F_Interaction == double.PositiveInfinity) pValue_Interaction = 0.0; else pValue_Interaction = 1.0 - FisherSnedecor.CDF(dfInteraction, dfError, F_Interaction); }

            }
            else
            {
                if (N != a_levels_count * b_levels_count)
                {
                    resultsConclusionLabel.Text = $"Для двухфакторного ANOVA без повторений количество наблюдений ({N}) должно быть равно произведению уровней факторов ({a_levels_count}*{b_levels_count}={a_levels_count * b_levels_count}).\n";
                    return;
                }
                ssError = ssTotal - ssA - ssB;
                dfError = (a_levels_count - 1) * (b_levels_count - 1);

                if (dfError <= 0)
                {
                    resultsConclusionLabel.Text = "Недостаточно степеней свободы для остатка/взаимодействия (dfError <= 0).\n";
                    return;
                }
                msError = ssError / dfError;

                F_A = (msError > 0 && dfA > 0) ? msA / msError : double.PositiveInfinity;
                F_B = (msError > 0 && dfB > 0) ? msB / msError : double.PositiveInfinity;

                if (dfA > 0 && dfError > 0) { if (F_A == double.PositiveInfinity) pValue_A = 0.0; else pValue_A = 1.0 - FisherSnedecor.CDF(dfA, dfError, F_A); }
                if (dfB > 0 && dfError > 0) { if (F_B == double.PositiveInfinity) pValue_B = 0.0; else pValue_B = 1.0 - FisherSnedecor.CDF(dfB, dfError, F_B); }
            }

            DataTable anovaTable = new DataTable();
            anovaTable.Columns.Add("Источник", typeof(string));
            anovaTable.Columns.Add("SS", typeof(double));
            anovaTable.Columns.Add("df", typeof(int));
            anovaTable.Columns.Add("MS", typeof(double));
            anovaTable.Columns.Add("F", typeof(double));
            anovaTable.Columns.Add("P-value", typeof(double));

            anovaTable.Rows.Add($"Фактор A ({factorAColName})", Math.Round(ssA, 3), dfA, Math.Round(msA, 3), Math.Round(F_A, 3), Math.Round(pValue_A, 5));
            anovaTable.Rows.Add($"Фактор B ({factorBColName})", Math.Round(ssB, 3), dfB, Math.Round(msB, 3), Math.Round(F_B, 3), Math.Round(pValue_B, 5));

            string errorTermGridName = "Ошибка";
            if (withRepeats)
            {
                if (dfInteraction > 0)
                    anovaTable.Rows.Add("Взаимодействие A×B", Math.Round(ssInteraction, 3), dfInteraction, Math.Round(msInteraction, 3), Math.Round(F_Interaction, 3), Math.Round(pValue_Interaction, 5));
                else
                    anovaTable.Rows.Add("Взаимодействие A×B", Math.Round(ssInteraction, 3), dfInteraction, Math.Round(msInteraction, 3), DBNull.Value, DBNull.Value);

                anovaTable.Rows.Add("Ошибка", Math.Round(ssError, 3), dfError, Math.Round(msError, 3), DBNull.Value, DBNull.Value);
            }
            else
            {
                errorTermGridName = "Остаток (Взаимод.)";
                anovaTable.Rows.Add(errorTermGridName, Math.Round(ssError, 3), dfError, Math.Round(msError, 3), DBNull.Value, DBNull.Value);
            }

            anovaTable.Rows.Add("Общая", Math.Round(ssTotal, 3), N - 1, DBNull.Value, DBNull.Value, DBNull.Value);

            resultsDataGrid.DataSource = anovaTable;
            foreach (DataGridViewColumn column in resultsDataGrid.Columns)
            {
                if (column.ValueType == typeof(double))
                {
                    column.DefaultCellStyle.Format = "F3";
                }
                if (column.Name == "P-value")
                {
                    column.DefaultCellStyle.Format = "F5";
                }
            }


            string conclusion = $"Двухфакторный ANOVA {(withRepeats ? "с повторениями" : "без повторений")}\nУровень значимости alpha: {alpha}\n";
            if (dfA > 0) conclusion += $"Фактор A: {(pValue_A < alpha ? "Значим (p < alpha)." : "Не значим (p >= alpha).")}\n";
            if (dfB > 0) conclusion += $"Фактор B: {(pValue_B < alpha ? "Значим (p < alpha)." : "Не значим (p >= alpha).")}\n";

            if (withRepeats && dfInteraction > 0)
            {
                conclusion += $"Взаимодействие A×B: {(pValue_Interaction < alpha ? "Значимо (p < alpha)." : "Не значимо (p >= alpha).")}\n";
            }
            resultsConclusionLabel.Text = conclusion;
        }
    }
}