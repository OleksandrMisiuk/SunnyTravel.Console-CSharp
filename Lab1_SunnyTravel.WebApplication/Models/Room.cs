using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;

namespace Lab1_SunnyTravel.Core.Entity
{
    public class Room
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("type")]
        public string Type { get; set; }
        [Column("seats")]
        public int Seats { get; set; }
        [Column("busy")]
        public bool IsBusy { get; set; }
        [Column("price")]
        public decimal Price { get; set; }

        [ForeignKey("hotel_id")]
        [NotMapped]
        [JsonIgnore]
        public Hotel Hotel { get; set; }
    }
}
