using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Timers;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace PaidParking3
{
    public partial class SimulationForm : Form
    {
        MainMenuForm form;
        Parking parking;
        SimulationParameters simulationParameters;
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
            timer = new Timer(components);
            timer.Enabled = true;
            timer.Interval = StandartInterval;
            timer.Tick += new EventHandler(TimerTick);
            revenue = 0;
            modelTime = new ModelTime(simulationParameters.StartHour, simulationParameters.StartMinute);
            SetCarSpawnInterval();
            cars = new List<Car>();
        }

        private void SetCarSpawnInterval()
        {
            if (simulationParameters.TrafficFlowType == SimulationParameters.DetRan.Deterministic)
            {
                curIntervalTF = (int)simulationParameters.Interval;
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

        private void TimerTick(object sender, EventArgs e)
        {
            if (ticks % TickInMinute == 0)
            {
                modelTime++;
                timeLabel.Text = "Время: " + modelTime;
                //curIntervalTF--;
            }
            //timeLabel.Text = "Время: " + modelTime + " " + ticks;
            /*if (curIntervalTF == 0)
            {
                //cars.Add(new Car(parking, simulationParameters, fieldPictureBox));
                SetCarSpawnInterval();
            }
            for (int i = 0; i < cars.Count; i++)
            {
                Car.State state = cars[i].Motion(modelTime);
                if (state == Car.State.Finish)
                {
                    cars.RemoveAt(i);
                    i--;
                }
                else if (state == Car.State.ParkedStart)
                {
                    dataGridView1.Rows.Add(cars[i].CheckInTime, cars[i].CheckOutTime, string.Format("{0:f2}", cars[i].Cost));
                    revenue += cars[i].Cost;
                    revenueLabel.Text = string.Format("Выручка: {0:f2}", revenue);
                }
            }*/
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
            drawParking();
            revenueLabel.Text = string.Format("Выручка: {0:f2}", revenue);
            timeLabel.Text = "Время: " + modelTime;
            ticks = 1;
            timer.Start();
            cars.Add(new Car(parking, simulationParameters, fieldPictureBox));
        }

        private void drawParking()
        {
            Bitmap bmp = new Bitmap(fieldPictureBox.Width, fieldPictureBox.Height);
            Graphics g = Graphics.FromImage(bmp);
            for (int i = 0; i < parking.Topology.GetLength(0); i++)
            {
                for (int j = 0; j < parking.Topology.GetLength(1); j++)
                {
                    switch (parking.Topology[i, j])
                    {
                        case Sample.TPS:
                            {
                                g.DrawImage(Properties.Resources.TPS, j * 45, i * 45, 45, 90);
                                break;
                            }
                        case Sample.CPS:
                            {
                                g.DrawImage(Properties.Resources.CPS, j * 45, i * 45, 45, 45);
                                break;
                            }
                        case Sample.Road:
                            {
                                g.DrawImage(Properties.Resources.road, j * 45, i * 45, 45, 45);
                                break;
                            }
                        case Sample.Entry:
                            {
                                g.DrawImage(Properties.Resources.entry, j * 45, i * 45, 45, 45);
                                break;
                            }
                        case Sample.Exit:
                            {
                                g.DrawImage(Properties.Resources.exit, j * 45, i * 45, 45, 45);
                                break;
                            }
                        case Sample.TicketOffice:
                            {
                                g.DrawImage(Properties.Resources.ticketOffice, j * 45, i * 45, 45, 45);
                                break;
                            }
                        case Sample.Lawn:
                            {
                                g.DrawImage(Properties.Resources.lawn, j * 45, i * 45, 45, 45);
                                break;
                            }
                    }
                }
            }
            fieldPictureBox.Image = bmp;
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
            //timer.Stop();
            //timer = new Timer();
            //timer.Tick -= new EventHandler(TimerTick);
            //timer.Tick += new EventHandler(TimerTick);
            timer.Interval = (int)(StandartInterval / Math.Pow(2, speedTrackBar.Value));
            //timer.Start();
        }
    }
}
