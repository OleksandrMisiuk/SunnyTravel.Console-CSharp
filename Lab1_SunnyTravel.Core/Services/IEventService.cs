using System.Collections.Generic;
using Lab1_SunnyTravel.Core.Entity;
using Lab1_SunnyTravel.Core.Models;

namespace Lab1_SunnyTravel.Core.Services
{
    public interface IEventService
    {
        ICollection<Hotel> GetFilteredHotels(EventFilterModelIn model, bool filterNestedCollections = true);
    }
}