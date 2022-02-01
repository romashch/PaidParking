
namespace PaidParking3
{
    partial class SimulationForm
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
            this.timeLabel = new System.Windows.Forms.Label();
            this.revenueLabel = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ArrivalTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DepartureTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.speedTrackBar = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.pauseButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.fieldPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fieldPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.timeLabel.Location = new System.Drawing.Point(71, 9);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(101, 21);
            this.timeLabel.TabIndex = 0;
            this.timeLabel.Text = "Время: 00:00";
            // 
            // revenueLabel
            // 
            this.revenueLabel.AutoSize = true;
            this.revenueLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.revenueLabel.Location = new System.Drawing.Point(54, 35);
            this.revenueLabel.Name = "revenueLabel";
            this.revenueLabel.Size = new System.Drawing.Size(142, 21);
            this.revenueLabel.TabIndex = 1;
            this.revenueLabel.Text = "Выручка: 0000000";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ArrivalTimeDataGridViewTextBoxColumn,
            this.DepartureTimeDataGridViewTextBoxColumn,
            this.PriceDataGridViewTextBoxColumn});
            this.dataGridView1.Location = new System.Drawing.Point(12, 177);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 40;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(232, 298);
            this.dataGridView1.TabIndex = 2;
            // 
            // ArrivalTimeDataGridViewTextBoxColumn
            // 
            this.ArrivalTimeDataGridViewTextBoxColumn.HeaderText = "t заезда";
            this.ArrivalTimeDataGridViewTextBoxColumn.MinimumWidth = 60;
            this.ArrivalTimeDataGridViewTextBoxColumn.Name = "ArrivalTimeDataGridViewTextBoxColumn";
            this.ArrivalTimeDataGridViewTextBoxColumn.ReadOnly = true;
            this.ArrivalTimeDataGridViewTextBoxColumn.Width = 60;
            // 
            // DepartureTimeDataGridViewTextBoxColumn
            // 
            this.DepartureTimeDataGridViewTextBoxColumn.HeaderText = "t выезда";
            this.DepartureTimeDataGridViewTextBoxColumn.MinimumWidth = 60;
            this.DepartureTimeDataGridViewTextBoxColumn.Name = "DepartureTimeDataGridViewTextBoxColumn";
            this.DepartureTimeDataGridViewTextBoxColumn.ReadOnly = true;
            this.DepartureTimeDataGridViewTextBoxColumn.Width = 60;
            // 
            // PriceDataGridViewTextBoxColumn
            // 
            this.PriceDataGridViewTextBoxColumn.HeaderText = "Стоимость";
            this.PriceDataGridViewTextBoxColumn.MinimumWidth = 70;
            this.PriceDataGridViewTextBoxColumn.Name = "PriceDataGridViewTextBoxColumn";
            this.PriceDataGridViewTextBoxColumn.ReadOnly = true;
            this.PriceDataGridViewTextBoxColumn.Width = 70;
            // 
            // speedTrackBar
            // 
            this.speedTrackBar.Location = new System.Drawing.Point(12, 100);
            this.speedTrackBar.Maximum = 2;
            this.speedTrackBar.Name = "speedTrackBar";
            this.speedTrackBar.Size = new System.Drawing.Size(232, 45);
            this.speedTrackBar.TabIndex = 3;
            this.speedTrackBar.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(97, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Скорость";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "x1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(119, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 15);
            this.label5.TabIndex = 6;
            this.label5.Text = "x2";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(221, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(19, 15);
            this.label6.TabIndex = 7;
            this.label6.Text = "x4";
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(17, 139);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(64, 23);
            this.startButton.TabIndex = 8;
            this.startButton.Text = "Пуск";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // pauseButton
            // 
            this.pauseButton.Location = new System.Drawing.Point(97, 139);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(64, 23);
            this.pauseButton.TabIndex = 9;
            this.pauseButton.Text = "Пауза";
            this.pauseButton.UseVisualStyleBackColor = true;
            this.pauseButton.Click += new System.EventHandler(this.pauseButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(176, 139);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(64, 23);
            this.stopButton.TabIndex = 10;
            this.stopButton.Text = "Стоп";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // fieldPictureBox
            // 
            this.fieldPictureBox.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.fieldPictureBox.Location = new System.Drawing.Point(260, 0);
            this.fieldPictureBox.Name = "fieldPictureBox";
            this.fieldPictureBox.Size = new System.Drawing.Size(225, 225);
            this.fieldPictureBox.TabIndex = 11;
            this.fieldPictureBox.TabStop = false;
            // 
            // SimulationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 493);
            this.Controls.Add(this.fieldPictureBox);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.pauseButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.speedTrackBar);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.revenueLabel);
            this.Controls.Add(this.timeLabel);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(501, 532);
            this.Name = "SimulationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "Моделирование";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SimulationForm_FormClosing);
            this.Load += new System.EventHandler(this.SimulationForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fieldPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Label revenueLabel;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ArrivalTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DepartureTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.TrackBar speedTrackBar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button pauseButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.PictureBox fieldPictureBox;
    }
}