using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1_SunnyTravel.Core.Entity
{
    class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SeaDistance { get; set; }
        public int Rating { get; set; }
        public virtual City City { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
        public virtual ICollection<Tour> Tours { get; set; }
        public virtual ICollection<Meal> Meals { get; set; }
    }
}
