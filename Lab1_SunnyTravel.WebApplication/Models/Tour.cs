using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;

namespace Lab1_SunnyTravel.Core.Entity
{
    [Table("Package")]
    public class Tour
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("price")]
        public decimal Price { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("duration")]
        public int Duration { get; set; }
        [Column("date_depart")]
        public DateTime DateDepart { get; set; }
        [ForeignKey("hotel_id")]
        [NotMapped]
        [JsonIgnore]
        public Hotel Hotel { get; set; }

    }
}
