﻿using ExcelDataReader;
using MetroFramework.Controls;
using MetroFramework.Forms;
using System.Collections.Generic;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MathStatRGR.Pages;

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
            var formSize = new Size(1450, 720);
            this.Size = formSize;
            this.MaximumSize = formSize;
            this.MinimumSize = formSize;
            this.Text = "MathStatRGR";

            var tabControl = new MetroTabControl
            {
                Dock = DockStyle.Fill
            };

            tabControl.TabPages.AddRange(new TabPage[]
                {
                    new VarSeriesPage(),
                    new StatisticalEstimatesAndHypothesesPage(),
                    new AnovaPage()
                });

            this.Controls.Add(tabControl);
        }
    }
}