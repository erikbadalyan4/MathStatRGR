using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Controls;
using MathStatRGR.Utils;
using System.Text.RegularExpressions;
using System.Xml;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net.Http;
using MathStatRGR.Models;
using MathStatRGR.StatisticsCalculator;
using System.Windows.Forms.DataVisualization.Charting;

namespace MathStatRGR.Pages
{
    public partial class StatisticalEstimatesAndHypothesesControls : MetroUserControl
    {
        public StatisticalEstimatesAndHypothesesControls()
        {
            InitializeComponent();
            verShareThresholdComboBox.SelectedIndex = 0;
            chart1.Titles.Add("Гистограмма и нормальная кривая");
        }

        private void StatisticalEstimatesAndHypothesesControls_Load(object sender, EventArgs e)
        {

        }

        private void tableLabel_Click(object sender, EventArgs e)
        {

        }

        private void unrepeatableRadioButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void repetableRadioButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void excelButton_Click(object sender, EventArgs e)
        {
            try
            {
                var excelOpenFileDialog = ExcelTableReader.GetExcelOpenFileDialog();

                if (excelOpenFileDialog.ShowDialog() != DialogResult.OK) return;

                var dataTableCollection = ExcelTableReader.GetAllDataTables(excelOpenFileDialog.FileName);

                int sheetIndex;
                switch (dataTableCollection.Count)
                {
                    case 0:
                        MessageBox.Show("Файл Excel оказался пустой!");
                        return;
                    case 1:
                        sheetIndex = 0;
                        break;
                    default:
                        sheetIndex = ExcelTableReader.GetSheetIndex(dataTableCollection.Count);
                        break;
                }

                if (sheetIndex == -1) return;

                ExcelTableReader.LoadTableToDataGridView(this.table, dataTableCollection, sheetIndex, readableColumnsCount: 3);

            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"Неожиданная ошибка при заргузке данных из Excel: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void verAvgTextBox_Click(object sender, EventArgs e)
        {

        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel4_Click(object sender, EventArgs e)
        {

        }

        private void metroTextBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void metroTextBox1_Click_2(object sender, EventArgs e)
        {

        }

        private void metroLabel5_Click(object sender, EventArgs e)
        {

        }

        private void verShareThresholdComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void metroLabel6_Click(object sender, EventArgs e)
        {

        }

        private async void estimatesButton_Click(object sender, EventArgs e)
        {
            try
            {
                var intervals = GetIntervals();

                if (intervals == null) return;

                Dictionary<string, double> data = new Dictionary<string, double>();

                int i = 0;
                //Добавление первого интервала одним числом
                data.Add(intervals[i].x2.ToString(), intervals[i].ni);
                
                //Добавление интервалов, не являющихся первыми или последними
                for(i = 1; i <= intervals.Count - 2; i++) 
                {
                    data.Add(string.Join("-", intervals[i].x1, intervals[i].x2), intervals[i].ni);
                }

                //Добавление последнего интервала одним числом
                data.Add(intervals[i].x1.ToString(), intervals[i].ni);

                var minTableIntervalValue = intervals[0].x1;
                var maxTableIntervalValue1 = intervals[i].x1;
                var maxTableIntervalValue2 = intervals[i].x2;
                
                double verAvgDiff = 0;
                double theshold = 0;
                string thesholdConditionType = verShareThresholdComboBox.Text == "более чем" ? ">" : "<";
                double verShareDiff = 0;
                if (verAvgRadioButton.Checked)
                {
                    if (!double.TryParse(verAvgTextBox.Text, out verAvgDiff))
                    {
                        MessageBox.Show("Недопустимый тип данных для разницы средних");
                        return;
                    }
                    theshold = minTableIntervalValue;
                    verShareDiff = 0.05;
                }
                else
                {

                    if (!double.TryParse(verShareThresholdTextBox.Text, out theshold))
                    {
                        MessageBox.Show("Недопустимый тип данных для значения порога");
                        return;
                    }

                    if (theshold >= minTableIntervalValue && theshold <= maxTableIntervalValue2)
                    {
                        verAvgDiff = theshold;
                    }
                    else
                    {
                        MessageBox.Show($"Значение порога должно лежать между {minTableIntervalValue} и {maxTableIntervalValue2}");
                        return;
                    }


                    if (!double.TryParse(verShareTextBox.Text, out verShareDiff))
                    {
                        MessageBox.Show("Недопустимый тип данных для разницы долей");
                        return;
                    }
                }

                double bordersVer;
                if (!double.TryParse(bordersVerTextBox.Text, out bordersVer))
                {
                    MessageBox.Show("Недопустимый тип данных для вероятности вычисления границ");
                    return;
                }

                double interval1;
                if (string.IsNullOrWhiteSpace(bordersIntervalTextBox1.Text))
                {
                    interval1 = 0;
                }
                else if (!double.TryParse(bordersIntervalTextBox1.Text, out interval1))
                {
                    MessageBox.Show("Недопустимый тип данных для первого значения интервала вычисления границ");
                    return;
                }

                double interval2;
                if (string.IsNullOrWhiteSpace(bordersIntervalTextBox2.Text))
                {
                    interval2 = (int)(maxTableIntervalValue1 * bordersVer);
                }
                else if (!double.TryParse(bordersIntervalTextBox2.Text, out interval2))
                {
                    MessageBox.Show("Недопустимый тип данных для первого значения интервала вычисления границ");
                    return;
                }

                double capacityVer;
                if (!double.TryParse(capacityVerTextBox.Text, out capacityVer))
                {
                    MessageBox.Show("Недопустимый тип данных для вычисления вероятности объема выборки");
                    return;
                }
                double N;
                if (!double.TryParse(capacityNTextBox.Text, out N))
                {
                    MessageBox.Show("Недопустимый тип данных для вычисления общего числа (N)");
                    return;
                }



                var requestData = new
                {
                    data,
                    margin = verAvgDiff,
                    lover_limit = interval1,
                    upper_limit = interval2,
                    N,
                    confidence = capacityVer,
                    ver = bordersVer,
                    conditionType = thesholdConditionType,
                    theshold,
                    conditionMargin = verShareDiff
                };


                var jsonOptions = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                };
                string jsonData = JsonSerializer.Serialize(requestData, jsonOptions);

                using (HttpClient client = new HttpClient())
                {
                    string url = "http://67.227.250.194:8080/api/v1/five";
                    StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();

                        // Десериализация JSON с использованием JsonDocument
                        using (JsonDocument document = JsonDocument.Parse(responseBody))
                        {
                            resultVerLabel.Text = verAvgRadioButton.Checked ? 
                                document.RootElement.GetProperty("taskA").GetString() : 
                                document.RootElement.GetProperty("taskD").GetString();
                            var taskB = document.RootElement.GetProperty("taskB").GetString().Split('\n');
                            resultBorderLabel.Text = string.Join("\n", taskB[1], taskB[2]);

                            resultCapacityLabel.Text = document.RootElement.GetProperty("taskC").GetString();
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Ошибка: {response.StatusCode}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Неожиданная ошибка: {ex.Message}");
            }

        }

        private void resultCapacityLabel_Click(object sender, EventArgs e)
        {

        }

        private void hypothesesButton_Click(object sender, EventArgs e)
        {
            var intervals = GetIntervals();

            double a;
            if (!double.TryParse(alphaTextBox.Text, out a))
            {
                MessageBox.Show("Недопустимый тип данных для уровня значимости!");
                return;
            }

            var hypothesesCalculator = new HypothesesCalculator(intervals, a);

            resultPirsonLabel.Text = hypothesesCalculator.Pirson();
            resultKolmogorLabel.Text = hypothesesCalculator.Kolmogorov();
            hypothesesCalculator.SetupChart(chart1);
        }

        private void clearTableButton_Click(object sender, EventArgs e)
        {
            table.Rows.Clear();
        }

        private void table_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private List<Interval> GetIntervals()
        {
            Interval.n = 0;
            List<Interval> intervals = new List<Interval>();
            double x1, x2, intervalValue;
            int i = 0;

            string GetCellValue(int rowIndex, int colIndex) => table.Rows[rowIndex].Cells[colIndex].Value?.ToString();

            //Считывание данных с учетом, что X1 для первого интервала можно не записывать
            string cellValue = GetCellValue(i, 0);
            if (string.IsNullOrWhiteSpace(cellValue))
            {
                x1 = double.MinValue;
            }
            else if(!double.TryParse(cellValue, out x1)) 
            {
                MessageBox.Show($"Недопустимый тип данных для интервала на строке {i} в столбце X1." +
                    $"\nДля строки {i} X1 может быть не записан, либо должно быть число, другие типы данных не принимаются!");
                return null;
            }
            cellValue = GetCellValue(i, 1);
            if(!double.TryParse(cellValue, out x2)) 
            {
                MessageBox.Show($"Недопустимый тип данных для интервала на строке {i} в столбце X2." +
                    $"\nДля строки {i} X2 должен быть записан всегда!");
                return null;
            }

            if(x1 >= x2) 
            {
                MessageBox.Show($"Неправильно задан интервал на строке {i}, нельзя чтобы X1 >= X2");
                return null;
            }

            cellValue = GetCellValue(i, 2);
            if(!double.TryParse(cellValue, out intervalValue)) 
            {
                MessageBox.Show($"Недопустимый тип данных для значения интервала на строке {i}");
                return null;
            }

            intervals.Add(new Interval(x1, x2, intervalValue));

            //Считывание данных с учетом, что X1 и X2 должен быть записан для всех интервалов, кроме первого и последнего
            for (i = 1; i < table.Rows.Count - 2; i++)
            {
                cellValue = GetCellValue(i, 0);
                if (!double.TryParse(cellValue, out x1))
                {
                    MessageBox.Show($"Недопустимый тип данных для интервала на строке {i} в столбце X1." +
                        $"\nДля строки {i} X1 должен быть записан всегда!");
                    return null;
                }
                cellValue = GetCellValue(i, 1);
                if (!double.TryParse(cellValue, out x2))
                {
                    MessageBox.Show($"Недопустимый тип данных для интервала на строке {i} в столбце X2." +
                        $"\nДля строки {i} X2 должен быть записан всегда!");
                    return null;
                }

                if (x1 >= x2)
                {
                    MessageBox.Show($"Неправильно задан интервал на строке {i}, нельзя чтобы X1 >= X2");
                    return null;
                }

                cellValue = GetCellValue(i, 2);
                if (!double.TryParse(cellValue, out intervalValue))
                {
                    MessageBox.Show($"Недопустимый тип данных для значения интервала на строке {i}");
                    return null;
                }

                intervals.Add(new Interval(x1, x2, intervalValue));
            }

            //Считывание данных с учетом, что X2 для последнего интервала можно не записывать
            cellValue = GetCellValue(i, 0);
            if (!double.TryParse(cellValue, out x1))
            {
                MessageBox.Show($"Недопустимый тип данных для интервала на строке {i} в столбце X1." +
                    $"\nДля строки {i} X1 должен быть записан всегда!");
                return null;
            }
            cellValue = GetCellValue(i, 1);
            if (string.IsNullOrWhiteSpace(cellValue))
            {
                x2 = double.MaxValue;
            }
            else if (!double.TryParse(cellValue, out x2))
            {
                MessageBox.Show($"Недопустимый тип данных для интервала на строке {i} в столбце X2." +
                    $"\nДля строки {i} X2 может быть не записан, либо должно быть число, другие типы данных не принимаются!");
                return null;
            }

            if (x1 >= x2)
            {
                MessageBox.Show($"Неправильно задан интервал на строке {i}, нельзя чтобы X1 >= X2");
                return null;
            }

            cellValue = GetCellValue(i, 2);
            if (!double.TryParse(cellValue, out intervalValue))
            {
                MessageBox.Show($"Недопустимый тип данных для значения интервала на строке {i}");
                return null;
            }

            intervals.Add(new Interval(x1, x2, intervalValue));

            //Расчет длины интервала и подстраивание X1 первого интервала и X2 второго интервала 
            var intervalLen = Math.Abs(intervals[1].x2 - intervals[1].x1);

            var firstInterval = intervals.FirstOrDefault();
            firstInterval.x1 = firstInterval.x2 - intervalLen;
            firstInterval.SetIntervalMedium();

            var lastInterval = intervals.LastOrDefault();
            lastInterval.x2 = lastInterval.x1 + intervalLen;
            lastInterval.SetIntervalMedium();

            return intervals;
        }
    }
}
