namespace MathStatRGR.Pages
{
    partial class AnovaControls
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        private void InitializeComponent()
        {
            this.mainTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.inputPanel = new MetroFramework.Controls.MetroPanel();
            this.inputFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.anovaTypeLabel = new MetroFramework.Controls.MetroLabel();
            this.anovaTypeComboBox = new MetroFramework.Controls.MetroComboBox();
            this.dataInputGroupBox = new System.Windows.Forms.GroupBox();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.browseButton = new MetroFramework.Controls.MetroButton();
            this.columnMappingGroupBox = new System.Windows.Forms.GroupBox();
            this.columnMappingTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.factorALabel = new MetroFramework.Controls.MetroLabel();
            this.factorAComboBox = new MetroFramework.Controls.MetroComboBox();
            this.factorBLabel = new MetroFramework.Controls.MetroLabel();
            this.factorBComboBox = new MetroFramework.Controls.MetroComboBox();
            this.valueLabel = new MetroFramework.Controls.MetroLabel();
            this.valueComboBox = new MetroFramework.Controls.MetroComboBox();
            this.alphaLabel = new MetroFramework.Controls.MetroLabel();
            this.alphaTextBox = new MetroFramework.Controls.MetroTextBox();
            this.calculateButton = new MetroFramework.Controls.MetroButton();
            this.resultsPanel = new MetroFramework.Controls.MetroPanel();
            this.resultsDataGrid = new System.Windows.Forms.DataGridView();
            this.resultsConclusionLabel = new MetroFramework.Controls.MetroLabel();
            this.mainTableLayout.SuspendLayout();
            this.inputPanel.SuspendLayout();
            this.inputFlowPanel.SuspendLayout();
            this.dataInputGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.columnMappingGroupBox.SuspendLayout();
            this.columnMappingTableLayout.SuspendLayout();
            this.resultsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultsDataGrid)).BeginInit();
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
            this.mainTableLayout.TabIndex = 1;
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
            this.inputFlowPanel.Controls.Add(this.anovaTypeLabel);
            this.inputFlowPanel.Controls.Add(this.anovaTypeComboBox);
            this.inputFlowPanel.Controls.Add(this.dataInputGroupBox);
            this.inputFlowPanel.Controls.Add(this.columnMappingGroupBox);
            this.inputFlowPanel.Controls.Add(this.alphaLabel);
            this.inputFlowPanel.Controls.Add(this.alphaTextBox);
            this.inputFlowPanel.Controls.Add(this.calculateButton);
            this.inputFlowPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.inputFlowPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.inputFlowPanel.Location = new System.Drawing.Point(7, 6);
            this.inputFlowPanel.Margin = new System.Windows.Forms.Padding(4);
            this.inputFlowPanel.Name = "inputFlowPanel";
            this.inputFlowPanel.Size = new System.Drawing.Size(500, 650);
            this.inputFlowPanel.TabIndex = 2;
            this.inputFlowPanel.WrapContents = false;
            // 
            // anovaTypeLabel
            // 
            this.anovaTypeLabel.AutoSize = true;
            this.anovaTypeLabel.Location = new System.Drawing.Point(4, 12);
            this.anovaTypeLabel.Margin = new System.Windows.Forms.Padding(4, 12, 4, 6);
            this.anovaTypeLabel.Name = "anovaTypeLabel";
            this.anovaTypeLabel.Size = new System.Drawing.Size(190, 20);
            this.anovaTypeLabel.TabIndex = 0;
            this.anovaTypeLabel.Text = "Тип дисперсионного анализа:";
            // 
            // anovaTypeComboBox
            // 
            this.anovaTypeComboBox.FormattingEnabled = true;
            this.anovaTypeComboBox.ItemHeight = 24;
            this.anovaTypeComboBox.Location = new System.Drawing.Point(4, 42);
            this.anovaTypeComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 12);
            this.anovaTypeComboBox.Name = "anovaTypeComboBox";
            this.anovaTypeComboBox.Size = new System.Drawing.Size(492, 30);
            this.anovaTypeComboBox.TabIndex = 1;
            this.anovaTypeComboBox.UseSelectable = true;
            // 
            // dataInputGroupBox
            // 
            this.dataInputGroupBox.AutoSize = true;
            this.dataInputGroupBox.Controls.Add(this.dataGrid);
            this.dataInputGroupBox.Controls.Add(this.browseButton);
            this.dataInputGroupBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dataInputGroupBox.Location = new System.Drawing.Point(3, 87);
            this.dataInputGroupBox.MinimumSize = new System.Drawing.Size(490, 0);
            this.dataInputGroupBox.Name = "dataInputGroupBox";
            this.dataInputGroupBox.Padding = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.dataInputGroupBox.Size = new System.Drawing.Size(494, 303);
            this.dataInputGroupBox.TabIndex = 2;
            this.dataInputGroupBox.TabStop = false;
            this.dataInputGroupBox.Text = "Ввод данных";
            // 
            // dataGrid
            // 
            this.dataGrid.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.GridColor = System.Drawing.Color.LightGray;
            this.dataGrid.Location = new System.Drawing.Point(7, 68);
            this.dataGrid.Margin = new System.Windows.Forms.Padding(4);
            this.dataGrid.MinimumSize = new System.Drawing.Size(400, 185);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.RowHeadersVisible = false;
            this.dataGrid.RowHeadersWidth = 51;
            this.dataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGrid.Size = new System.Drawing.Size(480, 205);
            this.dataGrid.TabIndex = 1;
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(7, 24);
            this.browseButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 4);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(480, 37);
            this.browseButton.TabIndex = 0;
            this.browseButton.Text = "Выбрать файл...";
            this.browseButton.UseSelectable = true;
            // 
            // columnMappingGroupBox
            // 
            this.columnMappingGroupBox.AutoSize = true;
            this.columnMappingGroupBox.Controls.Add(this.columnMappingTableLayout);
            this.columnMappingGroupBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.columnMappingGroupBox.Location = new System.Drawing.Point(3, 396);
            this.columnMappingGroupBox.MinimumSize = new System.Drawing.Size(490, 0);
            this.columnMappingGroupBox.Name = "columnMappingGroupBox";
            this.columnMappingGroupBox.Size = new System.Drawing.Size(494, 131);
            this.columnMappingGroupBox.TabIndex = 3;
            this.columnMappingGroupBox.TabStop = false;
            this.columnMappingGroupBox.Text = "Сопоставление столбцов";
            // 
            // columnMappingTableLayout
            // 
            this.columnMappingTableLayout.AutoSize = true;
            this.columnMappingTableLayout.ColumnCount = 2;
            this.columnMappingTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.columnMappingTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.columnMappingTableLayout.Controls.Add(this.factorALabel, 0, 0);
            this.columnMappingTableLayout.Controls.Add(this.factorAComboBox, 1, 0);
            this.columnMappingTableLayout.Controls.Add(this.factorBLabel, 0, 1);
            this.columnMappingTableLayout.Controls.Add(this.factorBComboBox, 1, 1);
            this.columnMappingTableLayout.Controls.Add(this.valueLabel, 0, 2);
            this.columnMappingTableLayout.Controls.Add(this.valueComboBox, 1, 2);
            this.columnMappingTableLayout.Dock = System.Windows.Forms.DockStyle.Top;
            this.columnMappingTableLayout.Location = new System.Drawing.Point(3, 23);
            this.columnMappingTableLayout.Name = "columnMappingTableLayout";
            this.columnMappingTableLayout.RowCount = 3;
            this.columnMappingTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.columnMappingTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.columnMappingTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.columnMappingTableLayout.Size = new System.Drawing.Size(488, 105);
            this.columnMappingTableLayout.TabIndex = 0;
            // 
            // factorALabel
            // 
            this.factorALabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.factorALabel.AutoSize = true;
            this.factorALabel.Location = new System.Drawing.Point(3, 7);
            this.factorALabel.Name = "factorALabel";
            this.factorALabel.Size = new System.Drawing.Size(76, 20);
            this.factorALabel.TabIndex = 0;
            this.factorALabel.Text = "Фактор A:";
            // 
            // factorAComboBox
            // 
            this.factorAComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.factorAComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.factorAComboBox.FormattingEnabled = true;
            this.factorAComboBox.ItemHeight = 24;
            this.factorAComboBox.Location = new System.Drawing.Point(183, 3);
            this.factorAComboBox.Name = "factorAComboBox";
            this.factorAComboBox.Size = new System.Drawing.Size(302, 30);
            this.factorAComboBox.TabIndex = 1;
            this.factorAComboBox.UseSelectable = true;
            // 
            // factorBLabel
            // 
            this.factorBLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.factorBLabel.AutoSize = true;
            this.factorBLabel.Location = new System.Drawing.Point(3, 42);
            this.factorBLabel.Name = "factorBLabel";
            this.factorBLabel.Size = new System.Drawing.Size(74, 20);
            this.factorBLabel.TabIndex = 2;
            this.factorBLabel.Text = "Фактор B:";
            // 
            // factorBComboBox
            // 
            this.factorBComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.factorBComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.factorBComboBox.FormattingEnabled = true;
            this.factorBComboBox.ItemHeight = 24;
            this.factorBComboBox.Location = new System.Drawing.Point(183, 38);
            this.factorBComboBox.Name = "factorBComboBox";
            this.factorBComboBox.Size = new System.Drawing.Size(302, 30);
            this.factorBComboBox.TabIndex = 3;
            this.factorBComboBox.UseSelectable = true;
            // 
            // valueLabel
            // 
            this.valueLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.valueLabel.AutoSize = true;
            this.valueLabel.Location = new System.Drawing.Point(3, 77);
            this.valueLabel.Name = "valueLabel";
            this.valueLabel.Size = new System.Drawing.Size(133, 20);
            this.valueLabel.TabIndex = 4;
            this.valueLabel.Text = "Столбец значений:";
            // 
            // valueComboBox
            // 
            this.valueComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.valueComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.valueComboBox.FormattingEnabled = true;
            this.valueComboBox.ItemHeight = 24;
            this.valueComboBox.Location = new System.Drawing.Point(183, 73);
            this.valueComboBox.Name = "valueComboBox";
            this.valueComboBox.Size = new System.Drawing.Size(302, 30);
            this.valueComboBox.TabIndex = 5;
            this.valueComboBox.UseSelectable = true;
            // 
            // alphaLabel
            // 
            this.alphaLabel.AutoSize = true;
            this.alphaLabel.Location = new System.Drawing.Point(4, 542);
            this.alphaLabel.Margin = new System.Windows.Forms.Padding(4, 12, 4, 0);
            this.alphaLabel.Name = "alphaLabel";
            this.alphaLabel.Size = new System.Drawing.Size(193, 20);
            this.alphaLabel.TabIndex = 4;
            this.alphaLabel.Text = "Уровень значимости (alpha):";
            // 
            // alphaTextBox
            // 
            this.alphaTextBox.CustomButton.Image = null;
            this.alphaTextBox.CustomButton.Location = new System.Drawing.Point(465, 2);
            this.alphaTextBox.CustomButton.Margin = new System.Windows.Forms.Padding(5);
            this.alphaTextBox.CustomButton.Name = "";
            this.alphaTextBox.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.alphaTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.alphaTextBox.CustomButton.TabIndex = 1;
            this.alphaTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.alphaTextBox.CustomButton.UseSelectable = true;
            this.alphaTextBox.CustomButton.Visible = false;
            this.alphaTextBox.Lines = new string[] { "0.05" };
            this.alphaTextBox.Location = new System.Drawing.Point(4, 566);
            this.alphaTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.alphaTextBox.MaxLength = 32767;
            this.alphaTextBox.Name = "alphaTextBox";
            this.alphaTextBox.PasswordChar = '\0';
            this.alphaTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.alphaTextBox.SelectedText = "";
            this.alphaTextBox.SelectionLength = 0;
            this.alphaTextBox.SelectionStart = 0;
            this.alphaTextBox.ShortcutsEnabled = true;
            this.alphaTextBox.Size = new System.Drawing.Size(493, 30);
            this.alphaTextBox.TabIndex = 5;
            this.alphaTextBox.Text = "0.05";
            this.alphaTextBox.UseSelectable = true;
            this.alphaTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.alphaTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // calculateButton
            // 
            this.calculateButton.Location = new System.Drawing.Point(4, 606);
            this.calculateButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 0);
            this.calculateButton.Name = "calculateButton";
            this.calculateButton.Size = new System.Drawing.Size(493, 43);
            this.calculateButton.TabIndex = 6;
            this.calculateButton.Text = "Рассчитать ANOVA";
            this.calculateButton.UseSelectable = true;
            // 
            // resultsPanel
            // 
            this.resultsPanel.AutoScroll = true;
            this.resultsPanel.Controls.Add(this.resultsDataGrid);
            this.resultsPanel.Controls.Add(this.resultsConclusionLabel);
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
            // resultsDataGrid
            // 
            this.resultsDataGrid.AllowUserToAddRows = false;
            this.resultsDataGrid.AllowUserToDeleteRows = false;
            this.resultsDataGrid.AllowUserToResizeRows = false;
            this.resultsDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.resultsDataGrid.BackgroundColor = System.Drawing.SystemColors.Window;
            this.resultsDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultsDataGrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.resultsDataGrid.Location = new System.Drawing.Point(7, 6);
            this.resultsDataGrid.Name = "resultsDataGrid";
            this.resultsDataGrid.ReadOnly = true;
            this.resultsDataGrid.RowHeadersVisible = false;
            this.resultsDataGrid.RowTemplate.Height = 24;
            this.resultsDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.resultsDataGrid.Size = new System.Drawing.Size(763, 250);
            this.resultsDataGrid.TabIndex = 2;
            // 
            // resultsConclusionLabel
            // 
            this.resultsConclusionLabel.AutoSize = true;
            this.resultsConclusionLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.resultsConclusionLabel.FontSize = MetroFramework.MetroLabelSize.Medium;
            this.resultsConclusionLabel.Location = new System.Drawing.Point(7, 256);
            this.resultsConclusionLabel.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.resultsConclusionLabel.Name = "resultsConclusionLabel";
            this.resultsConclusionLabel.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.resultsConclusionLabel.Size = new System.Drawing.Size(0, 20); // AutoSize=true, поэтому Size не так важен
            this.resultsConclusionLabel.TabIndex = 3;
            this.resultsConclusionLabel.WrapToLine = true;
            // 
            // AnovaControls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainTableLayout);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AnovaControls";
            this.Size = new System.Drawing.Size(1333, 738);
            this.mainTableLayout.ResumeLayout(false);
            this.inputPanel.ResumeLayout(false);
            this.inputPanel.PerformLayout();
            this.inputFlowPanel.ResumeLayout(false);
            this.inputFlowPanel.PerformLayout();
            this.dataInputGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.columnMappingGroupBox.ResumeLayout(false);
            this.columnMappingGroupBox.PerformLayout();
            this.columnMappingTableLayout.ResumeLayout(false);
            this.columnMappingTableLayout.PerformLayout();
            this.resultsPanel.ResumeLayout(false);
            this.resultsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultsDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainTableLayout;
        private MetroFramework.Controls.MetroPanel inputPanel;
        private System.Windows.Forms.FlowLayoutPanel inputFlowPanel;
        private MetroFramework.Controls.MetroPanel resultsPanel;
        private MetroFramework.Controls.MetroLabel anovaTypeLabel;
        private MetroFramework.Controls.MetroComboBox anovaTypeComboBox;
        private System.Windows.Forms.GroupBox dataInputGroupBox;
        private MetroFramework.Controls.MetroButton browseButton;
        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.GroupBox columnMappingGroupBox;
        private System.Windows.Forms.TableLayoutPanel columnMappingTableLayout;
        private MetroFramework.Controls.MetroLabel factorALabel;
        private MetroFramework.Controls.MetroComboBox factorAComboBox;
        private MetroFramework.Controls.MetroLabel factorBLabel;
        private MetroFramework.Controls.MetroComboBox factorBComboBox;
        private MetroFramework.Controls.MetroLabel valueLabel;
        private MetroFramework.Controls.MetroComboBox valueComboBox;
        private MetroFramework.Controls.MetroLabel alphaLabel;
        private MetroFramework.Controls.MetroTextBox alphaTextBox;
        private MetroFramework.Controls.MetroButton calculateButton;
        private System.Windows.Forms.DataGridView resultsDataGrid;
        private MetroFramework.Controls.MetroLabel resultsConclusionLabel;
    }
}