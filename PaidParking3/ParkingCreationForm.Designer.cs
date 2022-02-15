
namespace PaidParking3
{
    partial class ParkingCreationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ParkingCreationForm));
            this.TPSPictureBox = new System.Windows.Forms.PictureBox();
            this.CPSPictureBox = new System.Windows.Forms.PictureBox();
            this.entryPictureBox = new System.Windows.Forms.PictureBox();
            this.exitPictureBox = new System.Windows.Forms.PictureBox();
            this.ticketOfficePictureBox = new System.Windows.Forms.PictureBox();
            this.lawnPictureBox = new System.Windows.Forms.PictureBox();
            this.aboutProgramButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.backToDimensionsButton = new System.Windows.Forms.Button();
            this.backToMenuButton = new System.Windows.Forms.Button();
            this.saveToDBButton = new System.Windows.Forms.Button();
            this.fieldPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.TPSPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CPSPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.entryPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exitPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ticketOfficePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lawnPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fieldPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // TPSPictureBox
            // 
            this.TPSPictureBox.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.TPSPictureBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("TPSPictureBox.BackgroundImage")));
            this.TPSPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.TPSPictureBox.Image = global::PaidParking3.Properties.Resources.TPS2;
            this.TPSPictureBox.ImageLocation = "";
            this.TPSPictureBox.Location = new System.Drawing.Point(18, 58);
            this.TPSPictureBox.Name = "TPSPictureBox";
            this.TPSPictureBox.Size = new System.Drawing.Size(44, 88);
            this.TPSPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.TPSPictureBox.TabIndex = 0;
            this.TPSPictureBox.TabStop = false;
            this.TPSPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBox_MouseDown);
            // 
            // CPSPictureBox
            // 
            this.CPSPictureBox.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.CPSPictureBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CPSPictureBox.BackgroundImage")));
            this.CPSPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.CPSPictureBox.Image = global::PaidParking3.Properties.Resources.CPS2;
            this.CPSPictureBox.ImageLocation = "";
            this.CPSPictureBox.Location = new System.Drawing.Point(75, 58);
            this.CPSPictureBox.Name = "CPSPictureBox";
            this.CPSPictureBox.Size = new System.Drawing.Size(44, 44);
            this.CPSPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.CPSPictureBox.TabIndex = 1;
            this.CPSPictureBox.TabStop = false;
            this.CPSPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBox_MouseDown);
            // 
            // entryPictureBox
            // 
            this.entryPictureBox.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.entryPictureBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("entryPictureBox.BackgroundImage")));
            this.entryPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.entryPictureBox.Image = global::PaidParking3.Properties.Resources.entry;
            this.entryPictureBox.ImageLocation = "";
            this.entryPictureBox.Location = new System.Drawing.Point(131, 58);
            this.entryPictureBox.Name = "entryPictureBox";
            this.entryPictureBox.Size = new System.Drawing.Size(44, 44);
            this.entryPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.entryPictureBox.TabIndex = 2;
            this.entryPictureBox.TabStop = false;
            this.entryPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBox_MouseDown);
            // 
            // exitPictureBox
            // 
            this.exitPictureBox.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.exitPictureBox.BackgroundImage = global::PaidParking3.Properties.Resources.road;
            this.exitPictureBox.Image = global::PaidParking3.Properties.Resources.exit;
            this.exitPictureBox.ImageLocation = "";
            this.exitPictureBox.Location = new System.Drawing.Point(75, 114);
            this.exitPictureBox.Name = "exitPictureBox";
            this.exitPictureBox.Size = new System.Drawing.Size(44, 44);
            this.exitPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.exitPictureBox.TabIndex = 3;
            this.exitPictureBox.TabStop = false;
            this.exitPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBox_MouseDown);
            // 
            // ticketOfficePictureBox
            // 
            this.ticketOfficePictureBox.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ticketOfficePictureBox.BackgroundImage = global::PaidParking3.Properties.Resources.road;
            this.ticketOfficePictureBox.Image = global::PaidParking3.Properties.Resources.ticketOffice;
            this.ticketOfficePictureBox.ImageLocation = "";
            this.ticketOfficePictureBox.Location = new System.Drawing.Point(131, 114);
            this.ticketOfficePictureBox.Name = "ticketOfficePictureBox";
            this.ticketOfficePictureBox.Size = new System.Drawing.Size(44, 44);
            this.ticketOfficePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ticketOfficePictureBox.TabIndex = 4;
            this.ticketOfficePictureBox.TabStop = false;
            this.ticketOfficePictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBox_MouseDown);
            // 
            // lawnPictureBox
            // 
            this.lawnPictureBox.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lawnPictureBox.BackgroundImage = global::PaidParking3.Properties.Resources.road;
            this.lawnPictureBox.Image = global::PaidParking3.Properties.Resources.lawn;
            this.lawnPictureBox.ImageLocation = "";
            this.lawnPictureBox.Location = new System.Drawing.Point(18, 161);
            this.lawnPictureBox.Name = "lawnPictureBox";
            this.lawnPictureBox.Size = new System.Drawing.Size(44, 44);
            this.lawnPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.lawnPictureBox.TabIndex = 5;
            this.lawnPictureBox.TabStop = false;
            this.lawnPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBox_MouseDown);
            // 
            // aboutProgramButton
            // 
            this.aboutProgramButton.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.aboutProgramButton.Location = new System.Drawing.Point(18, 13);
            this.aboutProgramButton.Name = "aboutProgramButton";
            this.aboutProgramButton.Size = new System.Drawing.Size(35, 35);
            this.aboutProgramButton.TabIndex = 6;
            this.aboutProgramButton.Text = "?";
            this.aboutProgramButton.UseVisualStyleBackColor = true;
            this.aboutProgramButton.Click += new System.EventHandler(this.aboutProgramButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(16, 224);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(163, 29);
            this.saveButton.TabIndex = 7;
            this.saveButton.Text = "Проверить и сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(16, 259);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(163, 29);
            this.clearButton.TabIndex = 8;
            this.clearButton.Text = "Очистить";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // backToDimensionsButton
            // 
            this.backToDimensionsButton.Location = new System.Drawing.Point(16, 294);
            this.backToDimensionsButton.Name = "backToDimensionsButton";
            this.backToDimensionsButton.Size = new System.Drawing.Size(78, 56);
            this.backToDimensionsButton.TabIndex = 9;
            this.backToDimensionsButton.Text = "Назад к размерам парковки";
            this.backToDimensionsButton.UseVisualStyleBackColor = true;
            this.backToDimensionsButton.Click += new System.EventHandler(this.backToDimensionsButton_Click);
            // 
            // backToMenuButton
            // 
            this.backToMenuButton.Location = new System.Drawing.Point(101, 294);
            this.backToMenuButton.Name = "backToMenuButton";
            this.backToMenuButton.Size = new System.Drawing.Size(78, 56);
            this.backToMenuButton.TabIndex = 10;
            this.backToMenuButton.Text = "Назад в главное меню";
            this.backToMenuButton.UseVisualStyleBackColor = true;
            this.backToMenuButton.Click += new System.EventHandler(this.backToMenuButton_Click);
            // 
            // saveToDBButton
            // 
            this.saveToDBButton.Location = new System.Drawing.Point(16, 356);
            this.saveToDBButton.Name = "saveToDBButton";
            this.saveToDBButton.Size = new System.Drawing.Size(163, 29);
            this.saveToDBButton.TabIndex = 11;
            this.saveToDBButton.Text = "Сохранить в базе данных";
            this.saveToDBButton.UseVisualStyleBackColor = true;
            this.saveToDBButton.Click += new System.EventHandler(this.saveToDBButton_Click);
            // 
            // fieldPictureBox
            // 
            this.fieldPictureBox.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.fieldPictureBox.BackgroundImage = global::PaidParking3.Properties.Resources.road;
            this.fieldPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.fieldPictureBox.Location = new System.Drawing.Point(200, 0);
            this.fieldPictureBox.Name = "fieldPictureBox";
            this.fieldPictureBox.Size = new System.Drawing.Size(225, 450);
            this.fieldPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.fieldPictureBox.TabIndex = 12;
            this.fieldPictureBox.TabStop = false;
            // 
            // ParkingCreationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 450);
            this.Controls.Add(this.fieldPictureBox);
            this.Controls.Add(this.saveToDBButton);
            this.Controls.Add(this.backToMenuButton);
            this.Controls.Add(this.backToDimensionsButton);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.aboutProgramButton);
            this.Controls.Add(this.lawnPictureBox);
            this.Controls.Add(this.ticketOfficePictureBox);
            this.Controls.Add(this.exitPictureBox);
            this.Controls.Add(this.entryPictureBox);
            this.Controls.Add(this.CPSPictureBox);
            this.Controls.Add(this.TPSPictureBox);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(441, 444);
            this.Name = "ParkingCreationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "Конструирование";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ParkingCreationForm_FormClosing);
            this.Load += new System.EventHandler(this.ParkingCreationForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TPSPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CPSPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.entryPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exitPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ticketOfficePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lawnPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fieldPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox TPSPictureBox;
        private System.Windows.Forms.PictureBox CPSPictureBox;
        private System.Windows.Forms.PictureBox entryPictureBox;
        private System.Windows.Forms.PictureBox exitPictureBox;
        private System.Windows.Forms.PictureBox ticketOfficePictureBox;
        private System.Windows.Forms.PictureBox lawnPictureBox;
        private System.Windows.Forms.Button aboutProgramButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button backToDimensionsButton;
        private System.Windows.Forms.Button backToMenuButton;
        private System.Windows.Forms.Button saveToDBButton;
        private System.Windows.Forms.PictureBox fieldPictureBox;
    }
}