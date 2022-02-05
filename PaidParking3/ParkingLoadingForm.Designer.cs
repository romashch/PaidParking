
namespace PaidParking3
{
    partial class ParkingLoadingForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.backButton = new System.Windows.Forms.Button();
            this.loadingButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Выберите парковку:";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(13, 28);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(381, 199);
            this.listBox1.TabIndex = 1;
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(13, 234);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(117, 28);
            this.backButton.TabIndex = 2;
            this.backButton.Text = "Назад";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // loadingButton
            // 
            this.loadingButton.Location = new System.Drawing.Point(277, 234);
            this.loadingButton.Name = "loadingButton";
            this.loadingButton.Size = new System.Drawing.Size(117, 28);
            this.loadingButton.TabIndex = 3;
            this.loadingButton.Text = "Загрузить";
            this.loadingButton.UseVisualStyleBackColor = true;
            this.loadingButton.Click += new System.EventHandler(this.loadingButton_Click);
            // 
            // ParkingLoadingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 276);
            this.Controls.Add(this.loadingButton);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(422, 315);
            this.MinimumSize = new System.Drawing.Size(422, 315);
            this.Name = "ParkingLoadingForm";
            this.Text = "Загрузка парковки";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ParkingLoadingForm_FormClosing);
            this.Load += new System.EventHandler(this.ParkingLoadingForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button loadingButton;
    }
}