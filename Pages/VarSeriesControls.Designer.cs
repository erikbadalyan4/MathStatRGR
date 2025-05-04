using MetroFramework.Controls;
using System.Windows.Forms;

namespace MathStatRGR.Pages
{
    partial class VarSeriesControls
    {
        private System.ComponentModel.IContainer components = null;

        #region Код, автоматически созданный конструктором компонентов

        private void InitializeComponent()
        {
            this.mainTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.inputPanel = new MetroFramework.Controls.MetroPanel();
            this.inputFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.typeLabel = new MetroFramework.Controls.MetroLabel();
            this.discreteRadio = new MetroFramework.Controls.MetroRadioButton();
            this.continuousRadio = new MetroFramework.Controls.MetroRadioButton();
            this.spacerLabel1 = new MetroFramework.Controls.MetroLabel();
            this.browseButton = new MetroFramework.Controls.MetroButton();
            this.dataLabel = new MetroFramework.Controls.MetroLabel();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.calculateButton = new MetroFramework.Controls.MetroButton();
            this.spacerLabel2 = new MetroFramework.Controls.MetroLabel();
            this.spacerLabel3 = new MetroFramework.Controls.MetroLabel();
            this.showChartButton = new MetroFramework.Controls.MetroButton();
            this.resultsPanel = new MetroFramework.Controls.MetroPanel();
            this.momentsGroupBox = new System.Windows.Forms.GroupBox();
            this.momentsTable = new System.Windows.Forms.TableLayoutPanel();
            this.initialMoment1Label = new MetroFramework.Controls.MetroLabel();
            this.centralMoment1Label = new MetroFramework.Controls.MetroLabel();
            this.initialMoment2Label = new MetroFramework.Controls.MetroLabel();
            this.centralMoment2Label = new MetroFramework.Controls.MetroLabel();
            this.initialMoment3Label = new MetroFramework.Controls.MetroLabel();
            this.centralMoment3Label = new MetroFramework.Controls.MetroLabel();
            this.initialMoment4Label = new MetroFramework.Controls.MetroLabel();
            this.centralMoment4Label = new MetroFramework.Controls.MetroLabel();
            this.statisticsGroupBox = new System.Windows.Forms.GroupBox();
            this.statsTable = new System.Windows.Forms.TableLayoutPanel();
            this.meanLabel = new MetroFramework.Controls.MetroLabel();
            this.medianLabel = new MetroFramework.Controls.MetroLabel();
            this.modeLabel = new MetroFramework.Controls.MetroLabel();
            this.meanAbsoluteDeviationLabel = new MetroFramework.Controls.MetroLabel();
            this.sampleVarianceLabel = new MetroFramework.Controls.MetroLabel();
            this.standardDeviationLabel = new MetroFramework.Controls.MetroLabel();
            this.coefficientOfVariationLabel = new MetroFramework.Controls.MetroLabel();
            this.skewnessLabel = new MetroFramework.Controls.MetroLabel();
            this.kurtosisLabel = new MetroFramework.Controls.MetroLabel();
            this.mainTableLayout.SuspendLayout();
            this.inputPanel.SuspendLayout();
            this.inputFlowPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.resultsPanel.SuspendLayout();
            this.momentsGroupBox.SuspendLayout();
            this.momentsTable.SuspendLayout();
            this.statisticsGroupBox.SuspendLayout();
            this.statsTable.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainTableLayout
            // 
            this.mainTableLayout.BackColor = System.Drawing.Color.Transparent;
            this.mainTableLayout.ColumnCount = 2;
            this.mainTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.mainTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.mainTableLayout.Controls.Add(this.inputPanel, 0, 0);
            this.mainTableLayout.Controls.Add(this.resultsPanel, 1, 0);
            this.mainTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTableLayout.Location = new System.Drawing.Point(0, 0);
            this.mainTableLayout.Margin = new System.Windows.Forms.Padding(4);
            this.mainTableLayout.Name = "mainTableLayout";
            this.mainTableLayout.Padding = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.mainTableLayout.RowCount = 1;
            this.mainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTableLayout.Size = new System.Drawing.Size(1333, 738);
            this.mainTableLayout.TabIndex = 0;
            // 
            // inputPanel
            // 
            this.inputPanel.AutoScroll = true;
            this.inputPanel.Controls.Add(this.inputFlowPanel);
            this.inputPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inputPanel.HorizontalScrollbar = true;
            this.inputPanel.HorizontalScrollbarBarColor = true;
            this.inputPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.inputPanel.HorizontalScrollbarSize = 12;
            this.inputPanel.Location = new System.Drawing.Point(17, 16);
            this.inputPanel.Margin = new System.Windows.Forms.Padding(4);
            this.inputPanel.Name = "inputPanel";
            this.inputPanel.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.inputPanel.Size = new System.Drawing.Size(514, 706);
            this.inputPanel.TabIndex = 0;
            this.inputPanel.VerticalScrollbar = true;
            this.inputPanel.VerticalScrollbarBarColor = true;
            this.inputPanel.VerticalScrollbarHighlightOnWheel = false;
            this.inputPanel.VerticalScrollbarSize = 13;
            // 
            // inputFlowPanel
            // 
            this.inputFlowPanel.AutoSize = true;
            this.inputFlowPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.inputFlowPanel.BackColor = System.Drawing.Color.Transparent;
            this.inputFlowPanel.Controls.Add(this.typeLabel);
            this.inputFlowPanel.Controls.Add(this.discreteRadio);
            this.inputFlowPanel.Controls.Add(this.continuousRadio);
            this.inputFlowPanel.Controls.Add(this.spacerLabel1);
            this.inputFlowPanel.Controls.Add(this.browseButton);
            this.inputFlowPanel.Controls.Add(this.dataLabel);
            this.inputFlowPanel.Controls.Add(this.dataGrid);
            this.inputFlowPanel.Controls.Add(this.calculateButton);
            this.inputFlowPanel.Controls.Add(this.spacerLabel2);
            this.inputFlowPanel.Controls.Add(this.spacerLabel3);
            this.inputFlowPanel.Controls.Add(this.showChartButton);
            this.inputFlowPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.inputFlowPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.inputFlowPanel.Location = new System.Drawing.Point(7, 6);
            this.inputFlowPanel.Margin = new System.Windows.Forms.Padding(4);
            this.inputFlowPanel.Name = "inputFlowPanel";
            this.inputFlowPanel.Size = new System.Drawing.Size(500, 674);
            this.inputFlowPanel.TabIndex = 2;
            this.inputFlowPanel.WrapContents = false;
            // 
            // typeLabel
            // 
            this.typeLabel.AutoSize = true;
            this.typeLabel.Location = new System.Drawing.Point(4, 12);
            this.typeLabel.Margin = new System.Windows.Forms.Padding(4, 12, 4, 6);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(172, 20);
            this.typeLabel.TabIndex = 0;
            this.typeLabel.Text = "Тип вариационного ряда:";
            // 
            // discreteRadio
            // 
            this.discreteRadio.AutoSize = true;
            this.discreteRadio.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.discreteRadio.FontWeight = MetroFramework.MetroCheckBoxWeight.Light;
            this.discreteRadio.Location = new System.Drawing.Point(20, 42);
            this.discreteRadio.Margin = new System.Windows.Forms.Padding(20, 4, 4, 4);
            this.discreteRadio.Name = "discreteRadio";
            this.discreteRadio.Size = new System.Drawing.Size(132, 20);
            this.discreteRadio.TabIndex = 1;
            this.discreteRadio.Text = "Дискретный ряд";
            this.discreteRadio.UseSelectable = true;
            this.discreteRadio.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // continuousRadio
            // 
            this.continuousRadio.AutoSize = true;
            this.continuousRadio.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.continuousRadio.FontWeight = MetroFramework.MetroCheckBoxWeight.Light;
            this.continuousRadio.Location = new System.Drawing.Point(20, 70);
            this.continuousRadio.Margin = new System.Windows.Forms.Padding(20, 4, 4, 4);
            this.continuousRadio.Name = "continuousRadio";
            this.continuousRadio.Size = new System.Drawing.Size(145, 20);
            this.continuousRadio.TabIndex = 2;
            this.continuousRadio.Text = "Непрерывный ряд";
            this.continuousRadio.UseSelectable = true;
            this.continuousRadio.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // spacerLabel1
            // 
            this.spacerLabel1.AutoSize = true;
            this.spacerLabel1.FontSize = MetroFramework.MetroLabelSize.Small;
            this.spacerLabel1.Location = new System.Drawing.Point(4, 98);
            this.spacerLabel1.Margin = new System.Windows.Forms.Padding(4);
            this.spacerLabel1.Name = "spacerLabel1";
            this.spacerLabel1.Size = new System.Drawing.Size(12, 17);
            this.spacerLabel1.TabIndex = 12;
            this.spacerLabel1.Text = " ";
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(4, 125);
            this.browseButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 4);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(493, 37);
            this.browseButton.TabIndex = 3;
            this.browseButton.Text = "Выбрать файл...";
            this.browseButton.UseSelectable = true;
            this.browseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // dataLabel
            // 
            this.dataLabel.AutoSize = true;
            this.dataLabel.Location = new System.Drawing.Point(4, 178);
            this.dataLabel.Margin = new System.Windows.Forms.Padding(4, 12, 4, 6);
            this.dataLabel.Name = "dataLabel";
            this.dataLabel.Size = new System.Drawing.Size(63, 20);
            this.dataLabel.TabIndex = 4;
            this.dataLabel.Text = "Данные:";
            // 
            // dataGrid
            // 
            this.dataGrid.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.GridColor = System.Drawing.Color.LightGray;
            this.dataGrid.Location = new System.Drawing.Point(4, 208);
            this.dataGrid.Margin = new System.Windows.Forms.Padding(4);
            this.dataGrid.MinimumSize = new System.Drawing.Size(400, 185);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.RowHeadersVisible = false;
            this.dataGrid.RowHeadersWidth = 51;
            this.dataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGrid.Size = new System.Drawing.Size(493, 308);
            this.dataGrid.TabIndex = 5;
            // 
            // calculateButton
            // 
            this.calculateButton.Location = new System.Drawing.Point(4, 526);
            this.calculateButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 0);
            this.calculateButton.Name = "calculateButton";
            this.calculateButton.Size = new System.Drawing.Size(493, 43);
            this.calculateButton.TabIndex = 6;
            this.calculateButton.Text = "Рассчитать статистику";
            this.calculateButton.UseSelectable = true;
            this.calculateButton.Click += new System.EventHandler(this.CalculateButton_Click);
            // 
            // spacerLabel2
            // 
            this.spacerLabel2.AutoSize = true;
            this.spacerLabel2.FontSize = MetroFramework.MetroLabelSize.Small;
            this.spacerLabel2.Location = new System.Drawing.Point(4, 573);
            this.spacerLabel2.Margin = new System.Windows.Forms.Padding(4);
            this.spacerLabel2.Name = "spacerLabel2";
            this.spacerLabel2.Size = new System.Drawing.Size(12, 17);
            this.spacerLabel2.TabIndex = 13;
            this.spacerLabel2.Text = " ";
            // 
            // spacerLabel3
            // 
            this.spacerLabel3.AutoSize = true;
            this.spacerLabel3.FontSize = MetroFramework.MetroLabelSize.Small;
            this.spacerLabel3.Location = new System.Drawing.Point(4, 598);
            this.spacerLabel3.Margin = new System.Windows.Forms.Padding(4);
            this.spacerLabel3.Name = "spacerLabel3";
            this.spacerLabel3.Size = new System.Drawing.Size(12, 17);
            this.spacerLabel3.TabIndex = 14;
            this.spacerLabel3.Text = " ";
            // 
            // showChartButton
            // 
            this.showChartButton.Location = new System.Drawing.Point(4, 619);
            this.showChartButton.Margin = new System.Windows.Forms.Padding(4, 0, 4, 12);
            this.showChartButton.Name = "showChartButton";
            this.showChartButton.Size = new System.Drawing.Size(493, 43);
            this.showChartButton.TabIndex = 7;
            this.showChartButton.Text = "Показать график";
            this.showChartButton.UseSelectable = true;
            this.showChartButton.Click += new System.EventHandler(this.ShowChartButton_Click);
            // 
            // resultsPanel
            // 
            this.resultsPanel.AutoScroll = true;
            this.resultsPanel.Controls.Add(this.momentsGroupBox);
            this.resultsPanel.Controls.Add(this.statisticsGroupBox);
            this.resultsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultsPanel.HorizontalScrollbar = true;
            this.resultsPanel.HorizontalScrollbarBarColor = true;
            this.resultsPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.resultsPanel.HorizontalScrollbarSize = 12;
            this.resultsPanel.Location = new System.Drawing.Point(539, 16);
            this.resultsPanel.Margin = new System.Windows.Forms.Padding(4);
            this.resultsPanel.Name = "resultsPanel";
            this.resultsPanel.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.resultsPanel.Size = new System.Drawing.Size(777, 706);
            this.resultsPanel.TabIndex = 1;
            this.resultsPanel.VerticalScrollbar = true;
            this.resultsPanel.VerticalScrollbarBarColor = true;
            this.resultsPanel.VerticalScrollbarHighlightOnWheel = false;
            this.resultsPanel.VerticalScrollbarSize = 13;
            // 
            // momentsGroupBox
            // 
            this.momentsGroupBox.AutoSize = true;
            this.momentsGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.momentsGroupBox.Controls.Add(this.momentsTable);
            this.momentsGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.momentsGroupBox.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.momentsGroupBox.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.momentsGroupBox.Location = new System.Drawing.Point(7, 172);
            this.momentsGroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.momentsGroupBox.Name = "momentsGroupBox";
            this.momentsGroupBox.Padding = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.momentsGroupBox.Size = new System.Drawing.Size(763, 106);
            this.momentsGroupBox.TabIndex = 3;
            this.momentsGroupBox.TabStop = false;
            this.momentsGroupBox.Text = "Моменты распределения";
            // 
            // momentsTable
            // 
            this.momentsTable.AutoSize = true;
            this.momentsTable.BackColor = System.Drawing.Color.Transparent;
            this.momentsTable.ColumnCount = 2;
            this.momentsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.momentsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.momentsTable.Controls.Add(this.initialMoment1Label, 0, 0);
            this.momentsTable.Controls.Add(this.centralMoment1Label, 1, 0);
            this.momentsTable.Controls.Add(this.initialMoment2Label, 0, 1);
            this.momentsTable.Controls.Add(this.centralMoment2Label, 1, 1);
            this.momentsTable.Controls.Add(this.initialMoment3Label, 0, 2);
            this.momentsTable.Controls.Add(this.centralMoment3Label, 1, 2);
            this.momentsTable.Controls.Add(this.initialMoment4Label, 0, 3);
            this.momentsTable.Controls.Add(this.centralMoment4Label, 1, 3);
            this.momentsTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.momentsTable.Location = new System.Drawing.Point(13, 34);
            this.momentsTable.Margin = new System.Windows.Forms.Padding(4);
            this.momentsTable.Name = "momentsTable";
            this.momentsTable.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.momentsTable.RowCount = 4;
            this.momentsTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.momentsTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.momentsTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.momentsTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.momentsTable.Size = new System.Drawing.Size(737, 60);
            this.momentsTable.TabIndex = 0;
            // 
            // initialMoment1Label
            // 
            this.initialMoment1Label.AutoSize = true;
            this.initialMoment1Label.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.initialMoment1Label.Location = new System.Drawing.Point(11, 12);
            this.initialMoment1Label.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.initialMoment1Label.Name = "initialMoment1Label";
            this.initialMoment1Label.Size = new System.Drawing.Size(0, 0);
            this.initialMoment1Label.TabIndex = 0;
            // 
            // centralMoment1Label
            // 
            this.centralMoment1Label.AutoSize = true;
            this.centralMoment1Label.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.centralMoment1Label.Location = new System.Drawing.Point(372, 12);
            this.centralMoment1Label.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.centralMoment1Label.Name = "centralMoment1Label";
            this.centralMoment1Label.Size = new System.Drawing.Size(0, 0);
            this.centralMoment1Label.TabIndex = 1;
            // 
            // initialMoment2Label
            // 
            this.initialMoment2Label.AutoSize = true;
            this.initialMoment2Label.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.initialMoment2Label.Location = new System.Drawing.Point(11, 24);
            this.initialMoment2Label.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.initialMoment2Label.Name = "initialMoment2Label";
            this.initialMoment2Label.Size = new System.Drawing.Size(0, 0);
            this.initialMoment2Label.TabIndex = 2;
            // 
            // centralMoment2Label
            // 
            this.centralMoment2Label.AutoSize = true;
            this.centralMoment2Label.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.centralMoment2Label.Location = new System.Drawing.Point(372, 24);
            this.centralMoment2Label.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.centralMoment2Label.Name = "centralMoment2Label";
            this.centralMoment2Label.Size = new System.Drawing.Size(0, 0);
            this.centralMoment2Label.TabIndex = 3;
            // 
            // initialMoment3Label
            // 
            this.initialMoment3Label.AutoSize = true;
            this.initialMoment3Label.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.initialMoment3Label.Location = new System.Drawing.Point(11, 36);
            this.initialMoment3Label.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.initialMoment3Label.Name = "initialMoment3Label";
            this.initialMoment3Label.Size = new System.Drawing.Size(0, 0);
            this.initialMoment3Label.TabIndex = 4;
            // 
            // centralMoment3Label
            // 
            this.centralMoment3Label.AutoSize = true;
            this.centralMoment3Label.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.centralMoment3Label.Location = new System.Drawing.Point(372, 36);
            this.centralMoment3Label.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.centralMoment3Label.Name = "centralMoment3Label";
            this.centralMoment3Label.Size = new System.Drawing.Size(0, 0);
            this.centralMoment3Label.TabIndex = 5;
            // 
            // initialMoment4Label
            // 
            this.initialMoment4Label.AutoSize = true;
            this.initialMoment4Label.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.initialMoment4Label.Location = new System.Drawing.Point(11, 48);
            this.initialMoment4Label.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.initialMoment4Label.Name = "initialMoment4Label";
            this.initialMoment4Label.Size = new System.Drawing.Size(0, 0);
            this.initialMoment4Label.TabIndex = 6;
            // 
            // centralMoment4Label
            // 
            this.centralMoment4Label.AutoSize = true;
            this.centralMoment4Label.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.centralMoment4Label.Location = new System.Drawing.Point(372, 48);
            this.centralMoment4Label.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.centralMoment4Label.Name = "centralMoment4Label";
            this.centralMoment4Label.Size = new System.Drawing.Size(0, 0);
            this.centralMoment4Label.TabIndex = 7;
            // 
            // statisticsGroupBox
            // 
            this.statisticsGroupBox.AutoSize = true;
            this.statisticsGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.statisticsGroupBox.Controls.Add(this.statsTable);
            this.statisticsGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.statisticsGroupBox.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.statisticsGroupBox.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.statisticsGroupBox.Location = new System.Drawing.Point(7, 6);
            this.statisticsGroupBox.Margin = new System.Windows.Forms.Padding(4, 12, 4, 4);
            this.statisticsGroupBox.Name = "statisticsGroupBox";
            this.statisticsGroupBox.Padding = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.statisticsGroupBox.Size = new System.Drawing.Size(763, 166);
            this.statisticsGroupBox.TabIndex = 2;
            this.statisticsGroupBox.TabStop = false;
            this.statisticsGroupBox.Text = "Основные статистические характеристики";
            // 
            // statsTable
            // 
            this.statsTable.AutoSize = true;
            this.statsTable.BackColor = System.Drawing.Color.Transparent;
            this.statsTable.ColumnCount = 1;
            this.statsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.statsTable.Controls.Add(this.meanLabel, 0, 0);
            this.statsTable.Controls.Add(this.medianLabel, 0, 1);
            this.statsTable.Controls.Add(this.modeLabel, 0, 2);
            this.statsTable.Controls.Add(this.meanAbsoluteDeviationLabel, 0, 3);
            this.statsTable.Controls.Add(this.sampleVarianceLabel, 0, 4);
            this.statsTable.Controls.Add(this.standardDeviationLabel, 0, 5);
            this.statsTable.Controls.Add(this.coefficientOfVariationLabel, 0, 6);
            this.statsTable.Controls.Add(this.skewnessLabel, 0, 7);
            this.statsTable.Controls.Add(this.kurtosisLabel, 0, 8);
            this.statsTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statsTable.Location = new System.Drawing.Point(13, 34);
            this.statsTable.Margin = new System.Windows.Forms.Padding(4);
            this.statsTable.Name = "statsTable";
            this.statsTable.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.statsTable.RowCount = 9;
            this.statsTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.statsTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.statsTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.statsTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.statsTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.statsTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.statsTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.statsTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.statsTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.statsTable.Size = new System.Drawing.Size(737, 120);
            this.statsTable.TabIndex = 0;
            // 
            // meanLabel
            // 
            this.meanLabel.AutoSize = true;
            this.meanLabel.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.meanLabel.Location = new System.Drawing.Point(11, 12);
            this.meanLabel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.meanLabel.Name = "meanLabel";
            this.meanLabel.Size = new System.Drawing.Size(0, 0);
            this.meanLabel.TabIndex = 0;
            // 
            // medianLabel
            // 
            this.medianLabel.AutoSize = true;
            this.medianLabel.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.medianLabel.Location = new System.Drawing.Point(11, 24);
            this.medianLabel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.medianLabel.Name = "medianLabel";
            this.medianLabel.Size = new System.Drawing.Size(0, 0);
            this.medianLabel.TabIndex = 1;
            // 
            // modeLabel
            // 
            this.modeLabel.AutoSize = true;
            this.modeLabel.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.modeLabel.Location = new System.Drawing.Point(11, 36);
            this.modeLabel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.modeLabel.Name = "modeLabel";
            this.modeLabel.Size = new System.Drawing.Size(0, 0);
            this.modeLabel.TabIndex = 2;
            // 
            // meanAbsoluteDeviationLabel
            // 
            this.meanAbsoluteDeviationLabel.AutoSize = true;
            this.meanAbsoluteDeviationLabel.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.meanAbsoluteDeviationLabel.Location = new System.Drawing.Point(11, 48);
            this.meanAbsoluteDeviationLabel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.meanAbsoluteDeviationLabel.Name = "meanAbsoluteDeviationLabel";
            this.meanAbsoluteDeviationLabel.Size = new System.Drawing.Size(0, 0);
            this.meanAbsoluteDeviationLabel.TabIndex = 3;
            // 
            // sampleVarianceLabel
            // 
            this.sampleVarianceLabel.AutoSize = true;
            this.sampleVarianceLabel.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.sampleVarianceLabel.Location = new System.Drawing.Point(11, 60);
            this.sampleVarianceLabel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.sampleVarianceLabel.Name = "sampleVarianceLabel";
            this.sampleVarianceLabel.Size = new System.Drawing.Size(0, 0);
            this.sampleVarianceLabel.TabIndex = 4;
            // 
            // standardDeviationLabel
            // 
            this.standardDeviationLabel.AutoSize = true;
            this.standardDeviationLabel.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.standardDeviationLabel.Location = new System.Drawing.Point(11, 72);
            this.standardDeviationLabel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.standardDeviationLabel.Name = "standardDeviationLabel";
            this.standardDeviationLabel.Size = new System.Drawing.Size(0, 0);
            this.standardDeviationLabel.TabIndex = 5;
            // 
            // coefficientOfVariationLabel
            // 
            this.coefficientOfVariationLabel.AutoSize = true;
            this.coefficientOfVariationLabel.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.coefficientOfVariationLabel.Location = new System.Drawing.Point(11, 84);
            this.coefficientOfVariationLabel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.coefficientOfVariationLabel.Name = "coefficientOfVariationLabel";
            this.coefficientOfVariationLabel.Size = new System.Drawing.Size(0, 0);
            this.coefficientOfVariationLabel.TabIndex = 6;
            // 
            // skewnessLabel
            // 
            this.skewnessLabel.AutoSize = true;
            this.skewnessLabel.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.skewnessLabel.Location = new System.Drawing.Point(11, 96);
            this.skewnessLabel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.skewnessLabel.Name = "skewnessLabel";
            this.skewnessLabel.Size = new System.Drawing.Size(0, 0);
            this.skewnessLabel.TabIndex = 7;
            // 
            // kurtosisLabel
            // 
            this.kurtosisLabel.AutoSize = true;
            this.kurtosisLabel.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.kurtosisLabel.Location = new System.Drawing.Point(11, 108);
            this.kurtosisLabel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.kurtosisLabel.Name = "kurtosisLabel";
            this.kurtosisLabel.Size = new System.Drawing.Size(0, 0);
            this.kurtosisLabel.TabIndex = 8;
            // 
            // VarSeriesControls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainTableLayout);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "VarSeriesControls";
            this.Size = new System.Drawing.Size(1333, 738);
            this.mainTableLayout.ResumeLayout(false);
            this.inputPanel.ResumeLayout(false);
            this.inputPanel.PerformLayout();
            this.inputFlowPanel.ResumeLayout(false);
            this.inputFlowPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.resultsPanel.ResumeLayout(false);
            this.resultsPanel.PerformLayout();
            this.momentsGroupBox.ResumeLayout(false);
            this.momentsGroupBox.PerformLayout();
            this.momentsTable.ResumeLayout(false);
            this.momentsTable.PerformLayout();
            this.statisticsGroupBox.ResumeLayout(false);
            this.statisticsGroupBox.PerformLayout();
            this.statsTable.ResumeLayout(false);
            this.statsTable.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainTableLayout;
        private MetroFramework.Controls.MetroPanel inputPanel;
        private System.Windows.Forms.FlowLayoutPanel inputFlowPanel;
        private MetroFramework.Controls.MetroPanel resultsPanel;
        private System.Windows.Forms.GroupBox statisticsGroupBox;
        private System.Windows.Forms.TableLayoutPanel statsTable;
        private System.Windows.Forms.GroupBox momentsGroupBox;
        private System.Windows.Forms.TableLayoutPanel momentsTable;
        private MetroFramework.Controls.MetroLabel typeLabel;
        private MetroFramework.Controls.MetroRadioButton discreteRadio;
        private MetroFramework.Controls.MetroRadioButton continuousRadio;
        private MetroFramework.Controls.MetroLabel spacerLabel1;
        private MetroFramework.Controls.MetroButton browseButton;
        private MetroFramework.Controls.MetroLabel dataLabel;
        private System.Windows.Forms.DataGridView dataGrid;
        private MetroFramework.Controls.MetroLabel spacerLabel2;
        private MetroFramework.Controls.MetroButton calculateButton;
        private MetroFramework.Controls.MetroLabel spacerLabel3;
        private MetroFramework.Controls.MetroButton showChartButton;
        private MetroFramework.Controls.MetroLabel meanLabel;
        private MetroFramework.Controls.MetroLabel medianLabel;
        private MetroFramework.Controls.MetroLabel modeLabel;
        private MetroFramework.Controls.MetroLabel meanAbsoluteDeviationLabel;
        private MetroFramework.Controls.MetroLabel sampleVarianceLabel;
        private MetroFramework.Controls.MetroLabel standardDeviationLabel;
        private MetroFramework.Controls.MetroLabel coefficientOfVariationLabel;
        private MetroFramework.Controls.MetroLabel skewnessLabel;
        private MetroFramework.Controls.MetroLabel kurtosisLabel;
        private MetroFramework.Controls.MetroLabel initialMoment1Label;
        private MetroFramework.Controls.MetroLabel centralMoment1Label;
        private MetroFramework.Controls.MetroLabel initialMoment2Label;
        private MetroFramework.Controls.MetroLabel centralMoment2Label;
        private MetroFramework.Controls.MetroLabel initialMoment3Label;
        private MetroFramework.Controls.MetroLabel centralMoment3Label;
        private MetroFramework.Controls.MetroLabel initialMoment4Label;
        private MetroFramework.Controls.MetroLabel centralMoment4Label;
    }
}