using System;
using System.Linq;
using Lab1_SunnyTravel.Core.Entity;
using Lab1_SunnyTravel.Core.Models;
using LinqKit;

namespace Lab1_SunnyTravel.ConsoleProject
{
    public static class FilterFuncHelper
    {

        public static Func<Hotel, bool> BuildHotelFilterFunc(EventFilterModelIn model)
        {
            var builder = PredicateBuilder.New<Hotel>(true);

            if (!model.CityPartName.IsNullOrEmpty())
            {
                builder = builder.And(e => e.City.Name.IndexOf(model.CityPartName, StringComparison.OrdinalIgnoreCase) >= 0);
            }

            if (!model.CountryPartName.IsNullOrEmpty())
            {
                builder = builder.And(e => e.City.Country.Name.IndexOf(model.CountryPartName, StringComparison.OrdinalIgnoreCase) >= 0);
            }

            if (model.MinHotelRating.HasValue)
            {
                builder = builder.And(e => e.Rating >= model.MinHotelRating);
            }

            if (model.MinSeaDistance.HasValue)
            {
                builder = builder.And(e => e.SeaDistance <= model.MinSeaDistance);
            }

            var tourFilterFunc = BuildTourFilterFunc(model);
            builder = builder.And(e => e.Tours.Any(tourFilterFunc));

            var mealFilterFunc = BuildMealFilterFunc(model);
            builder = builder.And(e => e.Meals.Any(mealFilterFunc));

            var roomFilterFunc = BuildRoomFilterFunc(model);
            builder = builder.And(e => e.Rooms.Any(roomFilterFunc));

            var filterFunc = builder.Compile();
            return filterFunc;
        }

        public static Func<Room, bool> BuildRoomFilterFunc(EventFilterModelIn model)
        {

            var builder = PredicateBuilder.New<Room>(true);

            if (model.NumberOfPeople != null)
            {
                builder = builder.And(t => t.Seats.Equals(model.NumberOfPeople));
            }

            if (model.RoomType != null)
            {
                builder = builder.And(t => t.Type.IndexOf(model.RoomType, StringComparison.OrdinalIgnoreCase) >= 0);
            }

            var filterFunc = builder.Compile();
            return filterFunc;
        }
        public static Func<Meal, bool> BuildMealFilterFunc(EventFilterModelIn model)
        {
            var builder = PredicateBuilder.New<Meal>(true);

            if (model.Meal != null)
            {
                builder = builder.And(t => t.Type.IndexOf(model.Meal, StringComparison.OrdinalIgnoreCase) >= 0);
            }

            var filterFunc = builder.Compile();
            return filterFunc;
        }
        public static Func<Tour, bool> BuildTourFilterFunc(EventFilterModelIn model)
        {
            var builder = PredicateBuilder.New<Tour>(true);

            if (model.DateDepart != null)
            {
                builder = builder.And(t => t.DateDepart == model.DateDepart);
            }

            if (model.Duration != null)
            {
                builder = builder.And(t => t.Duration.Equals(model.Duration));
            }

            var filterFunc = builder.Compile();
            return filterFunc;
        }
    }
}
