using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PaidParking3
{
    public partial class SaveToDBForm : Form
    {
        Parking parking;

        public SaveToDBForm()
        {
            InitializeComponent();
        }

        public SaveToDBForm(Parking parking)
        {
            InitializeComponent();
            this.parking = parking;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text.Trim();
            //проверить на уникальность имени
            if (name.Length > 0)
            {
                try
                {
                    parking.AddParking(name);
                    Close();
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Введите название парковки.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
