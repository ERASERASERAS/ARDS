namespace ASPAP
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.chooseRoadTypeComboBox = new System.Windows.Forms.ComboBox();
            this.label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chooseCountWayComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.chooseStripesCountNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timesSecondParTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.timesFirstParTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chooseTimeTypeComboBox = new System.Windows.Forms.ComboBox();
            this.timeTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.chooseTimeDistributionLawComboBox = new System.Windows.Forms.ComboBox();
            this.speedsSecondParTextBox = new System.Windows.Forms.TextBox();
            this.speedsFirstParTextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.chooseSpeedTypeComboBox = new System.Windows.Forms.ComboBox();
            this.chooseSpeedDistributionLawComboBox = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.speedTextBox = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.trafficLightPictureBox = new System.Windows.Forms.PictureBox();
            this.signPictureBox = new System.Windows.Forms.PictureBox();
            this.label16 = new System.Windows.Forms.Label();
            this.mainPictureBox = new System.Windows.Forms.PictureBox();
            this.drawRoadButton = new System.Windows.Forms.Button();
            this.trafficLightTimer = new System.Windows.Forms.Timer(this.components);
            this.animationTimer = new System.Windows.Forms.Timer(this.components);
            this.generateCarTimer = new System.Windows.Forms.Timer(this.components);
            this.stopButton = new System.Windows.Forms.Button();
            this.resumeButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.labelForCarAppereanceTime = new System.Windows.Forms.Label();
            this.timerForVisibility = new System.Windows.Forms.Timer(this.components);
            this.labelForTrafficLightTime = new System.Windows.Forms.Label();
            this.labelForCarAppereanceValue = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelForTrafficLightValue = new System.Windows.Forms.Label();
            this.labelForSpeedOfFirstCar = new System.Windows.Forms.Label();
            this.firstCarSpeedNumericUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.chooseStripesCountNumericUpDown)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trafficLightPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.signPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.firstCarSpeedNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // chooseRoadTypeComboBox
            // 
            this.chooseRoadTypeComboBox.FormattingEnabled = true;
            this.chooseRoadTypeComboBox.Location = new System.Drawing.Point(15, 40);
            this.chooseRoadTypeComboBox.Name = "chooseRoadTypeComboBox";
            this.chooseRoadTypeComboBox.Size = new System.Drawing.Size(121, 21);
            this.chooseRoadTypeComboBox.TabIndex = 0;
            this.chooseRoadTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.chooseRoadTypeComboBox_SelectedIndexChanged);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(12, 24);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(127, 13);
            this.label.TabIndex = 1;
            this.label.Text = "Выбор типа автодороги";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Выбор количества направлений движения";
            // 
            // chooseCountWayComboBox
            // 
            this.chooseCountWayComboBox.FormattingEnabled = true;
            this.chooseCountWayComboBox.Location = new System.Drawing.Point(15, 80);
            this.chooseCountWayComboBox.Name = "chooseCountWayComboBox";
            this.chooseCountWayComboBox.Size = new System.Drawing.Size(121, 21);
            this.chooseCountWayComboBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Выбор количества полос";
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(12, 526);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 9;
            this.startButton.Text = "Старт";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // chooseStripesCountNumericUpDown
            // 
            this.chooseStripesCountNumericUpDown.Location = new System.Drawing.Point(15, 120);
            this.chooseStripesCountNumericUpDown.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.chooseStripesCountNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.chooseStripesCountNumericUpDown.Name = "chooseStripesCountNumericUpDown";
            this.chooseStripesCountNumericUpDown.Size = new System.Drawing.Size(121, 20);
            this.chooseStripesCountNumericUpDown.TabIndex = 10;
            this.chooseStripesCountNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справкаToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1284, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.оПрограммеToolStripMenuItem});
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // timesSecondParTextBox
            // 
            this.timesSecondParTextBox.Location = new System.Drawing.Point(1237, 182);
            this.timesSecondParTextBox.Name = "timesSecondParTextBox";
            this.timesSecondParTextBox.Size = new System.Drawing.Size(35, 20);
            this.timesSecondParTextBox.TabIndex = 28;
            this.timesSecondParTextBox.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1237, 166);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 27;
            this.label8.Text = "label8";
            this.label8.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1188, 166);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 26;
            this.label7.Text = "label7";
            this.label7.Visible = false;
            // 
            // timesFirstParTextBox
            // 
            this.timesFirstParTextBox.Location = new System.Drawing.Point(1188, 182);
            this.timesFirstParTextBox.Name = "timesFirstParTextBox";
            this.timesFirstParTextBox.Size = new System.Drawing.Size(35, 20);
            this.timesFirstParTextBox.TabIndex = 25;
            this.timesFirstParTextBox.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(1099, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(183, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "ВРЕМЯ ПОЯВЛЕНИЯ МАШИН";
            // 
            // chooseTimeTypeComboBox
            // 
            this.chooseTimeTypeComboBox.FormattingEnabled = true;
            this.chooseTimeTypeComboBox.Location = new System.Drawing.Point(1151, 56);
            this.chooseTimeTypeComboBox.Name = "chooseTimeTypeComboBox";
            this.chooseTimeTypeComboBox.Size = new System.Drawing.Size(121, 21);
            this.chooseTimeTypeComboBox.TabIndex = 23;
            this.chooseTimeTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.chooseTimeTypeComboBox_SelectedIndexChanged);
            // 
            // timeTextBox
            // 
            this.timeTextBox.Location = new System.Drawing.Point(1172, 96);
            this.timeTextBox.Name = "timeTextBox";
            this.timeTextBox.Size = new System.Drawing.Size(100, 20);
            this.timeTextBox.TabIndex = 22;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1194, 80);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Задать время";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(1112, 122);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(160, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "Выбор закона распределения";
            // 
            // chooseTimeDistributionLawComboBox
            // 
            this.chooseTimeDistributionLawComboBox.FormattingEnabled = true;
            this.chooseTimeDistributionLawComboBox.Location = new System.Drawing.Point(1114, 138);
            this.chooseTimeDistributionLawComboBox.Name = "chooseTimeDistributionLawComboBox";
            this.chooseTimeDistributionLawComboBox.Size = new System.Drawing.Size(158, 21);
            this.chooseTimeDistributionLawComboBox.TabIndex = 19;
            this.chooseTimeDistributionLawComboBox.SelectedIndexChanged += new System.EventHandler(this.chooseTimeDistributionLawComboBox_SelectedIndexChanged);
            // 
            // speedsSecondParTextBox
            // 
            this.speedsSecondParTextBox.Location = new System.Drawing.Point(1237, 356);
            this.speedsSecondParTextBox.Name = "speedsSecondParTextBox";
            this.speedsSecondParTextBox.Size = new System.Drawing.Size(35, 20);
            this.speedsSecondParTextBox.TabIndex = 38;
            this.speedsSecondParTextBox.Visible = false;
            // 
            // speedsFirstParTextBox
            // 
            this.speedsFirstParTextBox.Location = new System.Drawing.Point(1188, 356);
            this.speedsFirstParTextBox.Name = "speedsFirstParTextBox";
            this.speedsFirstParTextBox.Size = new System.Drawing.Size(35, 20);
            this.speedsFirstParTextBox.TabIndex = 37;
            this.speedsFirstParTextBox.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(1231, 340);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 13);
            this.label11.TabIndex = 36;
            this.label11.Text = "label11";
            this.label11.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(1188, 340);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 13);
            this.label12.TabIndex = 35;
            this.label12.Text = "label12";
            this.label12.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.Location = new System.Drawing.Point(1149, 221);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(123, 13);
            this.label13.TabIndex = 34;
            this.label13.Text = "СКОРОСТЬ МАШИН";
            // 
            // chooseSpeedTypeComboBox
            // 
            this.chooseSpeedTypeComboBox.FormattingEnabled = true;
            this.chooseSpeedTypeComboBox.Location = new System.Drawing.Point(1151, 237);
            this.chooseSpeedTypeComboBox.Name = "chooseSpeedTypeComboBox";
            this.chooseSpeedTypeComboBox.Size = new System.Drawing.Size(121, 21);
            this.chooseSpeedTypeComboBox.TabIndex = 33;
            this.chooseSpeedTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.chooseSpeedTypeComboBox_SelectedIndexChanged);
            // 
            // chooseSpeedDistributionLawComboBox
            // 
            this.chooseSpeedDistributionLawComboBox.FormattingEnabled = true;
            this.chooseSpeedDistributionLawComboBox.Location = new System.Drawing.Point(1107, 316);
            this.chooseSpeedDistributionLawComboBox.Name = "chooseSpeedDistributionLawComboBox";
            this.chooseSpeedDistributionLawComboBox.Size = new System.Drawing.Size(165, 21);
            this.chooseSpeedDistributionLawComboBox.TabIndex = 32;
            this.chooseSpeedDistributionLawComboBox.SelectedIndexChanged += new System.EventHandler(this.chooseSpeedDistributionLawComboBox_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(1107, 300);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(165, 13);
            this.label14.TabIndex = 31;
            this.label14.Text = "Выбрать закон распределения";
            // 
            // speedTextBox
            // 
            this.speedTextBox.Location = new System.Drawing.Point(1172, 277);
            this.speedTextBox.Name = "speedTextBox";
            this.speedTextBox.Size = new System.Drawing.Size(100, 20);
            this.speedTextBox.TabIndex = 30;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(1179, 261);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(93, 13);
            this.label15.TabIndex = 29;
            this.label15.Text = "Задать скорость";
            // 
            // trafficLightPictureBox
            // 
            this.trafficLightPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("trafficLightPictureBox.Image")));
            this.trafficLightPictureBox.Location = new System.Drawing.Point(1222, 405);
            this.trafficLightPictureBox.Name = "trafficLightPictureBox";
            this.trafficLightPictureBox.Size = new System.Drawing.Size(50, 50);
            this.trafficLightPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.trafficLightPictureBox.TabIndex = 40;
            this.trafficLightPictureBox.TabStop = false;
            this.trafficLightPictureBox.Click += new System.EventHandler(this.trafficLightPictureBox_Click);
            // 
            // signPictureBox
            // 
            this.signPictureBox.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.signPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("signPictureBox.Image")));
            this.signPictureBox.Location = new System.Drawing.Point(1222, 461);
            this.signPictureBox.Name = "signPictureBox";
            this.signPictureBox.Size = new System.Drawing.Size(50, 50);
            this.signPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.signPictureBox.TabIndex = 41;
            this.signPictureBox.TabStop = false;
            this.signPictureBox.Click += new System.EventHandler(this.signPictureBox_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(1158, 379);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(114, 13);
            this.label16.TabIndex = 42;
            this.label16.Text = "Панель инсрументов";
            // 
            // mainPictureBox
            // 
            this.mainPictureBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.mainPictureBox.Location = new System.Drawing.Point(241, 34);
            this.mainPictureBox.Name = "mainPictureBox";
            this.mainPictureBox.Size = new System.Drawing.Size(852, 477);
            this.mainPictureBox.TabIndex = 43;
            this.mainPictureBox.TabStop = false;
            this.mainPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.mainPictureBox_Paint);
            this.mainPictureBox.MouseLeave += new System.EventHandler(this.mainPictureBox_MouseLeave);
            this.mainPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mainPictureBox_MouseMove);
            // 
            // drawRoadButton
            // 
            this.drawRoadButton.Location = new System.Drawing.Point(12, 160);
            this.drawRoadButton.Name = "drawRoadButton";
            this.drawRoadButton.Size = new System.Drawing.Size(120, 24);
            this.drawRoadButton.TabIndex = 44;
            this.drawRoadButton.Text = "Нарисовать дорогу";
            this.drawRoadButton.UseVisualStyleBackColor = true;
            this.drawRoadButton.Click += new System.EventHandler(this.drawRoadButton_Click);
            // 
            // trafficLightTimer
            // 
            this.trafficLightTimer.Interval = 1;
            this.trafficLightTimer.Tick += new System.EventHandler(this.trafficLightTimer_Tick);
            // 
            // animationTimer
            // 
            this.animationTimer.Tick += new System.EventHandler(this.animationTimer_Tick);
            // 
            // generateCarTimer
            // 
            this.generateCarTimer.Tick += new System.EventHandler(this.generateCarTimer_Tick);
            // 
            // stopButton
            // 
            this.stopButton.Enabled = false;
            this.stopButton.Location = new System.Drawing.Point(241, 526);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 23);
            this.stopButton.TabIndex = 45;
            this.stopButton.Text = "Стоп";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Visible = false;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // resumeButton
            // 
            this.resumeButton.Enabled = false;
            this.resumeButton.Location = new System.Drawing.Point(241, 526);
            this.resumeButton.Name = "resumeButton";
            this.resumeButton.Size = new System.Drawing.Size(82, 23);
            this.resumeButton.TabIndex = 46;
            this.resumeButton.Text = "Продолжить";
            this.resumeButton.UseVisualStyleBackColor = true;
            this.resumeButton.Visible = false;
            this.resumeButton.Click += new System.EventHandler(this.resumeButton_Click);
            // 
            // resetButton
            // 
            this.resetButton.Enabled = false;
            this.resetButton.Location = new System.Drawing.Point(357, 526);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(79, 23);
            this.resetButton.TabIndex = 47;
            this.resetButton.Text = "Сбросить";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Visible = false;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // labelForCarAppereanceTime
            // 
            this.labelForCarAppereanceTime.AutoSize = true;
            this.labelForCarAppereanceTime.Location = new System.Drawing.Point(503, 531);
            this.labelForCarAppereanceTime.Name = "labelForCarAppereanceTime";
            this.labelForCarAppereanceTime.Size = new System.Drawing.Size(163, 13);
            this.labelForCarAppereanceTime.TabIndex = 48;
            this.labelForCarAppereanceTime.Text = "Время до появления машины: ";
            this.labelForCarAppereanceTime.Visible = false;
            // 
            // timerForVisibility
            // 
            this.timerForVisibility.Tick += new System.EventHandler(this.timerForVisibility_Tick);
            // 
            // labelForTrafficLightTime
            // 
            this.labelForTrafficLightTime.AutoSize = true;
            this.labelForTrafficLightTime.Location = new System.Drawing.Point(745, 531);
            this.labelForTrafficLightTime.Name = "labelForTrafficLightTime";
            this.labelForTrafficLightTime.Size = new System.Drawing.Size(142, 13);
            this.labelForTrafficLightTime.TabIndex = 49;
            this.labelForTrafficLightTime.Text = "Время до смены сигнала: ";
            this.labelForTrafficLightTime.Visible = false;
            // 
            // labelForCarAppereanceValue
            // 
            this.labelForCarAppereanceValue.AutoSize = true;
            this.labelForCarAppereanceValue.Location = new System.Drawing.Point(672, 531);
            this.labelForCarAppereanceValue.Name = "labelForCarAppereanceValue";
            this.labelForCarAppereanceValue.Size = new System.Drawing.Size(35, 13);
            this.labelForCarAppereanceValue.TabIndex = 50;
            this.labelForCarAppereanceValue.Text = "label3";
            this.labelForCarAppereanceValue.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(909, 531);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 51;
            // 
            // labelForTrafficLightValue
            // 
            this.labelForTrafficLightValue.AutoSize = true;
            this.labelForTrafficLightValue.Location = new System.Drawing.Point(893, 531);
            this.labelForTrafficLightValue.Name = "labelForTrafficLightValue";
            this.labelForTrafficLightValue.Size = new System.Drawing.Size(35, 13);
            this.labelForTrafficLightValue.TabIndex = 52;
            this.labelForTrafficLightValue.Text = "label5";
            this.labelForTrafficLightValue.Visible = false;
            // 
            // labelForSpeedOfFirstCar
            // 
            this.labelForSpeedOfFirstCar.AutoSize = true;
            this.labelForSpeedOfFirstCar.Location = new System.Drawing.Point(9, 202);
            this.labelForSpeedOfFirstCar.Name = "labelForSpeedOfFirstCar";
            this.labelForSpeedOfFirstCar.Size = new System.Drawing.Size(192, 13);
            this.labelForSpeedOfFirstCar.TabIndex = 53;
            this.labelForSpeedOfFirstCar.Text = "Скорость первой машины в тоннеле";
            // 
            // firstCarSpeedNumericUpDown
            // 
            this.firstCarSpeedNumericUpDown.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.firstCarSpeedNumericUpDown.Location = new System.Drawing.Point(12, 221);
            this.firstCarSpeedNumericUpDown.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.firstCarSpeedNumericUpDown.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.firstCarSpeedNumericUpDown.Name = "firstCarSpeedNumericUpDown";
            this.firstCarSpeedNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.firstCarSpeedNumericUpDown.TabIndex = 54;
            this.firstCarSpeedNumericUpDown.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.firstCarSpeedNumericUpDown.ValueChanged += new System.EventHandler(this.firstCarSpeedNumericUpDown_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1284, 557);
            this.Controls.Add(this.firstCarSpeedNumericUpDown);
            this.Controls.Add(this.labelForSpeedOfFirstCar);
            this.Controls.Add(this.labelForTrafficLightValue);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelForCarAppereanceValue);
            this.Controls.Add(this.labelForTrafficLightTime);
            this.Controls.Add(this.labelForCarAppereanceTime);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.resumeButton);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.drawRoadButton);
            this.Controls.Add(this.mainPictureBox);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.signPictureBox);
            this.Controls.Add(this.trafficLightPictureBox);
            this.Controls.Add(this.speedsSecondParTextBox);
            this.Controls.Add(this.speedsFirstParTextBox);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.chooseSpeedTypeComboBox);
            this.Controls.Add(this.chooseSpeedDistributionLawComboBox);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.speedTextBox);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.timesSecondParTextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.timesFirstParTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.chooseTimeTypeComboBox);
            this.Controls.Add(this.timeTextBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.chooseTimeDistributionLawComboBox);
            this.Controls.Add(this.chooseStripesCountNumericUpDown);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chooseCountWayComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label);
            this.Controls.Add(this.chooseRoadTypeComboBox);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1300, 596);
            this.MinimumSize = new System.Drawing.Size(1300, 596);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "АСПАП";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.chooseStripesCountNumericUpDown)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trafficLightPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.signPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.firstCarSpeedNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox chooseRoadTypeComboBox;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox chooseCountWayComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.NumericUpDown chooseStripesCountNumericUpDown;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.TextBox timesSecondParTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox timesFirstParTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox chooseTimeTypeComboBox;
        private System.Windows.Forms.TextBox timeTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox chooseTimeDistributionLawComboBox;
        private System.Windows.Forms.TextBox speedsSecondParTextBox;
        private System.Windows.Forms.TextBox speedsFirstParTextBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox chooseSpeedTypeComboBox;
        private System.Windows.Forms.ComboBox chooseSpeedDistributionLawComboBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox speedTextBox;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.PictureBox trafficLightPictureBox;
        private System.Windows.Forms.PictureBox signPictureBox;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.PictureBox mainPictureBox;
        private System.Windows.Forms.Button drawRoadButton;
        private System.Windows.Forms.Timer trafficLightTimer;
        private System.Windows.Forms.Timer animationTimer;
        private System.Windows.Forms.Timer generateCarTimer;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button resumeButton;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Label labelForCarAppereanceTime;
        private System.Windows.Forms.Timer timerForVisibility;
        private System.Windows.Forms.Label labelForTrafficLightTime;
        private System.Windows.Forms.Label labelForCarAppereanceValue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelForTrafficLightValue;
        private System.Windows.Forms.Label labelForSpeedOfFirstCar;
        private System.Windows.Forms.NumericUpDown firstCarSpeedNumericUpDown;
    }
}

