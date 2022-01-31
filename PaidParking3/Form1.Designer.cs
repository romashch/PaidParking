
namespace PaidParking3
{
    partial class SimulationParametersForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dayPriceLabel = new System.Windows.Forms.Label();
            this.nightPriceLabel = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.startTimeHoursTextBox = new System.Windows.Forms.TextBox();
            this.label45 = new System.Windows.Forms.Label();
            this.startTimeMinutesTextBox = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.likelihoodTextBox = new System.Windows.Forms.TextBox();
            this.percentageOfTrucksTextBox = new System.Windows.Forms.TextBox();
            this.dayPriceTextBox = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.distributionLaw2ComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.firstParam2TextBox = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.secondParam2TextBox = new System.Windows.Forms.TextBox();
            this.secondParam2NameLabel = new System.Windows.Forms.Label();
            this.firstParam2NameLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.random2RadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.interval2TextBox = new System.Windows.Forms.TextBox();
            this.interval2Label = new System.Windows.Forms.Label();
            this.deterministic2RadioButton = new System.Windows.Forms.RadioButton();
            this.label11 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.intervalTextBox = new System.Windows.Forms.TextBox();
            this.intervalLabel = new System.Windows.Forms.Label();
            this.deterministicRadioButton = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.distributionLawComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.firstParamTextBox = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.secondParamTextBox = new System.Windows.Forms.TextBox();
            this.secondParamNameLabel = new System.Windows.Forms.Label();
            this.firstParamNameLabel = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.randomRadioButton = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.nightPriceTextBox = new System.Windows.Forms.TextBox();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 8);
            this.label1.MaximumSize = new System.Drawing.Size(110, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Вероятность заезда (0-1)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 43);
            this.label7.MaximumSize = new System.Drawing.Size(150, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 30);
            this.label7.TabIndex = 5;
            this.label7.Text = "Процент грузовых автомобилей (0-100)";
            // 
            // dayPriceLabel
            // 
            this.dayPriceLabel.AutoSize = true;
            this.dayPriceLabel.Location = new System.Drawing.Point(219, 8);
            this.dayPriceLabel.MaximumSize = new System.Drawing.Size(100, 0);
            this.dayPriceLabel.Name = "dayPriceLabel";
            this.dayPriceLabel.Size = new System.Drawing.Size(94, 30);
            this.dayPriceLabel.TabIndex = 10;
            this.dayPriceLabel.Text = "Тариф дневной (000-000)";
            // 
            // nightPriceLabel
            // 
            this.nightPriceLabel.AutoSize = true;
            this.nightPriceLabel.Location = new System.Drawing.Point(219, 43);
            this.nightPriceLabel.MaximumSize = new System.Drawing.Size(120, 0);
            this.nightPriceLabel.Name = "nightPriceLabel";
            this.nightPriceLabel.Size = new System.Drawing.Size(115, 30);
            this.nightPriceLabel.TabIndex = 13;
            this.nightPriceLabel.Text = "Тариф ночной (22:00-6:00, 000-000)";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(13, 474);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(128, 15);
            this.label44.TabIndex = 45;
            this.label44.Text = "Время начала (ч:мин)";
            // 
            // startTimeHoursTextBox
            // 
            this.startTimeHoursTextBox.Location = new System.Drawing.Point(157, 469);
            this.startTimeHoursTextBox.Name = "startTimeHoursTextBox";
            this.startTimeHoursTextBox.Size = new System.Drawing.Size(44, 23);
            this.startTimeHoursTextBox.TabIndex = 46;
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(202, 473);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(10, 15);
            this.label45.TabIndex = 47;
            this.label45.Text = ":";
            // 
            // startTimeMinutesTextBox
            // 
            this.startTimeMinutesTextBox.Location = new System.Drawing.Point(212, 469);
            this.startTimeMinutesTextBox.Name = "startTimeMinutesTextBox";
            this.startTimeMinutesTextBox.Size = new System.Drawing.Size(44, 23);
            this.startTimeMinutesTextBox.TabIndex = 48;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(234, 506);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(129, 26);
            this.saveButton.TabIndex = 49;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(64, 506);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(129, 26);
            this.backButton.TabIndex = 50;
            this.backButton.Text = "Назад";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // likelihoodTextBox
            // 
            this.likelihoodTextBox.Location = new System.Drawing.Point(134, 12);
            this.likelihoodTextBox.Name = "likelihoodTextBox";
            this.likelihoodTextBox.Size = new System.Drawing.Size(70, 23);
            this.likelihoodTextBox.TabIndex = 51;
            // 
            // percentageOfTrucksTextBox
            // 
            this.percentageOfTrucksTextBox.Location = new System.Drawing.Point(134, 48);
            this.percentageOfTrucksTextBox.Name = "percentageOfTrucksTextBox";
            this.percentageOfTrucksTextBox.Size = new System.Drawing.Size(70, 23);
            this.percentageOfTrucksTextBox.TabIndex = 52;
            // 
            // dayPriceTextBox
            // 
            this.dayPriceTextBox.Location = new System.Drawing.Point(338, 12);
            this.dayPriceTextBox.Name = "dayPriceTextBox";
            this.dayPriceTextBox.Size = new System.Drawing.Size(70, 23);
            this.dayPriceTextBox.TabIndex = 53;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.distributionLaw2ComboBox);
            this.groupBox5.Controls.Add(this.groupBox6);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Location = new System.Drawing.Point(183, 36);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(213, 148);
            this.groupBox5.TabIndex = 29;
            this.groupBox5.TabStop = false;
            // 
            // distributionLaw2ComboBox
            // 
            this.distributionLaw2ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.distributionLaw2ComboBox.FormattingEnabled = true;
            this.distributionLaw2ComboBox.Items.AddRange(new object[] {
            "Нормальный",
            "Равномерный",
            "Экспоненциальный"});
            this.distributionLaw2ComboBox.Location = new System.Drawing.Point(6, 30);
            this.distributionLaw2ComboBox.Name = "distributionLaw2ComboBox";
            this.distributionLaw2ComboBox.Size = new System.Drawing.Size(199, 23);
            this.distributionLaw2ComboBox.TabIndex = 26;
            this.distributionLaw2ComboBox.SelectedIndexChanged += new System.EventHandler(this.distributionLaw2ComboBox_SelectedIndexChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.firstParam2TextBox);
            this.groupBox6.Controls.Add(this.panel4);
            this.groupBox6.Controls.Add(this.firstParam2NameLabel);
            this.groupBox6.Controls.Add(this.label5);
            this.groupBox6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox6.Location = new System.Drawing.Point(6, 50);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(199, 92);
            this.groupBox6.TabIndex = 25;
            this.groupBox6.TabStop = false;
            // 
            // firstParam2TextBox
            // 
            this.firstParam2TextBox.Location = new System.Drawing.Point(97, 17);
            this.firstParam2TextBox.Name = "firstParam2TextBox";
            this.firstParam2TextBox.Size = new System.Drawing.Size(91, 23);
            this.firstParam2TextBox.TabIndex = 52;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.secondParam2TextBox);
            this.panel4.Controls.Add(this.secondParam2NameLabel);
            this.panel4.Location = new System.Drawing.Point(6, 46);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(187, 38);
            this.panel4.TabIndex = 51;
            // 
            // secondParam2TextBox
            // 
            this.secondParam2TextBox.Location = new System.Drawing.Point(91, 9);
            this.secondParam2TextBox.Name = "secondParam2TextBox";
            this.secondParam2TextBox.Size = new System.Drawing.Size(91, 23);
            this.secondParam2TextBox.TabIndex = 34;
            // 
            // secondParam2NameLabel
            // 
            this.secondParam2NameLabel.AutoSize = true;
            this.secondParam2NameLabel.Location = new System.Drawing.Point(9, 15);
            this.secondParam2NameLabel.Name = "secondParam2NameLabel";
            this.secondParam2NameLabel.Size = new System.Drawing.Size(68, 15);
            this.secondParam2NameLabel.TabIndex = 33;
            this.secondParam2NameLabel.Text = "ppp (00-00)";
            // 
            // firstParam2NameLabel
            // 
            this.firstParam2NameLabel.AutoSize = true;
            this.firstParam2NameLabel.Location = new System.Drawing.Point(15, 21);
            this.firstParam2NameLabel.Name = "firstParam2NameLabel";
            this.firstParam2NameLabel.Size = new System.Drawing.Size(68, 15);
            this.firstParam2NameLabel.TabIndex = 23;
            this.firstParam2NameLabel.Text = "ppp (00-00)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 15);
            this.label5.TabIndex = 28;
            this.label5.Text = "-1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(40, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(127, 15);
            this.label6.TabIndex = 22;
            this.label6.Text = "Закон распределения";
            // 
            // random2RadioButton
            // 
            this.random2RadioButton.AutoSize = true;
            this.random2RadioButton.Location = new System.Drawing.Point(244, 19);
            this.random2RadioButton.Name = "random2RadioButton";
            this.random2RadioButton.Size = new System.Drawing.Size(86, 19);
            this.random2RadioButton.TabIndex = 20;
            this.random2RadioButton.TabStop = true;
            this.random2RadioButton.Text = "Случайное";
            this.random2RadioButton.UseVisualStyleBackColor = true;
            this.random2RadioButton.CheckedChanged += new System.EventHandler(this.random2RadioButton_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.interval2TextBox);
            this.groupBox4.Controls.Add(this.interval2Label);
            this.groupBox4.Location = new System.Drawing.Point(4, 36);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(173, 148);
            this.groupBox4.TabIndex = 28;
            this.groupBox4.TabStop = false;
            // 
            // interval2TextBox
            // 
            this.interval2TextBox.Location = new System.Drawing.Point(77, 30);
            this.interval2TextBox.Name = "interval2TextBox";
            this.interval2TextBox.Size = new System.Drawing.Size(78, 23);
            this.interval2TextBox.TabIndex = 22;
            // 
            // interval2Label
            // 
            this.interval2Label.AutoSize = true;
            this.interval2Label.Location = new System.Drawing.Point(12, 26);
            this.interval2Label.MaximumSize = new System.Drawing.Size(60, 0);
            this.interval2Label.Name = "interval2Label";
            this.interval2Label.Size = new System.Drawing.Size(60, 30);
            this.interval2Label.TabIndex = 21;
            this.interval2Label.Text = "Интервал (000-000)";
            // 
            // deterministic2RadioButton
            // 
            this.deterministic2RadioButton.AutoSize = true;
            this.deterministic2RadioButton.Location = new System.Drawing.Point(20, 19);
            this.deterministic2RadioButton.Name = "deterministic2RadioButton";
            this.deterministic2RadioButton.Size = new System.Drawing.Size(140, 19);
            this.deterministic2RadioButton.TabIndex = 19;
            this.deterministic2RadioButton.TabStop = true;
            this.deterministic2RadioButton.Text = "Детерминированное";
            this.deterministic2RadioButton.UseVisualStyleBackColor = true;
            this.deterministic2RadioButton.CheckedChanged += new System.EventHandler(this.deterministic2RadioButton_CheckedChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(106, 1);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(166, 15);
            this.label11.TabIndex = 27;
            this.label11.Text = "Время стоянки автомобилей";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox5);
            this.panel2.Controls.Add(this.deterministic2RadioButton);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.random2RadioButton);
            this.panel2.Controls.Add(this.groupBox4);
            this.panel2.Location = new System.Drawing.Point(12, 272);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(398, 191);
            this.panel2.TabIndex = 55;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.intervalTextBox);
            this.groupBox1.Controls.Add(this.intervalLabel);
            this.groupBox1.Location = new System.Drawing.Point(3, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(173, 144);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            // 
            // intervalTextBox
            // 
            this.intervalTextBox.Location = new System.Drawing.Point(77, 27);
            this.intervalTextBox.Name = "intervalTextBox";
            this.intervalTextBox.Size = new System.Drawing.Size(78, 23);
            this.intervalTextBox.TabIndex = 22;
            // 
            // intervalLabel
            // 
            this.intervalLabel.AutoSize = true;
            this.intervalLabel.Location = new System.Drawing.Point(12, 22);
            this.intervalLabel.MaximumSize = new System.Drawing.Size(60, 0);
            this.intervalLabel.Name = "intervalLabel";
            this.intervalLabel.Size = new System.Drawing.Size(60, 30);
            this.intervalLabel.TabIndex = 21;
            this.intervalLabel.Text = "Интервал (000-000)";
            // 
            // deterministicRadioButton
            // 
            this.deterministicRadioButton.AutoSize = true;
            this.deterministicRadioButton.Location = new System.Drawing.Point(16, 25);
            this.deterministicRadioButton.Name = "deterministicRadioButton";
            this.deterministicRadioButton.Size = new System.Drawing.Size(143, 19);
            this.deterministicRadioButton.TabIndex = 19;
            this.deterministicRadioButton.TabStop = true;
            this.deterministicRadioButton.Text = "Детерминированный";
            this.deterministicRadioButton.UseVisualStyleBackColor = true;
            this.deterministicRadioButton.CheckedChanged += new System.EventHandler(this.deterministicRadioButton_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(130, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 15);
            this.label4.TabIndex = 18;
            this.label4.Text = "Транспортный поток";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.distributionLawComboBox);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Location = new System.Drawing.Point(182, 44);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(213, 144);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            // 
            // distributionLawComboBox
            // 
            this.distributionLawComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.distributionLawComboBox.FormattingEnabled = true;
            this.distributionLawComboBox.Items.AddRange(new object[] {
            "Нормальный",
            "Равномерный",
            "Экспоненциальный"});
            this.distributionLawComboBox.Location = new System.Drawing.Point(6, 27);
            this.distributionLawComboBox.Name = "distributionLawComboBox";
            this.distributionLawComboBox.Size = new System.Drawing.Size(199, 23);
            this.distributionLawComboBox.TabIndex = 26;
            this.distributionLawComboBox.SelectedIndexChanged += new System.EventHandler(this.distributionLawComboBox_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.firstParamTextBox);
            this.groupBox3.Controls.Add(this.panel3);
            this.groupBox3.Controls.Add(this.firstParamNameLabel);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox3.Location = new System.Drawing.Point(6, 47);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(199, 92);
            this.groupBox3.TabIndex = 25;
            this.groupBox3.TabStop = false;
            // 
            // firstParamTextBox
            // 
            this.firstParamTextBox.Location = new System.Drawing.Point(97, 17);
            this.firstParamTextBox.Name = "firstParamTextBox";
            this.firstParamTextBox.Size = new System.Drawing.Size(91, 23);
            this.firstParamTextBox.TabIndex = 52;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.secondParamTextBox);
            this.panel3.Controls.Add(this.secondParamNameLabel);
            this.panel3.Location = new System.Drawing.Point(6, 46);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(187, 38);
            this.panel3.TabIndex = 51;
            // 
            // secondParamTextBox
            // 
            this.secondParamTextBox.Location = new System.Drawing.Point(91, 9);
            this.secondParamTextBox.Name = "secondParamTextBox";
            this.secondParamTextBox.Size = new System.Drawing.Size(91, 23);
            this.secondParamTextBox.TabIndex = 34;
            // 
            // secondParamNameLabel
            // 
            this.secondParamNameLabel.AutoSize = true;
            this.secondParamNameLabel.Location = new System.Drawing.Point(9, 15);
            this.secondParamNameLabel.Name = "secondParamNameLabel";
            this.secondParamNameLabel.Size = new System.Drawing.Size(68, 15);
            this.secondParamNameLabel.TabIndex = 33;
            this.secondParamNameLabel.Text = "ppp (00-00)";
            // 
            // firstParamNameLabel
            // 
            this.firstParamNameLabel.AutoSize = true;
            this.firstParamNameLabel.Location = new System.Drawing.Point(15, 21);
            this.firstParamNameLabel.Name = "firstParamNameLabel";
            this.firstParamNameLabel.Size = new System.Drawing.Size(68, 15);
            this.firstParamNameLabel.TabIndex = 23;
            this.firstParamNameLabel.Text = "ppp (00-00)";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(18, 25);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(18, 15);
            this.label18.TabIndex = 28;
            this.label18.Text = "-1";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(40, 10);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(127, 15);
            this.label9.TabIndex = 22;
            this.label9.Text = "Закон распределения";
            // 
            // randomRadioButton
            // 
            this.randomRadioButton.AutoSize = true;
            this.randomRadioButton.Location = new System.Drawing.Point(243, 25);
            this.randomRadioButton.Name = "randomRadioButton";
            this.randomRadioButton.Size = new System.Drawing.Size(89, 19);
            this.randomRadioButton.TabIndex = 20;
            this.randomRadioButton.TabStop = true;
            this.randomRadioButton.Text = "Случайный";
            this.randomRadioButton.UseVisualStyleBackColor = true;
            this.randomRadioButton.CheckedChanged += new System.EventHandler(this.randomRadioButton_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.deterministicRadioButton);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.randomRadioButton);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(13, 75);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(397, 197);
            this.panel1.TabIndex = 54;
            // 
            // nightPriceTextBox
            // 
            this.nightPriceTextBox.Location = new System.Drawing.Point(338, 48);
            this.nightPriceTextBox.Name = "nightPriceTextBox";
            this.nightPriceTextBox.Size = new System.Drawing.Size(70, 23);
            this.nightPriceTextBox.TabIndex = 56;
            // 
            // SimulationParametersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 543);
            this.Controls.Add(this.nightPriceTextBox);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dayPriceTextBox);
            this.Controls.Add(this.percentageOfTrucksTextBox);
            this.Controls.Add(this.likelihoodTextBox);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.startTimeMinutesTextBox);
            this.Controls.Add(this.label45);
            this.Controls.Add(this.startTimeHoursTextBox);
            this.Controls.Add(this.label44);
            this.Controls.Add(this.nightPriceLabel);
            this.Controls.Add(this.dayPriceLabel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(439, 582);
            this.MinimumSize = new System.Drawing.Size(439, 582);
            this.Name = "SimulationParametersForm";
            this.Text = "Параметры моделирования";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label dayPriceLabel;
        private System.Windows.Forms.Label nightPriceLabel;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.TextBox startTimeHoursTextBox;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.TextBox startTimeMinutesTextBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.TextBox likelihoodTextBox;
        private System.Windows.Forms.TextBox percentageOfTrucksTextBox;
        private System.Windows.Forms.TextBox dayPriceTextBox;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox distributionLaw2ComboBox;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox firstParam2TextBox;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox secondParam2TextBox;
        private System.Windows.Forms.Label secondParam2NameLabel;
        private System.Windows.Forms.Label firstParam2NameLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton random2RadioButton;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox interval2TextBox;
        private System.Windows.Forms.RadioButton deterministic2RadioButton;
        private System.Windows.Forms.Label interval2Label;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox intervalTextBox;
        private System.Windows.Forms.Label intervalLabel;
        private System.Windows.Forms.RadioButton deterministicRadioButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox distributionLawComboBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox firstParamTextBox;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox secondParamTextBox;
        private System.Windows.Forms.Label secondParamNameLabel;
        private System.Windows.Forms.Label firstParamNameLabel;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RadioButton randomRadioButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox nightPriceTextBox;
    }
}

