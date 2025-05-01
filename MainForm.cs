using MetroFramework.Controls;
using MetroFramework.Forms;
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

            //Добавление новык вкладок
            tabControl.TabPages.AddRange(new TabPage[]
                {
                    new TabPage()
                    {
                        Text = "Вариационные ряды"
                    },
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