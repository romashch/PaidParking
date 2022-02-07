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
        bool isParked;
        bool isTruck;
        int numOfPS;
        List<Vertice> way;
        ModelTime checkInTime;
        ModelTime checkOutTime;
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

        public Car(Parking parking, SimulationParameters simulationParameters, PictureBox fieldPictureBox)
        {
            isParked = new Random().NextDouble() < (simulationParameters.EnteringProbability);
            if (isParked)
            {
                numOfPS = new Random().Next(0, parking.PS.Count);
                SetParkingTime(simulationParameters);
                checkOutTime = checkInTime + parkingTime;
            }
            SetWay(parking);
            SetPictureBox(parking, simulationParameters, fieldPictureBox);
            direction = Direction.Left;
        }

        private void SetWay(Parking parking)
        {
            int i;
            if (isParked) {
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
        
        public void Motion()
        {
            if (pictureBox.Location.X % 45 == 0 || pictureBox.Location.Y % 45 == 0)
            {
                way.RemoveAt(0);
                if (way.Count == 0)
                {
                    pictureBox.Dispose();
                    return;
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
        }
    }
}
