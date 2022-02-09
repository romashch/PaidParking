using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static PaidParking3.SimulationForm;

namespace PaidParking3
{
    class Car
    {
        Parking parking;
        bool isGoingToParking;
        bool isTruck;
        int numOfPS;
        List<Vertice> way;
        ModelTime checkInTime;
        public ModelTime CheckInTime { get { return checkInTime; } }
        ModelTime checkOutTime;
        public ModelTime CheckOutTime { get { return checkOutTime; } }

        int parkingTime;
        PictureBox pictureBox;
        public enum Direction
        {
            Top,
            Bottom,
            Left,
            Right
        }
        Direction direction;
        double cost;
        public double Cost { get { return cost; } }

        double dayTariff;
        double nightTariff;
        public enum State
        {
            Motion,
            TruckParkedStart,
            ParkedStart,
            Parked,
            ParkedEnd,
            TruckParkedEnd,
            Finish
        }
        State state;

        public Car(Parking parking, SimulationParameters simulationParameters, PictureBox fieldPictureBox)
        {
            isTruck = new Random().NextDouble() < (simulationParameters.TrucksPercentage / 100);
            this.parking = parking;
            Dictionary<int, Vertice> curFreePS = new Dictionary<int, Vertice>();
            for (int i = 0; i < parking.PS.Count; i++)
            {
                if (parking.IsBusy[i] == false && (!isTruck && parking.PS[i].s == Sample.CPS || isTruck && parking.PS[i].s == Sample.TPS))
                {
                    curFreePS.Add(i, parking.PS[i]);
                }
            }
            if (curFreePS.Count == 0)
                isGoingToParking = false;
            else
                isGoingToParking = new Random().NextDouble() < (simulationParameters.EnteringProbability);
            if (isGoingToParking)
            {
                do
                {
                    numOfPS = new Random().Next(0, parking.PS.Count);
                }
                while (!curFreePS.ContainsKey(numOfPS));
                parking.IsBusy[numOfPS] = true;
                SetParkingTime(simulationParameters);
            }
            SetWay(parking);
            SetPictureBox(parking, simulationParameters, fieldPictureBox);
            direction = Direction.Left;
            state = State.Motion;
            dayTariff = simulationParameters.DayTariffPrice;
            nightTariff = simulationParameters.NightTariffPrice;
        }

        private void SetWay(Parking parking)
        {
            way = new List<Vertice>();
            int i;
            if (isGoingToParking)
            {
                for (i = parking.Length; i >= parking.EntryWays[numOfPS][0].y; i--)
                    way.Add(new Vertice(parking.Width, i, Sample.Road));
                way.AddRange(parking.EntryWays[numOfPS]);
                way.AddRange(parking.ExitWays[numOfPS]);
                for (i = parking.ExitWays[numOfPS][parking.ExitWays[numOfPS].Count - 1].y; i >= -1; i--)
                    way.Add(new Vertice(parking.Width, i, Sample.Road));
            }
            else
            {
                for (i = parking.Length; i >= -1; i--)
                    way.Add(new Vertice(parking.Width, i, Sample.Road));
            }

            //StreamWriter sw = new StreamWriter(@"C:\Users\dvt21\Documents\Универ\ПИ\PaidParking3\graph.txt", false);
            //for (int z = 0; z < way.Count; z++)
            //{
            //    sw.WriteLine(way[z] + " " + way[z].s);
            //}
            //sw.Close();
        }

        private void SetPictureBox(Parking parking, SimulationParameters simulationParameters, PictureBox fieldPictureBox)
        {
            pictureBox = new PictureBox();
            if (!isTruck)
            {
                pictureBox.Location = new Point(parking.Length * 44, parking.Width * 44);
                pictureBox.Size = new Size(44, 44);
                pictureBox.Image = Properties.Resources.car;
            }
            else
            {
                pictureBox.Location = new Point(parking.Length * 44 - 22, parking.Width * 44);
                pictureBox.Size = new Size(88, 44);
                pictureBox.Image = Properties.Resources.track;
            }
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.BackgroundImage = null;
            pictureBox.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
            pictureBox.BackColor = Color.FromArgb(0, 0, 0, 0);
            fieldPictureBox.Controls.Add(pictureBox);
        }

        private void SetParkingTime(SimulationParameters simulationParameters)
        {
            if (simulationParameters.ParkingTimeType == SimulationParameters.DetRan.Deterministic)
            {
                parkingTime = (int)simulationParameters.Interval2;
            }
            else
                switch (simulationParameters.Law2)
                {
                    case SimulationParameters.DistributionLaw.Normal:
                        {
                            parkingTime = RandomNormal(simulationParameters.Mx2, simulationParameters.Dx2);
                            break;
                        }
                    case SimulationParameters.DistributionLaw.Uniform:
                        {
                            parkingTime = RandomUniform(simulationParameters.Min2, simulationParameters.Max2);
                            break;
                        }
                    case SimulationParameters.DistributionLaw.Exponential:
                        {
                            parkingTime = RandomExp(simulationParameters.Lambda2);
                            break;
                        }
                }
        }

