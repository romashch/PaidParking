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
        const int Interval = 1;
        const int StandartTickInMinute = 40;
        ModelTime modelTime;
        double revenue;
        Timer timer;
        int curIntervalTF;
        List<Car> cars;
        int speed;

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
            timer.Enabled = true;
            timer.Interval = Interval;
            timer.Tick += new EventHandler((s, e) => TimerTick(speed, e));
            revenue = 0;
            modelTime = new ModelTime(simulationParameters.StartHour, simulationParameters.StartMinute);
            SetCarSpawnInterval();
            cars = new List<Car>();
            parking.IsBusy = new bool[parking.PS.Count];
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
            int speed = (int)sender;
            if (ticks % (StandartTickInMinute / speed) == 0)
            {
                modelTime++;
                timeLabel.Text = "Время: " + modelTime;
                curIntervalTF--;
            }
            if (curIntervalTF == 0)
            {
                cars.Add(new Car(parking, simulationParameters, fieldPictureBox));
                SetCarSpawnInterval();
            }
            for (int i = 0; i < cars.Count; i++)
            {
                Car.State state = cars[i].Motion(modelTime, speed);
                if (state == Car.State.ParkedStart)
                {
                    int firstDisplayed = dataGridView1.FirstDisplayedScrollingRowIndex;
                    int displayed = dataGridView1.DisplayedRowCount(true);
                    int lastVisible = (firstDisplayed + displayed) - 1;
                    int lastIndex = dataGridView1.RowCount - 1;
                    dataGridView1.Rows.Add(dataGridView1.Rows.Count, cars[i].CheckInTime, cars[i].CheckOutTime, string.Format("{0:f2}", cars[i].Cost));
                    if (lastVisible == lastIndex)
                    {
                        dataGridView1.FirstDisplayedScrollingRowIndex = firstDisplayed + 1;
                    }
                    revenue += cars[i].Cost;
                    revenueLabel.Text = string.Format("Выручка: {0:f2}", revenue);
                }
                else if (state == Car.State.Finish)
                {
                    cars.RemoveAt(i);
                    i--;
                }
            }
            ticks++;
        }

        public static int RandomUniform(double min, double max)
        {
            return (int)(Math.Ceiling(new Random().NextDouble() * (max - min) + min));
        }

        public static int RandomExp(double lambda)
        {
            return (int)(Math.Ceiling(-Math.Log(1 - new Random().NextDouble()) / lambda));
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
            return (int)(Math.Ceiling(z * Math.Sqrt(dx) + mx));
        }

        private void SimulationForm_Load(object sender, EventArgs e)
        {
            fieldPictureBox.Width = parking.Length * 44;
            fieldPictureBox.Height = parking.Width * 44 + 44;
            Width = 260 + 16 + fieldPictureBox.Width;
            Height = 532;
            if (Height < fieldPictureBox.Height)
                Height = fieldPictureBox.Height;
            drawParking();
            revenueLabel.Text = string.Format("Выручка: {0:f2}", revenue);
            timeLabel.Text = "Время: " + modelTime;
            ticks = 1;
            speed = 1;
            timer.Start();
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
                                g.DrawImage(Properties.Resources.TPS, j * 44, i * 44, 44, 88);
                                break;
                            }
                        case Sample.CPS:
                            {
                                g.DrawImage(Properties.Resources.CPS, j * 44, i * 44, 44, 44);
                                break;
                            }
                        case Sample.Road:
                            {
                                g.DrawImage(Properties.Resources.road, j * 44, i * 44, 44, 44);
                                break;
                            }
                        case Sample.Entry:
                            {
                                g.DrawImage(Properties.Resources.entry, j * 44, i * 44, 44, 44);
                                break;
                            }
                        case Sample.Exit:
                            {
                                g.DrawImage(Properties.Resources.exit, j * 44, i * 44, 44, 44);
                                break;
                            }
                        case Sample.TicketOffice:
                            {
                                g.DrawImage(Properties.Resources.ticketOffice, j * 44, i * 44, 44, 44);
                                break;
                            }
                        case Sample.Lawn:
                            {
                                g.DrawImage(Properties.Resources.lawn, j * 44, i * 44, 44, 44);
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
            speed = (int)Math.Pow(2, speedTrackBar.Value);
        }
    }
}
