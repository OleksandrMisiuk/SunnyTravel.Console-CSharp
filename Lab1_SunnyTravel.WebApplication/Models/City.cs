using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lab1_SunnyTravel.Core.Entity
{
    public class City
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [ForeignKey("country_id")]
        public Country Country { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual List<Hotel> Hotel { get; set; }
    }
}
