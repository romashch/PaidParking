using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PaidParking3
{
    public class Cell
    {
        [Key]
        public int Id { get; set; }
        public string ParkingName { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Sample { get; set; }

        public Cell()
        {

        }

        public Cell(string pName, int x, int y, int s)
        {
            ParkingName = pName;
            X = x;
            Y = y;
            Sample = s;
        }
    }
}
