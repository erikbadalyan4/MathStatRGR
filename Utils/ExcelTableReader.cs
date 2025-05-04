using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathStatRGR.Utils
{
    static class ExcelTableReader
    {
        public static void LoadTableToDataGridView(DataGridView dataGridView, 
            DataTableCollection dataTableCollection, 
            int sheetIndex,
            int? readableRowsCount = null,
            int? readableColumnsCount = null,
            int? notDoubleColumnIndex = null) 
        {
            var dataTable = dataTableCollection[sheetIndex];

            if (dataTable.Columns.Count == 0) MessageBox.Show($"В листе {sheetIndex + 1} не найдено данных для считывания!");

            dataGridView.Rows.Clear();

            readableColumnsCount = readableColumnsCount == null ? dataTable.Columns.Count : readableColumnsCount;
            readableRowsCount = readableRowsCount == null ? dataTable.Rows.Count : readableRowsCount;

            for (int j = dataGridView.ColumnCount; j < readableColumnsCount; j++)
            {
                dataGridView.Columns.Add($"Value{j}", $"Значение {j}");
            }

            for (int i = 0; i < readableRowsCount; i++)
            {
                var rowData = new List<string>();
                for (int j = 0; j < readableColumnsCount; j++)
                {
                    var value = dataTable.Rows[i][j];
                    if (value != null) 
                    {
                        if (j == notDoubleColumnIndex || double.TryParse(value.ToString(), out _))
                        {
                            rowData.Add(value.ToString());
                        }
                        else
                        {
                            MessageBox.Show($"Невозможно загрузить таблицу, ячейка [{i},{j}] содержит неправильный формат данных!");
                        }
                    }
                    else 
                    {
                        MessageBox.Show($"Невозможно загрузить таблицу, ячейка [{i},{j}] пустая!");
                        return;
                    }
                }

                dataGridView.Rows.Add(rowData.ToArray());
            }

        }

        public static OpenFileDialog GetExcelOpenFileDialog() => new OpenFileDialog
        {
            Filter = "Excel Files|*.xlsx;*.xls;*.xlsb",
            Title = "Выберите Excel-файл"
        };

        public static DataTableCollection GetAllDataTables(string fileName)
        {
            using (var stream = File.Open(fileName, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration
                    {
                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration { UseHeaderRow = false }
                    });

                    return result.Tables;
                }
            }
        }

        public static int GetSheetIndex(int sheetsCount)
        {
            using (var form = new SheetSelectionForm(sheetsCount))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    return form.SelectedSheetIndex;
                }
                return -1; 
            }
        }
    }
}
