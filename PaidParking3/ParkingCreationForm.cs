using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PaidParking3
{
    public partial class ParkingCreationForm : Form
    {
        MainMenuForm form;
        ParkingDimensionsForm form2;
        int length;
        int width;

        public ParkingCreationForm()
        {
            InitializeComponent();
        }

        public ParkingCreationForm(MainMenuForm form, ParkingDimensionsForm form2, int length, int width)
        {
            InitializeComponent();
            this.form = form;
            this.form2 = form2;
            this.length = length;
            this.width = width;
        }

        private void ParkingCreationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            form2.Show();
        }

        private void aboutProgramButton_Click(object sender, EventArgs e)
        {
            //файл справки
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            //проверка корректности топологии
            Close();
            form2.Close();
            form.Show();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы уверены, что хотите очистить поле конструирования парковки?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                //очищаем поле
            }            
        }

        private void backToDimensionsButton_Click(object sender, EventArgs e)
        {
            Close();
            form2.Show();
        }

        private void backToMenuButton_Click(object sender, EventArgs e)
        {
            Close();
            form2.Close();
            form.Show();
        }

        private void saveToDBButton_Click(object sender, EventArgs e)
        {
            SaveToDBForm form3 = new SaveToDBForm();
            form3.ShowDialog();
        }

        private void ParkingCreationForm_Load(object sender, EventArgs e)
        {
            fieldPictureBox.Width = length * 45;
            fieldPictureBox.Height = width * 45;
            Width = fieldPictureBox.Width + 200 + 16;
            Height = 450;
            if (fieldPictureBox.Height > Height)
            {
                Height = fieldPictureBox.Height;
            }
        }
    }
}
