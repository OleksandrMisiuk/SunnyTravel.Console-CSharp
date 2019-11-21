using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab1_SunnyTravel.Core.Entity
{
    public class Hotel
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("sea_distance")]
        public int SeaDistance { get; set; }

        [Column("rating")]
        public int Rating { get; set; }

        [ForeignKey("city_id")]
        public City City { get; set; }

        [ForeignKey("hotel_id")]
        public virtual List<Room> Rooms { get; set; }
        [ForeignKey("hotel_id")]
        public virtual List<Tour> Tours { get; set; }
        [ForeignKey("hotel_id")]
        public virtual List<Meal> Meals { get; set; }
    }
}
