using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Timers;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace PaidParking3
{
    public partial class SimulationForm : Form
    {
        MainMenuForm form;
        Parking parking;
        SimulationParameters simulationParameters;
        PictureBox[,] pictureBoxes;
        int ticks;
        const int StandartInterval = 8;
        const int TickInMinute = 50;
        ModelTime modelTime;
        double revenue;
        Timer timer;
        int curIntervalTF;
        List<Car> cars;

        public SimulationForm()
        {
            InitializeComponent();
        }

        public SimulationForm(MainMenuForm form)
        {
            InitializeComponent();
            this.form = form;
            parking = form.Parking;
            parking.DijkstrasAlgorithmWithWays();
            parking.GetPS();
            simulationParameters = form.SimulationParameters;
            timer = new Timer();
            timer.Interval = StandartInterval;
            timer.Elapsed += TimerTick;
            revenue = 0;
            modelTime = new ModelTime(simulationParameters.StartHour, simulationParameters.StartMinute);
            SetCarSpawnInterval();
            cars = new List<Car>();
        }

        private void SetCarSpawnInterval()
        {
            if (simulationParameters.TrafficFlowType == SimulationParameters.DetRan.Deterministic)
            {
                curIntervalTF = (int)simulationParameters.Interval2;
            }
            else
                switch (simulationParameters.Law)
                {
                    case SimulationParameters.DistributionLaw.Normal:
                        {
                            curIntervalTF = RandomNormal(simulationParameters.Mx, simulationParameters.Dx);
                            break;
                        }
                    case SimulationParameters.DistributionLaw.Uniform:
                        {
                            curIntervalTF = RandomUniform(simulationParameters.Min, simulationParameters.Max);
                            break;
                        }
                    case SimulationParameters.DistributionLaw.Exponential:
                        {
                            curIntervalTF = RandomExp(simulationParameters.Lambda);
                            break;
                        }
                }
        }

        private void TimerTick(object? sender, ElapsedEventArgs e)
        {
            if (ticks % TickInMinute == 0)
            {
                modelTime++;
                timeLabel.Invoke((MethodInvoker)delegate {
                    timeLabel.Text = "Время: " + modelTime;
                });
                curIntervalTF--;
            }
            if (curIntervalTF == 0)
            {
                cars.Add(new Car(parking, simulationParameters, fieldPictureBox));
                SetCarSpawnInterval();
            }
            foreach (Car c in cars)
            {
                Car.State state = c.Motion(modelTime);
                if (state == Car.State.Finish)
                {
                    cars.Remove(c);
                }
                else if (state == Car.State.Parked)
                {
                    dataGridView1.Rows.Add(c.CheckInTime, c.CheckOutTime, c.Cost);
                    revenue += c.Cost;
                    revenueLabel.Text = string.Format("Выручка: {0:f2}", revenue);
                }
            }
            ticks++;
        }

        public static int RandomUniform(double min, double max)
        {
            return (int)(new Random().NextDouble() * (max - min) + min);
        }

        public static int RandomExp(double lambda)
        {
            return (int)(-Math.Log(1 - new Random().NextDouble()) / lambda);
        }

        public static int RandomNormal(double mx, double dx)
        {
            double x, y, s, z;
            do
            {
                do
                {
                    x = new Random().NextDouble() * 2 - 1;
                    y = new Random().NextDouble() * 2 - 1;
                    s = Math.Sqrt(x * x + y * y);
                }
                while (s > 1 || s == 0);
                z = x * Math.Sqrt(-2 * Math.Log(s) / s);
            }
            while (z <= 0);
            return (int)(z * Math.Sqrt(dx) + mx);
        }

        private void SimulationForm_Load(object sender, EventArgs e)
        {
            fieldPictureBox.Width = parking.Length * 45;
            fieldPictureBox.Height = parking.Width * 45 + 45;
            Width = 260 + 16 + fieldPictureBox.Width;
            Height = 532;
            if (Height < fieldPictureBox.Height)
                Height = fieldPictureBox.Height;
            createPictureBoxesArray();
            revenueLabel.Text = string.Format("Выручка: {0:f2}", revenue);
            timeLabel.Text = "Время: " + modelTime;
            timer.Start();
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
                        case Sample.TPS:
                            {
                                pictureBoxes[i, j].Size = new Size(45, 90);
                                pictureBoxes[i, j].Image = Properties.Resources.TPS;
                                break;
                            }
                        case Sample.CPS:
                            {
                                pictureBoxes[i, j].Image = Properties.Resources.CPS;
                                break;
                            }
                        case Sample.Road:
                            {
                                pictureBoxes[i, j].Image = Properties.Resources.road;
                                break;
                            }
                        case Sample.Entry:
                            {
                                pictureBoxes[i, j].Image = Properties.Resources.entry;
                                break;
                            }
                        case Sample.Exit:
                            {
                                pictureBoxes[i, j].Image = Properties.Resources.exit;
                                break;
                            }
                        case Sample.TicketOffice:
                            {
                                pictureBoxes[i, j].Image = Properties.Resources.ticketOffice;
                                break;
                            }
                        case Sample.Lawn:
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
            timer.Stop();
            form.Show();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            timer.Start();
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            timer.Stop();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            timer.Stop();
            Close();
        }

        private void speedTrackBar_Scroll(object sender, EventArgs e)
        {
            timer.Interval = (int)(StandartInterval / Math.Pow(2, speedTrackBar.Value));
        }
    }
}
