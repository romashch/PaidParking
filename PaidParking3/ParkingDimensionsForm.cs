using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PaidParking3
{
    public partial class ParkingDimensionsForm : Form
    {
        MainMenuForm form;

        public ParkingDimensionsForm()
        {
            InitializeComponent();
        }

        public ParkingDimensionsForm(MainMenuForm form)
        {
            InitializeComponent();
            this.form = form;
        }

        private void ParkingDimensionsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            form.Show();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            string value0 = lengthTextBox.Text;
            int length, width;
            if (!int.TryParse(value0, out length) || length < 5 || length > 20)
            {
                MessageBox.Show("Некорректное значение размеров парковки.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            value0 = widthTextBox.Text;
            if (!int.TryParse(value0, out width) || width < 5 || width > 15)
            {
                MessageBox.Show("Некорректное значение размеров парковки.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ParkingCreationForm form2 = new ParkingCreationForm(form, this, length, width);
            Hide();
            form2.Show();
        }

        private void ParkingDimensionsForm_Load(object sender, EventArgs e)
        {
            lengthTextBox.Text = "5";
            widthTextBox.Text = "5";
        }
    }
}
