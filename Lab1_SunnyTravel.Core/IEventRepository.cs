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
        //ICollection<Room> WhereRoomType(Func<Room, bool> predicate);
        //ICollection<Meal> WhereMeal(Func<Meal, bool> predicate);


    }
}
