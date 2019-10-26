using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1_SunnyTravel.Core.Entity
{
    class Room
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int Seats { get; set; }
        public bool IsBusy { get; set; }
        public decimal Price { get; set; }
    }
}
