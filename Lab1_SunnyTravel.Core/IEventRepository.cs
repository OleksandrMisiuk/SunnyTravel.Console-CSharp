using Lab1_SunnyTravel.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1_SunnyTravel.Core
{
    interface IEventRepository
    {
        ICollection<Hotel> Where(Func<Hotel, bool> predicate);
        //ICollection<City> WhereCity(Func<City, bool> predicate);
        ICollection<Hotel> WhereRoomType(Func<Room, bool> predicate);
        ICollection<Hotel> WhereMeal(Func<Meal, bool> predicate);
        ICollection<Hotel> WhereTour(Func<Tour, bool> predicate);



    }
}
