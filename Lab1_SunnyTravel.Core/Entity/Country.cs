using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1_SunnyTravel.Core.Entity
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<City> Cities { get; set; }
    }
}
