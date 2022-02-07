﻿using System;
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
            if (minutes == 59) hours = (hours == 23) ? 0 : hours + 1;
            else minutes++;
        }

        public void Tick(int minutes)
        {
            minutes = minutes % 60;
            hours = (hours + (int)Math.Floor((double)(minutes / 60))) % 24;
        }

        public static ModelTime operator +(ModelTime mt1, int mt2)
        {
            mt1.Tick(mt2);
            return mt1;
        }

        public static ModelTime operator ++(ModelTime mt1, int mt2)
        {
            mt1.Tick();
            return mt1;
        }

        public override string ToString()
        {
            return string.Format("{0:d2}:{1:d2}", hours, minutes);
        }
    }
}
