using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1_SunnyTravel.Core.Models
{
    class EventFilterModelIn
    {
        public string CountryPartName { get; set; }
        public string CityPartName { get; set; }
        public DateTime? DateDepart { get; set; }
        public int? Duration { get; set; }
        public int? NumberOfPeople { get; set; }
        public int? MinSeaDistance { get; set; }
        public String RoomType { get; set; }
        public String Meal { get; set; }
        public int? MinHotelRating { get; set; }
    }
}
