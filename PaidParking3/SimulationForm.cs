using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Timer = System.Threading.Timer;

namespace PaidParking3
{
    public partial class SimulationForm : Form
    {
        MainMenuForm form;
        Parking parking;
        SimulationParameters simulationParameters;
        PictureBox[,] pictureBoxes;
        int tick_interval_ms;
        const int Standart_tick_interval_ms = 100;
        int timeH, timeM;
        int revenue;

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
            tick_interval_ms = Standart_tick_interval_ms;
            TimerCallback timerCallback = new TimerCallback(TimerTick);
            Timer timer = new Timer(timerCallback, null, 0, tick_interval_ms);
            revenue = 0;
            timeH = simulationParameters.StartHour;
            timeM = simulationParameters.StartMinute;
        }

        private void TimerTick(object obj)
        {
            
        }

        private int RandomUniform(int min, int max)
        {
            return (int)(new Random().NextDouble() * (max - min) + min);
        }

        private int RandomExp(int lambda)
        {
            return (int)(-Math.Log(1 - new Random().NextDouble()) / lambda);
        }

        private int RandomNormal(int mx, int dx)
        {
            double x, y, s;
            do
            {
                x = new Random().NextDouble() * 2 - 1;
                y = new Random().NextDouble() * 2 - 1;
                s = Math.Sqrt(x * x + y * y);
            }
            while (s > 1 || s == 0);
            double z = x * Math.Sqrt(-2 * Math.Log(s) / s);
            return (int)(z * Math.Sqrt(dx) + mx);
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
            revenueLabel.Text = "Выручка: " + revenue;
            timeLabel.Text = string.Format("Время: {0:d2}:{1:d2}", timeH, timeM);
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

        private void speedTrackBar_Scroll(object sender, EventArgs e)
        {
            tick_interval_ms = (int)(Standart_tick_interval_ms / Math.Pow(2, speedTrackBar.Value));
        }
    }
}
