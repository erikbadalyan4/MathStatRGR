using MetroFramework.Controls;
using MetroFramework.Forms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MathStatRGR
{
    public partial class SheetSelectionForm : MetroForm
    {
        public int SelectedSheetIndex { get; private set; }

        private int _sheetsCount;

        public SheetSelectionForm(int sheetsCount)
        {
            _sheetsCount = sheetsCount;
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            this.Size = new System.Drawing.Size(300, 90);

            var label = new MetroLabel
            {
                Text = "Введите номер листа (начиная с 1):",
                FontSize = MetroFramework.MetroLabelSize.Medium,
                Location = new Point(17, 30),
                AutoSize = true
            };
            this.Controls.Add(label);

            var textBox = new MetroTextBox
            {
                Location = new Point(243, 30),
                Width = 40,
                Text = "1"
            };
            this.Controls.Add(textBox);

            var okButton = new MetroButton
            {
                Text = "ОК",
                Location = new Point(20, 55),
                Width = 80
            };
            okButton.Click += (s, e) =>
            {
                if (int.TryParse(textBox.Text, out int sheetNumber) && sheetNumber > 0)
                {
                    if (sheetNumber <= _sheetsCount)
                    {
                        SelectedSheetIndex = sheetNumber - 1;
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else 
                    {
                        MessageBox.Show("Введеный номер листа больше количества листов у файла.");
                    }
                }
                else
                {
                    MessageBox.Show("Введите корректный номер листа (целое число больше 0).");
                }
            };
            this.Controls.Add(okButton);

            var cancelButton = new MetroButton
            {
                Text = "Отмена",
                Location = new Point(120, 55),
                Width = 80
            };
            cancelButton.Click += (s, e) =>
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            };
            this.Controls.Add(cancelButton);
        }
    }
}