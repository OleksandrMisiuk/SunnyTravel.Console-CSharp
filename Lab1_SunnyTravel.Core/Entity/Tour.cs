using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1_SunnyTravel.Core.Entity
{
    class Tour
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public DateTime DateDepart { get; set; }
        public virtual Hotel Hotel { get; set; }

    }
}
