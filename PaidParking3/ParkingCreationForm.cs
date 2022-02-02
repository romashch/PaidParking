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
        PictureBox[,] pictureBoxes;
        List<PictureBox> listPictureBox = new List<PictureBox>();
        bool isTPSDrag = false;

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
            fieldPictureBox.Height = width * 45 + 45;
            Width = fieldPictureBox.Width + 200 + 16;
            Height = 450;
            if (fieldPictureBox.Height > Height)
            {
                Height = fieldPictureBox.Height;
            }
            createPictureBoxesArray();
        }

        private void createPictureBoxesArray()
        {
            pictureBoxes = new PictureBox[width, length];
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    pictureBoxes[i, j] = new PictureBox();
                    pictureBoxes[i, j].Name = "pictureBox_" + j + "_" + i;
                    pictureBoxes[i, j].Location = new Point(j * 45, i * 45);
                    pictureBoxes[i, j].Size = new Size(45, 45);
                    pictureBoxes[i, j].BorderStyle = BorderStyle.FixedSingle;
                    pictureBoxes[i, j].AllowDrop = true;
                    pictureBoxes[i, j].DragDrop += new DragEventHandler(PictureBox_DragDrop);
                    pictureBoxes[i, j].DragEnter += new DragEventHandler(PictureBox_DragEnter);
                    pictureBoxes[i, j].BackgroundImage = Properties.Resources.road;
                    pictureBoxes[i, j].SizeMode = PictureBoxSizeMode.Zoom;
                    fieldPictureBox.Controls.Add(pictureBoxes[i, j]);
                }
            }
        }

        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            if (pictureBox == TPSPictureBox)
            {
                isTPSDrag = true;
            }
            pictureBox.DoDragDrop(pictureBox.Image, DragDropEffects.Copy);
        }

        private void PictureBox_DragDrop(object sender, DragEventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            Image getImage = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            if (isTPSDrag)
            {
                isTPSDrag = false;
                if (pictureBox.Location.Y >= (width - 1) * 45)
                {
                    //добавить в if условие для соседнего TPS/TPS2
                    return;
                }
                pictureBox.Size = new Size(45, 90);
                pictureBox.Click += new EventHandler(PictureBox_Click);
            }
            else
            {
                pictureBox.Size = new Size(45, 45);
                pictureBox.Click -= new EventHandler(PictureBox_Click);
            }
            pictureBox.Image = getImage;
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            if (pictureBox.Size == new Size(45, 90))
            {
                pictureBox.Size = new Size(90, 45);
                pictureBox.Image = Properties.Resources.TPS2;
            }
            else
            {
                pictureBox.Size = new Size(45, 90);
                pictureBox.Image = Properties.Resources.TPS;
            }
        }

        private void PictureBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }
    }
}
