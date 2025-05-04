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

namespace MathStatRGR.Pages
{
    public partial class StatisticalEstimatesAndHypothesesControls: MetroUserControl
    {
        public StatisticalEstimatesAndHypothesesControls()
        {
            InitializeComponent();
            
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

                ExcelTableReader.LoadTableToDataGridView(this.table, dataTableCollection, sheetIndex, readableColumnsCount: 2);

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
    }
}
