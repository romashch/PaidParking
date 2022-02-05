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
        Parking parking;
        SimulationParameters simulationParameters;
        PictureBox[,] pictureBoxes;

        public SimulationForm()
        {
            InitializeComponent();
        }

        public SimulationForm(MainMenuForm form)
        {
            InitializeComponent();
            this.form = form;
            this.parking = form.Parking;
            this.simulationParameters = form.SimulationParameters;
        }

        private void SimulationForm_Load(object sender, EventArgs e)
        {
            fieldPictureBox.Width = parking.Length * 45;
            fieldPictureBox.Height = parking.Width * 45 + 45;
            Width = 260 + 16 + fieldPictureBox.Width;
            Height = 532;
            if (Height < fieldPictureBox.Height)
            {
                Height = fieldPictureBox.Height;
            }
            createPictureBoxesArray();
        }

        private void createPictureBoxesArray()
        {
            pictureBoxes = new PictureBox[parking.Width, parking.Length];
            for (int i = 0; i < pictureBoxes.GetLength(0); i++)
            {
                for (int j = 0; j < pictureBoxes.GetLength(1); j++)
                {
                    pictureBoxes[i, j] = new PictureBox();
                    pictureBoxes[i, j].Location = new Point(j * 45, i * 45);
                    pictureBoxes[i, j].BorderStyle = BorderStyle.FixedSingle;
                    pictureBoxes[i, j].BackgroundImage = Properties.Resources.road;
                    pictureBoxes[i, j].SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBoxes[i, j].Size = new Size(45, 45);
                    switch (parking.Topology[i, j])
                    {
                        case Parking.Sample.TPS:
                            {
                                pictureBoxes[i, j].Size = new Size(45, 90);
                                pictureBoxes[i, j].Image = Properties.Resources.TPS;
                                break;
                            }
                        case Parking.Sample.CPS:
                            {
                                pictureBoxes[i, j].Image = Properties.Resources.CPS;
                                break;
                            }
                        case Parking.Sample.Road:
                            {
                                pictureBoxes[i, j].Image = Properties.Resources.road;
                                break;
                            }
                        case Parking.Sample.Entry:
                            {
                                pictureBoxes[i, j].Image = Properties.Resources.entry;
                                break;
                            }
                        case Parking.Sample.Exit:
                            {
                                pictureBoxes[i, j].Image = Properties.Resources.exit;
                                break;
                            }
                        case Parking.Sample.TicketOffice:
                            {
                                pictureBoxes[i, j].Image = Properties.Resources.ticketOffice;
                                break;
                            }
                        case Parking.Sample.Lawn:
                            {
                                pictureBoxes[i, j].Image = Properties.Resources.lawn;
                                break;
                            }
                    }
                    fieldPictureBox.Controls.Add(pictureBoxes[i, j]);
                }
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
