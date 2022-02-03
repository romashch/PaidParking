
namespace PaidParking3
{
    partial class MainMenuForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.aboutProgramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutDevToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parkingCreationButton = new System.Windows.Forms.Button();
            this.parkingLoadingButton = new System.Windows.Forms.Button();
            this.simulationParametersButton = new System.Windows.Forms.Button();
            this.simulationButton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutProgramToolStripMenuItem,
            this.aboutDevToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(273, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // aboutProgramToolStripMenuItem
            // 
            this.aboutProgramToolStripMenuItem.Name = "aboutProgramToolStripMenuItem";
            this.aboutProgramToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.aboutProgramToolStripMenuItem.Text = "О программе";
            // 
            // aboutDevToolStripMenuItem
            // 
            this.aboutDevToolStripMenuItem.Name = "aboutDevToolStripMenuItem";
            this.aboutDevToolStripMenuItem.Size = new System.Drawing.Size(113, 20);
            this.aboutDevToolStripMenuItem.Text = "О разработчиках";
            // 
            // parkingCreationButton
            // 
            this.parkingCreationButton.Location = new System.Drawing.Point(13, 35);
            this.parkingCreationButton.Name = "parkingCreationButton";
            this.parkingCreationButton.Size = new System.Drawing.Size(248, 41);
            this.parkingCreationButton.TabIndex = 1;
            this.parkingCreationButton.Text = "Создать парковку";
            this.parkingCreationButton.UseVisualStyleBackColor = true;
            this.parkingCreationButton.Click += new System.EventHandler(this.parkingCreationButton_Click);
            // 
            // parkingLoadingButton
            // 
            this.parkingLoadingButton.Location = new System.Drawing.Point(12, 82);
            this.parkingLoadingButton.Name = "parkingLoadingButton";
            this.parkingLoadingButton.Size = new System.Drawing.Size(248, 41);
            this.parkingLoadingButton.TabIndex = 2;
            this.parkingLoadingButton.Text = "Загрузить парковку";
            this.parkingLoadingButton.UseVisualStyleBackColor = true;
            this.parkingLoadingButton.Click += new System.EventHandler(this.parkingLoadingButton_Click);
            // 
            // simulationParametersButton
            // 
            this.simulationParametersButton.Location = new System.Drawing.Point(13, 129);
            this.simulationParametersButton.Name = "simulationParametersButton";
            this.simulationParametersButton.Size = new System.Drawing.Size(248, 41);
            this.simulationParametersButton.TabIndex = 3;
            this.simulationParametersButton.Text = "Параметры моделирования";
            this.simulationParametersButton.UseVisualStyleBackColor = true;
            this.simulationParametersButton.Click += new System.EventHandler(this.simulationParametersButton_Click);
            // 
            // simulationButton
            // 
            this.simulationButton.Location = new System.Drawing.Point(12, 176);
            this.simulationButton.Name = "simulationButton";
            this.simulationButton.Size = new System.Drawing.Size(248, 41);
            this.simulationButton.TabIndex = 4;
            this.simulationButton.Text = "Запустить моделирование";
            this.simulationButton.UseVisualStyleBackColor = true;
            this.simulationButton.Click += new System.EventHandler(this.simulationButton_Click);
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 235);
            this.Controls.Add(this.simulationButton);
            this.Controls.Add(this.simulationParametersButton);
            this.Controls.Add(this.parkingLoadingButton);
            this.Controls.Add(this.parkingCreationButton);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(289, 274);
            this.MinimumSize = new System.Drawing.Size(289, 274);
            this.Name = "MainMenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Главное меню";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainMenuForm_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aboutProgramToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutDevToolStripMenuItem;
        private System.Windows.Forms.Button parkingCreationButton;
        private System.Windows.Forms.Button parkingLoadingButton;
        private System.Windows.Forms.Button simulationParametersButton;
        private System.Windows.Forms.Button simulationButton;
    }
}