        private void ChangeDirection()
        {
            int x, y;
            if (!isTruck || isTruck && state == State.TruckParkedEnd)
            {
                x = pictureBox.Location.Y / 44;
                y = pictureBox.Location.X / 44;
            }
            else
            {
                x = (pictureBox.Location.Y + 22) / 44;
                y = (pictureBox.Location.X + 22) / 44;
            }
            Direction oldDirection = direction;
            if (state == State.TruckParkedEnd && way[0].x == x)
            {
                direction = Direction.Top;
            }
            else if (state == State.TruckParkedEnd && way[0].x > x)
            {
                direction = Direction.Bottom;
            }
            if (way[0].y < y)
                direction = Direction.Left;
            else if (way[0].y > y)
                direction = Direction.Right;
            else if (way[0].x < x)
                direction = Direction.Top;
            else if (way[0].x > x)
                direction = Direction.Bottom;
            if (isTruck)
            {
                if ((oldDirection == Direction.Top || oldDirection == Direction.Bottom) && (direction == Direction.Left || direction == Direction.Right))
                {
                    pictureBox.Size = new Size(88, 44);
                    pictureBox.Location = new Point(pictureBox.Location.X - 22, pictureBox.Location.Y + 22);
                }
                else if ((oldDirection == Direction.Left || oldDirection == Direction.Right) && (direction == Direction.Top || direction == Direction.Bottom))
                {
                    pictureBox.Size = new Size(44, 88);
                    pictureBox.Location = new Point(pictureBox.Location.X + 22, pictureBox.Location.Y - 22);
                }
            }
            if (oldDirection == Direction.Top)
            {
                if (direction == Direction.Bottom)
                    pictureBox.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                else if (direction == Direction.Left)
                    pictureBox.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                else if (direction == Direction.Right)
                    pictureBox.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            }
            else if (oldDirection == Direction.Bottom)
            {
                if (direction == Direction.Top)
                    pictureBox.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                else if (direction == Direction.Left)
                    pictureBox.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                else if (direction == Direction.Right)
                    pictureBox.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
            }
            else if (oldDirection == Direction.Left)
            {
                if (direction == Direction.Bottom)
                    pictureBox.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                else if (direction == Direction.Top)
                    pictureBox.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                else if (direction == Direction.Right)
                    pictureBox.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
            }
            else if (oldDirection == Direction.Right)
            {
                if (direction == Direction.Bottom)
                    pictureBox.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                else if (direction == Direction.Top)
                    pictureBox.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                else if (direction == Direction.Left)
                    pictureBox.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
            }
        }

        public State Motion(ModelTime mt, int speed)
        {
            if (state == State.Parked && checkOutTime == mt)
            {
                state = State.ParkedEnd;
                parking.IsBusy[numOfPS] = false;
                way.RemoveAt(0);
                if (isTruck)
                {
                    state = State.TruckParkedEnd;
                    ChangeDirection();
                }
            }
            else if (state == State.Finish || state == State.Parked)
            {
                return state;
            }
            else if (state == State.ParkedStart)
            {
                state = State.Parked;
                return state;
            }
            else if (state == State.TruckParkedStart && pictureBox.Location.X % 44 <= 2 && pictureBox.Location.Y % 44 <= 2)
            {
                state = State.ParkedStart;
                checkInTime = mt;
                checkOutTime = checkInTime + parkingTime;
                GetCost();
                return state;
            }
            if (!isTruck && pictureBox.Location.X % 44 == 0 && pictureBox.Location.Y % 44 == 0 || isTruck && ((pictureBox.Location.X + 22) % 44 == 0 && pictureBox.Location.Y % 44 == 0 || (pictureBox.Location.Y + 22) % 44 == 0 && pictureBox.Location.X % 44 == 0))
            {
                if (way[0].s == Sample.CPS)
                {
                    state = State.ParkedStart;
                    checkInTime = mt;
                    checkOutTime = checkInTime + parkingTime;
                    GetCost();
                    return state;
                }
                else if (state != State.TruckParkedEnd && state == State.Motion && (way[0].s == Sample.TPS || way[0].s == Sample.None))
                {
                    state = State.TruckParkedStart;
                }
                else if (state == State.TruckParkedEnd)
                {
                    state = State.Motion;
                }
                if (state != State.ParkedEnd)
                    way.RemoveAt(0);
                if (way.Count == 0)
                {
                    pictureBox.Dispose();
                    state = State.Finish;
                    return state;
                }
                ChangeDirection();
            }
            Step(direction, speed);
            if (state == State.ParkedEnd)
            {
                state = State.Motion;
            }
            return state;
        }

        public void Step(Direction direction, int step)
        {
            int i = 0;
            do
            {
                switch (direction)
                {
                    case Direction.Top:
                        {
                            pictureBox.Location = new Point(pictureBox.Location.X, pictureBox.Location.Y - 1);
                            break;
                        }
                    case Direction.Bottom:
                        {
                            pictureBox.Location = new Point(pictureBox.Location.X, pictureBox.Location.Y + 1);
                            break;
                        }
                    case Direction.Left:
                        {
                            pictureBox.Location = new Point(pictureBox.Location.X - 1, pictureBox.Location.Y);
                            break;
                        }
                    case Direction.Right:
                        {
                            pictureBox.Location = new Point(pictureBox.Location.X + 1, pictureBox.Location.Y);
                            break;
                        }
                }
                i++;
            }
            while (i < step && !(!isTruck && pictureBox.Location.X % 44 == 0 && pictureBox.Location.Y % 44 == 0 || isTruck && ((pictureBox.Location.X + 22) % 44 == 0 && pictureBox.Location.Y % 44 == 0 || (pictureBox.Location.Y + 22) % 44 == 0 && pictureBox.Location.X % 44 == 0)));
        }

        public void GetCost()
        {
            cost = 0;
            cost += (int)Math.Floor((double)parkingTime / 1440) * (8 * nightTariff + 16 * dayTariff);
            ModelTime mt = checkInTime;
            while (mt != checkOutTime)
            {
                if (!mt.IsNight())
                    cost += dayTariff / 60;
                else
                    cost += nightTariff / 60;
                mt++;
            }
        }
    }
}
