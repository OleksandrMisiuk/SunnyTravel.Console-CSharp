using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lab1_SunnyTravel.Core.Entity
{
    public class Country
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<City> Cities { get; set; }
    }
}
