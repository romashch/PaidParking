using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using static PaidParking3.Parking;

namespace PaidParking3
{
    public partial class ParkingCreationForm : Form
    {
        MainMenuForm form;
        ParkingDimensionsForm form2;
        int length;
        int width;
        PictureBox[,] pictureBoxes;
        Sample[,] topology;
        Sample current;

        Parking parking;

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
            parking = form.Parking;
            if (parking != null && length == parking.Length && width == parking.Width)
            {
                topology = parking.Topology;
            }
            else
            {
                parking = null;
                topology = new Sample[width, length];
                for (int i = 0; i < topology.GetLength(0); i++)
                    for (int j = 0; j < topology.GetLength(1); j++)
                        topology[i, j] = Sample.Road;
            }
        }

        private void ParkingCreationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            form2.Show();
        }

        private void aboutProgramButton_Click(object sender, EventArgs e)
        {
            MainMenuForm.OpenHelpFile();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            parking = Validation(topology);
            if (parking == null)
            {
                MessageBox.Show("Некорректная парковка.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                saveToDBButton.Enabled = false;
            }
            else
            {
                MessageBox.Show("Парковка успешно сохранена.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                saveToDBButton.Enabled = true;
                form.Parking = parking;
                parking.Serialize();
                //parking.DijkstrasAlgorithmWithWays();
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы уверены, что хотите очистить поле конструирования парковки?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                saveToDBButton.Enabled = false;
                entryPictureBox.Image = Properties.Resources.entry;
                entryPictureBox.MouseDown += new MouseEventHandler(PictureBox_MouseDown);
                exitPictureBox.Image = Properties.Resources.exit;
                exitPictureBox.MouseDown += new MouseEventHandler(PictureBox_MouseDown);
                ticketOfficePictureBox.Image = Properties.Resources.ticketOffice;
                ticketOfficePictureBox.MouseDown += new MouseEventHandler(PictureBox_MouseDown);
                foreach (PictureBox pictureBox in pictureBoxes)
                {
                    if (pictureBox.Size == new Size(45, 90))
                    {
                        pictureBox.Size = new Size(45, 45);
                    }
                    pictureBox.Image = null;
                    topology[pictureBox.Location.Y / 45, pictureBox.Location.X / 45] = Sample.Road;
                }
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
            SaveToDBForm form3 = new SaveToDBForm(parking);
            form3.ShowDialog();
        }

        private void ParkingCreationForm_Load(object sender, EventArgs e)
        {
            fieldPictureBox.Width = length * 45;
            fieldPictureBox.Height = width * 45 + 45;
            Width = fieldPictureBox.Width + 200 + 16;
            Height = 399;
            if (fieldPictureBox.Height + 39 > Height)
            {
                Height = fieldPictureBox.Height + 39;
            }
            createPictureBoxesArray();
            if (parking != null)
            {
                drawParking();
                saveToDBButton.Enabled = true;
            }
            else
                saveToDBButton.Enabled = false;
        }

        private void drawParking()
        {
            for (int i = 0; i < topology.GetLength(0); i++)
            {
                for (int j = 0; j < topology.GetLength(1); j++)
                {
                    if (topology[i, j] == Sample.TPS)
                    {
                        pictureBoxes[i, j].Size = new Size(45, 90);
                        pictureBoxes[i, j].Image = Properties.Resources.TPS;
                    }
                    else if (topology[i, j] == Sample.Entry)
                    {
                        pictureBoxes[i, j].Image = Properties.Resources.entry;
                        entryPictureBox.Image = null;
                        entryPictureBox.MouseDown -= new MouseEventHandler(PictureBox_MouseDown);
                    }
                    else if (topology[i, j] == Sample.Exit)
                    {
                        pictureBoxes[i, j].Image = Properties.Resources.exit;
                        exitPictureBox.Image = null;
                        exitPictureBox.MouseDown -= new MouseEventHandler(PictureBox_MouseDown);
                    }
                    else if (topology[i, j] == Sample.TicketOffice)
                    {
                        pictureBoxes[i, j].Image = Properties.Resources.ticketOffice;
                        ticketOfficePictureBox.Image = null;
                        ticketOfficePictureBox.MouseDown -= new MouseEventHandler(PictureBox_MouseDown);
                    }
                    else if (topology[i, j] == Sample.CPS)
                    {
                        pictureBoxes[i, j].Image = Properties.Resources.CPS;
                    }
                    else if (topology[i, j] == Sample.Lawn)
                    {
                        pictureBoxes[i, j].Image = Properties.Resources.lawn;
                    }
                    ticketOfficePictureBox.MouseDown += new MouseEventHandler(PictureBox_MouseDown);
                }
            }
        }

        private void createPictureBoxesArray()
        {
            pictureBoxes = new PictureBox[width, length];
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    pictureBoxes[i, j] = new PictureBox();
                    pictureBoxes[i, j].Location = new Point(j * 45, i * 45);
                    pictureBoxes[i, j].Size = new Size(45, 45);
                    pictureBoxes[i, j].BorderStyle = BorderStyle.FixedSingle;
                    pictureBoxes[i, j].AllowDrop = true;
                    pictureBoxes[i, j].DragDrop += new DragEventHandler(PictureBox_DragDrop);
                    pictureBoxes[i, j].DragEnter += new DragEventHandler(PictureBox_DragEnter);
                    pictureBoxes[i, j].BackgroundImage = Properties.Resources.road;
                    pictureBoxes[i, j].SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBoxes[i, j].DoubleClick += new EventHandler(PictureBox_DoubleClick);
                    fieldPictureBox.Controls.Add(pictureBoxes[i, j]);
                }
            }
        }

        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            if (pictureBox == TPSPictureBox)
            {
                current = Sample.TPS;
            }
            else if (pictureBox == CPSPictureBox)
            {
                current = Sample.CPS;
            }
            else if (pictureBox == entryPictureBox)
            {
                current = Sample.Entry;
            }
            else if (pictureBox == exitPictureBox)
            {
                current = Sample.Exit;
            }
            else if (pictureBox == ticketOfficePictureBox)
            {
                current = Sample.TicketOffice;
            }
            else if (pictureBox == lawnPictureBox)
            {
                current = Sample.Lawn;
            }
            pictureBox.DoDragDrop(pictureBox.Image, DragDropEffects.Copy);
        }

        private void PictureBox_DragDrop(object sender, DragEventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            Sample deleteSample = topology[pictureBox.Location.Y / 45, pictureBox.Location.X / 45];
            Image getImage = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            if (deleteSample == Sample.TPS)
            {
                pictureBox.Size = new Size(45, 45);
                topology[pictureBox.Location.Y / 45 + 1, pictureBox.Location.X / 45] = Sample.Road;
            }
            else if (deleteSample == Sample.Entry)
            {
                entryPictureBox.Image = Properties.Resources.entry;
                entryPictureBox.MouseDown += new MouseEventHandler(PictureBox_MouseDown);
            }
            else if (deleteSample == Sample.Exit)
            {
                exitPictureBox.Image = Properties.Resources.exit;
                exitPictureBox.MouseDown += new MouseEventHandler(PictureBox_MouseDown);
            }
            else if (deleteSample == Sample.TicketOffice)
            {
                ticketOfficePictureBox.Image = Properties.Resources.ticketOffice;
                ticketOfficePictureBox.MouseDown += new MouseEventHandler(PictureBox_MouseDown);
            }
            if (current == Sample.TPS)
            {
                if (pictureBox.Location.Y >= (width - 1) * 45 || topology[pictureBox.Location.Y / 45 + 1, pictureBox.Location.X / 45] == Sample.TPS)
                {
                    return;
                }
                pictureBox.Size = new Size(45, 90);
                topology[pictureBox.Location.Y / 45 + 1, pictureBox.Location.X / 45] = Sample.None;
            }
            else if (current == Sample.Entry)
            {
                entryPictureBox.Image = null;
                entryPictureBox.MouseDown -= new MouseEventHandler(PictureBox_MouseDown);
            }
            else if (current == Sample.Exit)
            {
                exitPictureBox.Image = null;
                exitPictureBox.MouseDown -= new MouseEventHandler(PictureBox_MouseDown);
            }
            else if (current == Sample.TicketOffice)
            {
                ticketOfficePictureBox.Image = null;
                ticketOfficePictureBox.MouseDown -= new MouseEventHandler(PictureBox_MouseDown);
            }
            pictureBox.Image = getImage;
            topology[pictureBox.Location.Y / 45, pictureBox.Location.X / 45] = current;
            saveToDBButton.Enabled = false;
        }

        private void PictureBox_DoubleClick(object sender, EventArgs e)
        {
            saveToDBButton.Enabled = false;
            PictureBox pictureBox = (PictureBox)sender;
            Sample deleteSample = topology[pictureBox.Location.Y / 45, pictureBox.Location.X / 45];
            if (deleteSample == Sample.TPS)
            {
                pictureBox.Size = new Size(45, 45);
                topology[pictureBox.Location.Y / 45 + 1, pictureBox.Location.X / 45] = Sample.Road;
            }
            else if (deleteSample == Sample.Entry)
            {
                entryPictureBox.Image = Properties.Resources.entry;
                entryPictureBox.MouseDown += new MouseEventHandler(PictureBox_MouseDown);
            }
            else if (deleteSample == Sample.Exit)
            {
                exitPictureBox.Image = Properties.Resources.exit;
                exitPictureBox.MouseDown += new MouseEventHandler(PictureBox_MouseDown);
            }
            else if (deleteSample == Sample.TicketOffice)
            {
                ticketOfficePictureBox.Image = Properties.Resources.ticketOffice;
                ticketOfficePictureBox.MouseDown += new MouseEventHandler(PictureBox_MouseDown);
            }
            pictureBox.Image = null;
            topology[pictureBox.Location.Y / 45, pictureBox.Location.X / 45] = Sample.Road;
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
