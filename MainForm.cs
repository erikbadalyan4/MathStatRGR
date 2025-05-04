using MetroFramework.Controls;
using MetroFramework.Forms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MathStatRGR
{
    public partial class MainForm : MetroForm
    {
        public MainForm()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            this.Size = new Size(1280, 960);
            this.Text = "MathStatRGR";

            var tabControl = new MetroTabControl
            {
                Dock = DockStyle.Fill
            };

            var variationSeriesTabPage = new TabPage() { Text = "Вариационные ряды" };

            var varSeriesControl = new VarSeriesControl();
            variationSeriesTabPage.Controls.Add(varSeriesControl);
            varSeriesControl.Dock = DockStyle.Fill;


            tabControl.TabPages.AddRange(new TabPage[]
                {
                    variationSeriesTabPage,
                    new TabPage()
                    {
                        Text = "Статистические оценки и гипотезы"
                    },
                    new TabPage()
                    {
                        Text = "Дисперсионный анализ"
                    }
                });

            this.Controls.Add(tabControl);
        }
    }
}