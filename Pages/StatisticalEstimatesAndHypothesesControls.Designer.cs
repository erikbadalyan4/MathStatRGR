namespace MathStatRGR.Pages
{
    partial class StatisticalEstimatesAndHypothesesControls
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.excelButton = new MetroFramework.Controls.MetroButton();
            this.estimatesGroupBox = new System.Windows.Forms.GroupBox();
            this.estimatesButton = new MetroFramework.Controls.MetroButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.capacityNTextBox = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel9 = new MetroFramework.Controls.MetroLabel();
            this.capacityVerTextBox = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel10 = new MetroFramework.Controls.MetroLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.bordersIntervalTextBox2 = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.bordersIntervalTextBox1 = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.bordersVerTextBox = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.verGroupBox = new System.Windows.Forms.GroupBox();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.verShareTextBox = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.verShareThresholdTextBox = new MetroFramework.Controls.MetroTextBox();
            this.verShareThresholdComboBox = new System.Windows.Forms.ComboBox();
            this.verShareThresholdLabel = new MetroFramework.Controls.MetroLabel();
            this.verAvgTextBox = new MetroFramework.Controls.MetroTextBox();
            this.verAvgLabel = new MetroFramework.Controls.MetroLabel();
            this.verAvgRadioButton = new MetroFramework.Controls.MetroRadioButton();
            this.verShareRadioButton = new MetroFramework.Controls.MetroRadioButton();
            this.hypothesesButton = new MetroFramework.Controls.MetroButton();
            this.hypothesesGroupBox = new System.Windows.Forms.GroupBox();
            this.alphaTextBox = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.resultCapacityLabel = new MetroFramework.Controls.MetroLabel();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.resultBorderLabel = new MetroFramework.Controls.MetroLabel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.resultVerLabel = new MetroFramework.Controls.MetroLabel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.resultKolmogorLabel = new MetroFramework.Controls.MetroLabel();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.resultPirsonLabel = new MetroFramework.Controls.MetroLabel();
            this.table = new System.Windows.Forms.DataGridView();
            this.Interval = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.clearTableButton = new MetroFramework.Controls.MetroButton();
            this.estimatesGroupBox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.verGroupBox.SuspendLayout();
            this.hypothesesGroupBox.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.table)).BeginInit();
            this.groupBox8.SuspendLayout();
            this.SuspendLayout();
            // 
            // excelButton
            // 
            this.excelButton.Location = new System.Drawing.Point(6, 516);
            this.excelButton.Margin = new System.Windows.Forms.Padding(2);
            this.excelButton.Name = "excelButton";
            this.excelButton.Size = new System.Drawing.Size(295, 32);
            this.excelButton.TabIndex = 5;
            this.excelButton.Text = "Загрузить данные из Excel";
            this.excelButton.UseSelectable = true;
            this.excelButton.Click += new System.EventHandler(this.excelButton_Click);
            // 
            // estimatesGroupBox
            // 
            this.estimatesGroupBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.estimatesGroupBox.Controls.Add(this.estimatesButton);
            this.estimatesGroupBox.Controls.Add(this.groupBox2);
            this.estimatesGroupBox.Controls.Add(this.groupBox1);
            this.estimatesGroupBox.Controls.Add(this.verGroupBox);
            this.estimatesGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.estimatesGroupBox.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.estimatesGroupBox.Location = new System.Drawing.Point(324, 12);
            this.estimatesGroupBox.Margin = new System.Windows.Forms.Padding(2);
            this.estimatesGroupBox.Name = "estimatesGroupBox";
            this.estimatesGroupBox.Padding = new System.Windows.Forms.Padding(2);
            this.estimatesGroupBox.Size = new System.Drawing.Size(288, 444);
            this.estimatesGroupBox.TabIndex = 6;
            this.estimatesGroupBox.TabStop = false;
            this.estimatesGroupBox.Text = "Расчет оценок";
            // 
            // estimatesButton
            // 
            this.estimatesButton.Location = new System.Drawing.Point(7, 408);
            this.estimatesButton.Name = "estimatesButton";
            this.estimatesButton.Size = new System.Drawing.Size(275, 32);
            this.estimatesButton.TabIndex = 10;
            this.estimatesButton.Text = "Расчитать";
            this.estimatesButton.UseSelectable = true;
            this.estimatesButton.Click += new System.EventHandler(this.estimatesButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox2.Controls.Add(this.capacityNTextBox);
            this.groupBox2.Controls.Add(this.metroLabel9);
            this.groupBox2.Controls.Add(this.capacityVerTextBox);
            this.groupBox2.Controls.Add(this.metroLabel10);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBox2.Location = new System.Drawing.Point(7, 299);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(275, 104);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Вычисление объема выборки";
            // 
            // capacityNTextBox
            // 
            // 
            // 
            // 
            this.capacityNTextBox.CustomButton.Image = null;
            this.capacityNTextBox.CustomButton.Location = new System.Drawing.Point(36, 2);
            this.capacityNTextBox.CustomButton.Name = "";
            this.capacityNTextBox.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.capacityNTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.capacityNTextBox.CustomButton.TabIndex = 1;
            this.capacityNTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.capacityNTextBox.CustomButton.UseSelectable = true;
            this.capacityNTextBox.CustomButton.Visible = false;
            this.capacityNTextBox.Lines = new string[0];
            this.capacityNTextBox.Location = new System.Drawing.Point(124, 53);
            this.capacityNTextBox.MaxLength = 32767;
            this.capacityNTextBox.Name = "capacityNTextBox";
            this.capacityNTextBox.PasswordChar = '\0';
            this.capacityNTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.capacityNTextBox.SelectedText = "";
            this.capacityNTextBox.SelectionLength = 0;
            this.capacityNTextBox.SelectionStart = 0;
            this.capacityNTextBox.ShortcutsEnabled = true;
            this.capacityNTextBox.Size = new System.Drawing.Size(54, 20);
            this.capacityNTextBox.TabIndex = 9;
            this.capacityNTextBox.UseSelectable = true;
            this.capacityNTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.capacityNTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel9
            // 
            this.metroLabel9.AutoSize = true;
            this.metroLabel9.Location = new System.Drawing.Point(7, 52);
            this.metroLabel9.Name = "metroLabel9";
            this.metroLabel9.Size = new System.Drawing.Size(115, 19);
            this.metroLabel9.TabIndex = 8;
            this.metroLabel9.Text = "Общее число (N)";
            this.metroLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // capacityVerTextBox
            // 
            // 
            // 
            // 
            this.capacityVerTextBox.CustomButton.Image = null;
            this.capacityVerTextBox.CustomButton.Location = new System.Drawing.Point(57, 2);
            this.capacityVerTextBox.CustomButton.Name = "";
            this.capacityVerTextBox.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.capacityVerTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.capacityVerTextBox.CustomButton.TabIndex = 1;
            this.capacityVerTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.capacityVerTextBox.CustomButton.UseSelectable = true;
            this.capacityVerTextBox.CustomButton.Visible = false;
            this.capacityVerTextBox.Lines = new string[0];
            this.capacityVerTextBox.Location = new System.Drawing.Point(93, 28);
            this.capacityVerTextBox.MaxLength = 32767;
            this.capacityVerTextBox.Name = "capacityVerTextBox";
            this.capacityVerTextBox.PasswordChar = '\0';
            this.capacityVerTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.capacityVerTextBox.SelectedText = "";
            this.capacityVerTextBox.SelectionLength = 0;
            this.capacityVerTextBox.SelectionStart = 0;
            this.capacityVerTextBox.ShortcutsEnabled = true;
            this.capacityVerTextBox.Size = new System.Drawing.Size(75, 20);
            this.capacityVerTextBox.TabIndex = 7;
            this.capacityVerTextBox.UseSelectable = true;
            this.capacityVerTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.capacityVerTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel10
            // 
            this.metroLabel10.AutoSize = true;
            this.metroLabel10.Location = new System.Drawing.Point(7, 27);
            this.metroLabel10.Name = "metroLabel10";
            this.metroLabel10.Size = new System.Drawing.Size(85, 19);
            this.metroLabel10.TabIndex = 0;
            this.metroLabel10.Text = "Вероятность";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Controls.Add(this.metroLabel5);
            this.groupBox1.Controls.Add(this.bordersIntervalTextBox2);
            this.groupBox1.Controls.Add(this.metroLabel4);
            this.groupBox1.Controls.Add(this.bordersIntervalTextBox1);
            this.groupBox1.Controls.Add(this.metroLabel3);
            this.groupBox1.Controls.Add(this.bordersVerTextBox);
            this.groupBox1.Controls.Add(this.metroLabel2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBox1.Location = new System.Drawing.Point(7, 191);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(275, 104);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Вычисление границ";
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(188, 60);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(24, 19);
            this.metroLabel5.TabIndex = 12;
            this.metroLabel5.Text = "до";
            this.metroLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroLabel5.Click += new System.EventHandler(this.metroLabel5_Click);
            // 
            // bordersIntervalTextBox2
            // 
            // 
            // 
            // 
            this.bordersIntervalTextBox2.CustomButton.Image = null;
            this.bordersIntervalTextBox2.CustomButton.Location = new System.Drawing.Point(36, 2);
            this.bordersIntervalTextBox2.CustomButton.Name = "";
            this.bordersIntervalTextBox2.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.bordersIntervalTextBox2.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.bordersIntervalTextBox2.CustomButton.TabIndex = 1;
            this.bordersIntervalTextBox2.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.bordersIntervalTextBox2.CustomButton.UseSelectable = true;
            this.bordersIntervalTextBox2.CustomButton.Visible = false;
            this.bordersIntervalTextBox2.Lines = new string[0];
            this.bordersIntervalTextBox2.Location = new System.Drawing.Point(214, 60);
            this.bordersIntervalTextBox2.MaxLength = 32767;
            this.bordersIntervalTextBox2.Name = "bordersIntervalTextBox2";
            this.bordersIntervalTextBox2.PasswordChar = '\0';
            this.bordersIntervalTextBox2.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.bordersIntervalTextBox2.SelectedText = "";
            this.bordersIntervalTextBox2.SelectionLength = 0;
            this.bordersIntervalTextBox2.SelectionStart = 0;
            this.bordersIntervalTextBox2.ShortcutsEnabled = true;
            this.bordersIntervalTextBox2.Size = new System.Drawing.Size(54, 20);
            this.bordersIntervalTextBox2.TabIndex = 11;
            this.bordersIntervalTextBox2.UseSelectable = true;
            this.bordersIntervalTextBox2.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.bordersIntervalTextBox2.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.bordersIntervalTextBox2.Click += new System.EventHandler(this.metroTextBox1_Click_2);
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(107, 60);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(22, 19);
            this.metroLabel4.TabIndex = 10;
            this.metroLabel4.Text = "от";
            this.metroLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroLabel4.Click += new System.EventHandler(this.metroLabel4_Click);
            // 
            // bordersIntervalTextBox1
            // 
            // 
            // 
            // 
            this.bordersIntervalTextBox1.CustomButton.Image = null;
            this.bordersIntervalTextBox1.CustomButton.Location = new System.Drawing.Point(36, 2);
            this.bordersIntervalTextBox1.CustomButton.Name = "";
            this.bordersIntervalTextBox1.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.bordersIntervalTextBox1.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.bordersIntervalTextBox1.CustomButton.TabIndex = 1;
            this.bordersIntervalTextBox1.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.bordersIntervalTextBox1.CustomButton.UseSelectable = true;
            this.bordersIntervalTextBox1.CustomButton.Visible = false;
            this.bordersIntervalTextBox1.Lines = new string[0];
            this.bordersIntervalTextBox1.Location = new System.Drawing.Point(131, 60);
            this.bordersIntervalTextBox1.MaxLength = 32767;
            this.bordersIntervalTextBox1.Name = "bordersIntervalTextBox1";
            this.bordersIntervalTextBox1.PasswordChar = '\0';
            this.bordersIntervalTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.bordersIntervalTextBox1.SelectedText = "";
            this.bordersIntervalTextBox1.SelectionLength = 0;
            this.bordersIntervalTextBox1.SelectionStart = 0;
            this.bordersIntervalTextBox1.ShortcutsEnabled = true;
            this.bordersIntervalTextBox1.Size = new System.Drawing.Size(54, 20);
            this.bordersIntervalTextBox1.TabIndex = 9;
            this.bordersIntervalTextBox1.UseSelectable = true;
            this.bordersIntervalTextBox1.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.bordersIntervalTextBox1.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.bordersIntervalTextBox1.Click += new System.EventHandler(this.metroTextBox1_Click_1);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(7, 51);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(101, 38);
            this.metroLabel3.TabIndex = 8;
            this.metroLabel3.Text = "Интервал \r\n(опционально)";
            this.metroLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bordersVerTextBox
            // 
            // 
            // 
            // 
            this.bordersVerTextBox.CustomButton.Image = null;
            this.bordersVerTextBox.CustomButton.Location = new System.Drawing.Point(57, 2);
            this.bordersVerTextBox.CustomButton.Name = "";
            this.bordersVerTextBox.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.bordersVerTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.bordersVerTextBox.CustomButton.TabIndex = 1;
            this.bordersVerTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.bordersVerTextBox.CustomButton.UseSelectable = true;
            this.bordersVerTextBox.CustomButton.Visible = false;
            this.bordersVerTextBox.Lines = new string[0];
            this.bordersVerTextBox.Location = new System.Drawing.Point(93, 28);
            this.bordersVerTextBox.MaxLength = 32767;
            this.bordersVerTextBox.Name = "bordersVerTextBox";
            this.bordersVerTextBox.PasswordChar = '\0';
            this.bordersVerTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.bordersVerTextBox.SelectedText = "";
            this.bordersVerTextBox.SelectionLength = 0;
            this.bordersVerTextBox.SelectionStart = 0;
            this.bordersVerTextBox.ShortcutsEnabled = true;
            this.bordersVerTextBox.Size = new System.Drawing.Size(75, 20);
            this.bordersVerTextBox.TabIndex = 7;
            this.bordersVerTextBox.UseSelectable = true;
            this.bordersVerTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.bordersVerTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(7, 27);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(85, 19);
            this.metroLabel2.TabIndex = 0;
            this.metroLabel2.Text = "Вероятность";
            // 
            // verGroupBox
            // 
            this.verGroupBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.verGroupBox.Controls.Add(this.metroLabel6);
            this.verGroupBox.Controls.Add(this.verShareTextBox);
            this.verGroupBox.Controls.Add(this.metroLabel1);
            this.verGroupBox.Controls.Add(this.verShareThresholdTextBox);
            this.verGroupBox.Controls.Add(this.verShareThresholdComboBox);
            this.verGroupBox.Controls.Add(this.verShareThresholdLabel);
            this.verGroupBox.Controls.Add(this.verAvgTextBox);
            this.verGroupBox.Controls.Add(this.verAvgLabel);
            this.verGroupBox.Controls.Add(this.verAvgRadioButton);
            this.verGroupBox.Controls.Add(this.verShareRadioButton);
            this.verGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.verGroupBox.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.verGroupBox.Location = new System.Drawing.Point(7, 20);
            this.verGroupBox.Margin = new System.Windows.Forms.Padding(2);
            this.verGroupBox.Name = "verGroupBox";
            this.verGroupBox.Padding = new System.Windows.Forms.Padding(2);
            this.verGroupBox.Size = new System.Drawing.Size(275, 170);
            this.verGroupBox.TabIndex = 7;
            this.verGroupBox.TabStop = false;
            this.verGroupBox.Text = "Вычисление вероятности";
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(22, 115);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(107, 19);
            this.metroLabel6.TabIndex = 12;
            this.metroLabel6.Text = "Условие порога";
            this.metroLabel6.Click += new System.EventHandler(this.metroLabel6_Click);
            // 
            // verShareTextBox
            // 
            // 
            // 
            // 
            this.verShareTextBox.CustomButton.Image = null;
            this.verShareTextBox.CustomButton.Location = new System.Drawing.Point(57, 2);
            this.verShareTextBox.CustomButton.Name = "";
            this.verShareTextBox.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.verShareTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.verShareTextBox.CustomButton.TabIndex = 1;
            this.verShareTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.verShareTextBox.CustomButton.UseSelectable = true;
            this.verShareTextBox.CustomButton.Visible = false;
            this.verShareTextBox.Lines = new string[0];
            this.verShareTextBox.Location = new System.Drawing.Point(181, 141);
            this.verShareTextBox.MaxLength = 32767;
            this.verShareTextBox.Name = "verShareTextBox";
            this.verShareTextBox.PasswordChar = '\0';
            this.verShareTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.verShareTextBox.SelectedText = "";
            this.verShareTextBox.SelectionLength = 0;
            this.verShareTextBox.SelectionStart = 0;
            this.verShareTextBox.ShortcutsEnabled = true;
            this.verShareTextBox.Size = new System.Drawing.Size(75, 20);
            this.verShareTextBox.TabIndex = 11;
            this.verShareTextBox.UseSelectable = true;
            this.verShareTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.verShareTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.verShareTextBox.Click += new System.EventHandler(this.metroTextBox1_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(22, 141);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(158, 19);
            this.metroLabel1.TabIndex = 10;
            this.metroLabel1.Text = "Разница долей в числах";
            this.metroLabel1.Click += new System.EventHandler(this.metroLabel1_Click);
            // 
            // verShareThresholdTextBox
            // 
            // 
            // 
            // 
            this.verShareThresholdTextBox.CustomButton.Image = null;
            this.verShareThresholdTextBox.CustomButton.Location = new System.Drawing.Point(57, 2);
            this.verShareThresholdTextBox.CustomButton.Name = "";
            this.verShareThresholdTextBox.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.verShareThresholdTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.verShareThresholdTextBox.CustomButton.TabIndex = 1;
            this.verShareThresholdTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.verShareThresholdTextBox.CustomButton.UseSelectable = true;
            this.verShareThresholdTextBox.CustomButton.Visible = false;
            this.verShareThresholdTextBox.Lines = new string[0];
            this.verShareThresholdTextBox.Location = new System.Drawing.Point(72, 90);
            this.verShareThresholdTextBox.MaxLength = 32767;
            this.verShareThresholdTextBox.Name = "verShareThresholdTextBox";
            this.verShareThresholdTextBox.PasswordChar = '\0';
            this.verShareThresholdTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.verShareThresholdTextBox.SelectedText = "";
            this.verShareThresholdTextBox.SelectionLength = 0;
            this.verShareThresholdTextBox.SelectionStart = 0;
            this.verShareThresholdTextBox.ShortcutsEnabled = true;
            this.verShareThresholdTextBox.Size = new System.Drawing.Size(75, 20);
            this.verShareThresholdTextBox.TabIndex = 9;
            this.verShareThresholdTextBox.UseSelectable = true;
            this.verShareThresholdTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.verShareThresholdTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // verShareThresholdComboBox
            // 
            this.verShareThresholdComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.verShareThresholdComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.verShareThresholdComboBox.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.verShareThresholdComboBox.FormattingEnabled = true;
            this.verShareThresholdComboBox.Items.AddRange(new object[] {
            "более чем",
            "менее чем"});
            this.verShareThresholdComboBox.Location = new System.Drawing.Point(129, 114);
            this.verShareThresholdComboBox.Name = "verShareThresholdComboBox";
            this.verShareThresholdComboBox.Size = new System.Drawing.Size(85, 23);
            this.verShareThresholdComboBox.TabIndex = 8;
            this.verShareThresholdComboBox.SelectedIndexChanged += new System.EventHandler(this.verShareThresholdComboBox_SelectedIndexChanged);
            // 
            // verShareThresholdLabel
            // 
            this.verShareThresholdLabel.AutoSize = true;
            this.verShareThresholdLabel.Location = new System.Drawing.Point(22, 91);
            this.verShareThresholdLabel.Name = "verShareThresholdLabel";
            this.verShareThresholdLabel.Size = new System.Drawing.Size(47, 19);
            this.verShareThresholdLabel.TabIndex = 7;
            this.verShareThresholdLabel.Text = "Порог";
            // 
            // verAvgTextBox
            // 
            // 
            // 
            // 
            this.verAvgTextBox.CustomButton.Image = null;
            this.verAvgTextBox.CustomButton.Location = new System.Drawing.Point(57, 2);
            this.verAvgTextBox.CustomButton.Name = "";
            this.verAvgTextBox.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.verAvgTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.verAvgTextBox.CustomButton.TabIndex = 1;
            this.verAvgTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.verAvgTextBox.CustomButton.UseSelectable = true;
            this.verAvgTextBox.CustomButton.Visible = false;
            this.verAvgTextBox.Lines = new string[0];
            this.verAvgTextBox.Location = new System.Drawing.Point(138, 40);
            this.verAvgTextBox.MaxLength = 32767;
            this.verAvgTextBox.Name = "verAvgTextBox";
            this.verAvgTextBox.PasswordChar = '\0';
            this.verAvgTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.verAvgTextBox.SelectedText = "";
            this.verAvgTextBox.SelectionLength = 0;
            this.verAvgTextBox.SelectionStart = 0;
            this.verAvgTextBox.ShortcutsEnabled = true;
            this.verAvgTextBox.Size = new System.Drawing.Size(75, 20);
            this.verAvgTextBox.TabIndex = 6;
            this.verAvgTextBox.UseSelectable = true;
            this.verAvgTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.verAvgTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // verAvgLabel
            // 
            this.verAvgLabel.AutoSize = true;
            this.verAvgLabel.Location = new System.Drawing.Point(20, 40);
            this.verAvgLabel.Name = "verAvgLabel";
            this.verAvgLabel.Size = new System.Drawing.Size(115, 19);
            this.verAvgLabel.TabIndex = 5;
            this.verAvgLabel.Text = "Разница средних";
            // 
            // verAvgRadioButton
            // 
            this.verAvgRadioButton.AutoSize = true;
            this.verAvgRadioButton.Checked = true;
            this.verAvgRadioButton.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.verAvgRadioButton.FontWeight = MetroFramework.MetroCheckBoxWeight.Light;
            this.verAvgRadioButton.Location = new System.Drawing.Point(4, 19);
            this.verAvgRadioButton.Margin = new System.Windows.Forms.Padding(2);
            this.verAvgRadioButton.Name = "verAvgRadioButton";
            this.verAvgRadioButton.Size = new System.Drawing.Size(101, 19);
            this.verAvgRadioButton.TabIndex = 4;
            this.verAvgRadioButton.TabStop = true;
            this.verAvgRadioButton.Text = "По средней ";
            this.verAvgRadioButton.UseSelectable = true;
            // 
            // verShareRadioButton
            // 
            this.verShareRadioButton.AutoSize = true;
            this.verShareRadioButton.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.verShareRadioButton.FontWeight = MetroFramework.MetroCheckBoxWeight.Light;
            this.verShareRadioButton.Location = new System.Drawing.Point(5, 71);
            this.verShareRadioButton.Margin = new System.Windows.Forms.Padding(2);
            this.verShareRadioButton.Name = "verShareRadioButton";
            this.verShareRadioButton.Size = new System.Drawing.Size(75, 19);
            this.verShareRadioButton.TabIndex = 4;
            this.verShareRadioButton.Text = "По доле";
            this.verShareRadioButton.UseSelectable = true;
            // 
            // hypothesesButton
            // 
            this.hypothesesButton.Location = new System.Drawing.Point(5, 57);
            this.hypothesesButton.Name = "hypothesesButton";
            this.hypothesesButton.Size = new System.Drawing.Size(275, 32);
            this.hypothesesButton.TabIndex = 10;
            this.hypothesesButton.Text = "Проверить";
            this.hypothesesButton.UseSelectable = true;
            this.hypothesesButton.Click += new System.EventHandler(this.hypothesesButton_Click);
            // 
            // hypothesesGroupBox
            // 
            this.hypothesesGroupBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.hypothesesGroupBox.Controls.Add(this.hypothesesButton);
            this.hypothesesGroupBox.Controls.Add(this.alphaTextBox);
            this.hypothesesGroupBox.Controls.Add(this.metroLabel7);
            this.hypothesesGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.hypothesesGroupBox.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.hypothesesGroupBox.Location = new System.Drawing.Point(324, 506);
            this.hypothesesGroupBox.Margin = new System.Windows.Forms.Padding(2);
            this.hypothesesGroupBox.Name = "hypothesesGroupBox";
            this.hypothesesGroupBox.Padding = new System.Windows.Forms.Padding(2);
            this.hypothesesGroupBox.Size = new System.Drawing.Size(288, 93);
            this.hypothesesGroupBox.TabIndex = 7;
            this.hypothesesGroupBox.TabStop = false;
            this.hypothesesGroupBox.Text = "Проверка гипотез";
            // 
            // alphaTextBox
            // 
            // 
            // 
            // 
            this.alphaTextBox.CustomButton.Image = null;
            this.alphaTextBox.CustomButton.Location = new System.Drawing.Point(44, 2);
            this.alphaTextBox.CustomButton.Name = "";
            this.alphaTextBox.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.alphaTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.alphaTextBox.CustomButton.TabIndex = 1;
            this.alphaTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.alphaTextBox.CustomButton.UseSelectable = true;
            this.alphaTextBox.CustomButton.Visible = false;
            this.alphaTextBox.Lines = new string[0];
            this.alphaTextBox.Location = new System.Drawing.Point(168, 26);
            this.alphaTextBox.MaxLength = 32767;
            this.alphaTextBox.Name = "alphaTextBox";
            this.alphaTextBox.PasswordChar = '\0';
            this.alphaTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.alphaTextBox.SelectedText = "";
            this.alphaTextBox.SelectionLength = 0;
            this.alphaTextBox.SelectionStart = 0;
            this.alphaTextBox.ShortcutsEnabled = true;
            this.alphaTextBox.Size = new System.Drawing.Size(62, 20);
            this.alphaTextBox.TabIndex = 8;
            this.alphaTextBox.UseSelectable = true;
            this.alphaTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.alphaTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.Location = new System.Drawing.Point(5, 26);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(157, 19);
            this.metroLabel7.TabIndex = 7;
            this.metroLabel7.Text = "Уровень значимости (α)";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox3.Controls.Add(this.groupBox7);
            this.groupBox3.Controls.Add(this.groupBox6);
            this.groupBox3.Controls.Add(this.groupBox5);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBox3.Location = new System.Drawing.Point(621, 12);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(381, 587);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Результат расчета оценок";
            // 
            // groupBox7
            // 
            this.groupBox7.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox7.Controls.Add(this.resultCapacityLabel);
            this.groupBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox7.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBox7.Location = new System.Drawing.Point(5, 401);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox7.Size = new System.Drawing.Size(371, 182);
            this.groupBox7.TabIndex = 12;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Объем выборки";
            // 
            // resultCapacityLabel
            // 
            this.resultCapacityLabel.Location = new System.Drawing.Point(5, 17);
            this.resultCapacityLabel.Name = "resultCapacityLabel";
            this.resultCapacityLabel.Size = new System.Drawing.Size(357, 160);
            this.resultCapacityLabel.TabIndex = 9;
            this.resultCapacityLabel.WrapToLine = true;
            this.resultCapacityLabel.Click += new System.EventHandler(this.resultCapacityLabel_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox6.Controls.Add(this.resultBorderLabel);
            this.groupBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox6.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBox6.Location = new System.Drawing.Point(6, 268);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox6.Size = new System.Drawing.Size(371, 109);
            this.groupBox6.TabIndex = 11;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Границы";
            // 
            // resultBorderLabel
            // 
            this.resultBorderLabel.Location = new System.Drawing.Point(5, 19);
            this.resultBorderLabel.Name = "resultBorderLabel";
            this.resultBorderLabel.Size = new System.Drawing.Size(361, 85);
            this.resultBorderLabel.TabIndex = 8;
            this.resultBorderLabel.WrapToLine = true;
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox5.Controls.Add(this.resultVerLabel);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBox5.Location = new System.Drawing.Point(6, 19);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox5.Size = new System.Drawing.Size(371, 227);
            this.groupBox5.TabIndex = 10;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Вероятность";
            // 
            // resultVerLabel
            // 
            this.resultVerLabel.Location = new System.Drawing.Point(5, 20);
            this.resultVerLabel.Name = "resultVerLabel";
            this.resultVerLabel.Size = new System.Drawing.Size(365, 199);
            this.resultVerLabel.TabIndex = 7;
            this.resultVerLabel.WrapToLine = true;
            // 
            // chart1
            // 
            this.chart1.BorderlineColor = System.Drawing.SystemColors.ControlLight;
            this.chart1.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            this.chart1.Location = new System.Drawing.Point(5, 270);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(370, 312);
            this.chart1.TabIndex = 9;
            this.chart1.Text = "chart1";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox4.Controls.Add(this.groupBox10);
            this.groupBox4.Controls.Add(this.groupBox9);
            this.groupBox4.Controls.Add(this.chart1);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBox4.Location = new System.Drawing.Point(1012, 12);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(381, 587);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Результат проверки гипотез";
            // 
            // groupBox10
            // 
            this.groupBox10.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox10.Controls.Add(this.resultKolmogorLabel);
            this.groupBox10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox10.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBox10.Location = new System.Drawing.Point(5, 150);
            this.groupBox10.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox10.Size = new System.Drawing.Size(370, 115);
            this.groupBox10.TabIndex = 12;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "По критерию Колмогорова: ";
            // 
            // resultKolmogorLabel
            // 
            this.resultKolmogorLabel.Location = new System.Drawing.Point(5, 17);
            this.resultKolmogorLabel.Name = "resultKolmogorLabel";
            this.resultKolmogorLabel.Size = new System.Drawing.Size(360, 90);
            this.resultKolmogorLabel.TabIndex = 8;
            this.resultKolmogorLabel.WrapToLine = true;
            // 
            // groupBox9
            // 
            this.groupBox9.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox9.Controls.Add(this.resultPirsonLabel);
            this.groupBox9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox9.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBox9.Location = new System.Drawing.Point(5, 20);
            this.groupBox9.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox9.Size = new System.Drawing.Size(370, 131);
            this.groupBox9.TabIndex = 11;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "По критерию Пирсона: ";
            // 
            // resultPirsonLabel
            // 
            this.resultPirsonLabel.Location = new System.Drawing.Point(5, 17);
            this.resultPirsonLabel.Name = "resultPirsonLabel";
            this.resultPirsonLabel.Size = new System.Drawing.Size(360, 111);
            this.resultPirsonLabel.TabIndex = 7;
            this.resultPirsonLabel.WrapToLine = true;
            // 
            // table
            // 
            this.table.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.table.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.table.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.table.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Interval,
            this.Value});
            this.table.Location = new System.Drawing.Point(5, 20);
            this.table.Name = "table";
            this.table.RowHeadersVisible = false;
            this.table.Size = new System.Drawing.Size(295, 490);
            this.table.TabIndex = 11;
            // 
            // Interval
            // 
            this.Interval.HeaderText = "Интервал";
            this.Interval.Name = "Interval";
            // 
            // Value
            // 
            this.Value.HeaderText = "Значение";
            this.Value.Name = "Value";
            // 
            // groupBox8
            // 
            this.groupBox8.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox8.Controls.Add(this.clearTableButton);
            this.groupBox8.Controls.Add(this.table);
            this.groupBox8.Controls.Add(this.excelButton);
            this.groupBox8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox8.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBox8.Location = new System.Drawing.Point(10, 12);
            this.groupBox8.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox8.Size = new System.Drawing.Size(306, 587);
            this.groupBox8.TabIndex = 13;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Данные";
            // 
            // clearTableButton
            // 
            this.clearTableButton.Location = new System.Drawing.Point(5, 551);
            this.clearTableButton.Margin = new System.Windows.Forms.Padding(2);
            this.clearTableButton.Name = "clearTableButton";
            this.clearTableButton.Size = new System.Drawing.Size(295, 32);
            this.clearTableButton.TabIndex = 12;
            this.clearTableButton.Text = "Очистить таблицу";
            this.clearTableButton.UseSelectable = true;
            this.clearTableButton.Click += new System.EventHandler(this.clearTableButton_Click);
            // 
            // StatisticalEstimatesAndHypothesesControls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.hypothesesGroupBox);
            this.Controls.Add(this.estimatesGroupBox);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "StatisticalEstimatesAndHypothesesControls";
            this.Size = new System.Drawing.Size(1440, 608);
            this.Load += new System.EventHandler(this.StatisticalEstimatesAndHypothesesControls_Load);
            this.estimatesGroupBox.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.verGroupBox.ResumeLayout(false);
            this.verGroupBox.PerformLayout();
            this.hypothesesGroupBox.ResumeLayout(false);
            this.hypothesesGroupBox.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.table)).EndInit();
            this.groupBox8.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Controls.MetroButton excelButton;
        private System.Windows.Forms.GroupBox estimatesGroupBox;
        private System.Windows.Forms.GroupBox verGroupBox;
        private MetroFramework.Controls.MetroRadioButton verAvgRadioButton;
        private MetroFramework.Controls.MetroRadioButton verShareRadioButton;
        private MetroFramework.Controls.MetroLabel verShareThresholdLabel;
        private System.Windows.Forms.ComboBox verShareThresholdComboBox;
        private MetroFramework.Controls.MetroTextBox verShareThresholdTextBox;
        private MetroFramework.Controls.MetroTextBox verShareTextBox;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox verAvgTextBox;
        private MetroFramework.Controls.MetroLabel verAvgLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private MetroFramework.Controls.MetroTextBox bordersIntervalTextBox1;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroTextBox bordersVerTextBox;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroTextBox bordersIntervalTextBox2;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private System.Windows.Forms.GroupBox groupBox2;
        private MetroFramework.Controls.MetroTextBox capacityNTextBox;
        private MetroFramework.Controls.MetroLabel metroLabel9;
        private MetroFramework.Controls.MetroTextBox capacityVerTextBox;
        private MetroFramework.Controls.MetroLabel metroLabel10;
        private MetroFramework.Controls.MetroButton estimatesButton;
        private MetroFramework.Controls.MetroButton hypothesesButton;
        private System.Windows.Forms.GroupBox hypothesesGroupBox;
        private MetroFramework.Controls.MetroTextBox alphaTextBox;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private System.Windows.Forms.GroupBox groupBox3;
        private MetroFramework.Controls.MetroLabel resultCapacityLabel;
        private MetroFramework.Controls.MetroLabel resultBorderLabel;
        private MetroFramework.Controls.MetroLabel resultVerLabel;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.GroupBox groupBox4;
        private MetroFramework.Controls.MetroLabel resultKolmogorLabel;
        private MetroFramework.Controls.MetroLabel resultPirsonLabel;
        private System.Windows.Forms.DataGridView table;
        private System.Windows.Forms.DataGridViewTextBoxColumn Interval;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.GroupBox groupBox10;
        private MetroFramework.Controls.MetroButton clearTableButton;
    }
}
