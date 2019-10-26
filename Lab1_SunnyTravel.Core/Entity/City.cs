using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1_SunnyTravel.Core.Entity
{
    class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Country Country { get; set; }
    }
}
