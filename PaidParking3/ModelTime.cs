using System;
using System.Collections.Generic;
using System.Text;

namespace PaidParking3
{
    public struct ModelTime
    {
        int hours;
        int minutes;

        public ModelTime(int hours, int minutes)
        {
            this.minutes = minutes % 60;
            this.hours = (hours + (int)Math.Floor((double)(minutes / 60))) % 24;
        }

        public void Tick()
        {
            if (minutes == 59)
            {
                hours = (hours == 23) ? 0 : hours + 1;
                minutes = 0;
            }
            else minutes++;
        }

        public void Tick(int m)
        {
            hours = (hours + (int)Math.Floor((double)((minutes + m) / 60))) % 24;
            minutes = (minutes + m) % 60;
        }

        public static ModelTime operator +(ModelTime mt1, int mt2)
        {
            mt1.Tick(mt2);
            return mt1;
        }

        public static ModelTime operator ++(ModelTime mt1)
        {
            mt1.Tick();
            return mt1;
        }

        public static bool operator ==(ModelTime mt1, ModelTime mt2)
        {
            return mt1.hours == mt2.hours && mt1.minutes == mt2.minutes;
        }

        public static bool operator !=(ModelTime mt1, ModelTime mt2)
        {
            return mt1.hours != mt2.hours || mt1.minutes != mt2.minutes;
        }

        public override string ToString()
        {
            return string.Format("{0:d2}:{1:d2}", hours, minutes);
        }

        public bool IsNight()
        {
            return hours >= 22 || hours <= 5;
        }
    }
}
