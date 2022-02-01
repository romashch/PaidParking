using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PaidParking3
{
    public partial class SimulationForm : Form
    {
        MainMenuForm form;
        int length;
        int width;

        public SimulationForm()
        {
            InitializeComponent();
        }

        public SimulationForm(MainMenuForm form, int length, int width)
        {
            InitializeComponent();
            this.form = form;
            this.length = length;
            this.width = width;
        }

        private void SimulationForm_Load(object sender, EventArgs e)
        {
            fieldPictureBox.Width = length * 45;
            fieldPictureBox.Height = width * 45;
            Width = 260 + 16 + fieldPictureBox.Width;
            Height = 532;
            if (Height < fieldPictureBox.Height)
            {
                Height = fieldPictureBox.Height;
            }
        }

        private void SimulationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            form.Show();
        }

        private void startButton_Click(object sender, EventArgs e)
        {

        }

        private void pauseButton_Click(object sender, EventArgs e)
        {

        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
