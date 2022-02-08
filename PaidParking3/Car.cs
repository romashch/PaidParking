using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static PaidParking3.SimulationForm;

namespace PaidParking3
{
    class Car
    {
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
        enum Direction
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
            Parked,
            Finish
        }
        State state;

        public Car(Parking parking, SimulationParameters simulationParameters, PictureBox fieldPictureBox)
        {
            isGoingToParking = new Random().NextDouble() < (simulationParameters.EnteringProbability);
            if (isGoingToParking)
            {
                numOfPS = new Random().Next(0, parking.PS.Count);
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
            if (isGoingToParking) {
                for (i = parking.Length - 1; i >= parking.EntryWays[numOfPS][0].y; i--)
                    way.Add(new Vertice(parking.Width, i, Sample.Road));
                way.AddRange(parking.EntryWays[numOfPS]);
                way.AddRange(parking.ExitWays[numOfPS]);
                for (i = i + 1; i >= 0; i--)
                    way.Add(new Vertice(parking.Width, i, Sample.Road));
            }
            else
            {
                for (i = parking.Length - 1; i >= 0; i--)
                    way.Add(new Vertice(parking.Width, i, Sample.Road));
            }
        }

        private void SetPictureBox(Parking parking, SimulationParameters simulationParameters, PictureBox fieldPictureBox)
        {
            isTruck = new Random().NextDouble() < (simulationParameters.TrucksPercentage / 100);
            pictureBox = new PictureBox();
            if (!isTruck)
            {
                pictureBox.Location = new Point((parking.Length - 1) * 45, (parking.Width - 1) * 45);
                pictureBox.Size = new Size(45, 45);
                pictureBox.Image = Properties.Resources.CPS;
            }
            else
            {
                pictureBox.Location = new Point((parking.Length - 1) * 45, (parking.Width - 1) * 45);
                pictureBox.Size = new Size(90, 45);
                pictureBox.Image = Properties.Resources.TPS;
            }
            pictureBox.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.BackgroundImage = null;
            pictureBox.BackColor = Color.FromArgb(0, 0, 0, 0);
            pictureBox.Refresh();
            fieldPictureBox.Invoke((MethodInvoker)delegate {
                fieldPictureBox.Controls.Add(pictureBox); 
            });
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
            int x = pictureBox.Location.X / 45;
            int y = pictureBox.Location.Y / 45;
            Direction oldDirection = direction;
            if (way[0].y < y)
                direction = Direction.Top;
            else if (way[0].y > y)
                direction = Direction.Bottom;
            else if (way[0].x < x)
                direction = Direction.Left;
            else if (way[0].x > x)
                direction = Direction.Right;
            if (isTruck)
            {
                if ((oldDirection == Direction.Top || oldDirection == Direction.Bottom) && (direction == Direction.Left || direction == Direction.Right))
                    pictureBox.Size = new Size(90, 45);
                else if ((oldDirection == Direction.Left || oldDirection == Direction.Right) && (direction == Direction.Top || direction == Direction.Bottom))
                    pictureBox.Size = new Size(45, 90);
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
                else if (direction == Direction.Left)
                    pictureBox.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                else if (direction == Direction.Top)
                    pictureBox.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
            }
            pictureBox.Refresh();
        }
        
        public State Motion(ModelTime mt)
        {
            if (state == State.Parked && checkOutTime == mt)
            {
                state = State.Motion;
            }
            else
            {
                return state;
            }
            if (pictureBox.Location.X % 45 == 0 || pictureBox.Location.Y % 45 == 0)
            {

                if (way[0].s == Sample.CPS || way[0].s == Sample.TPS)
                {
                    state = State.Parked;
                    checkInTime = mt;
                    checkOutTime = checkInTime + parkingTime;
                    GetCost();
                    way.RemoveAt(0);
                    return state;
                }
                way.RemoveAt(0);
                if (way.Count == 0)
                {
                    pictureBox.Dispose();
                    state = State.Finish;
                    return state;
                }
                ChangeDirection();
            }
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
            return state;
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
