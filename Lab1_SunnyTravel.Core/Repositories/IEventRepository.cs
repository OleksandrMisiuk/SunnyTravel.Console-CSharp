using System;
using System.Collections.Generic;
using Lab1_SunnyTravel.Core.Entity;

namespace Lab1_SunnyTravel.Core.Repositories
{
    public interface IEventRepository
    {
        ICollection<Hotel> Where(Func<Hotel, bool> predicate);
    }
}
