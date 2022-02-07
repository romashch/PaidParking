using System;
using System.Collections.Generic;
using System.Text;

namespace PaidParking3
{
    public struct Vertice
    {
        public int x;
        public int y;
        public Sample s;
        public Vertice(int x, int y, Sample s)
        {
            this.x = x;
            this.y = y;
            this.s = s;
        }
        public override string ToString()
        {
            return x + " " + y;
        }
    }
}
