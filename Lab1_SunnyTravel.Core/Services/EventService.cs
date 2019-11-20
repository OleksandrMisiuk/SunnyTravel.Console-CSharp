using System.Collections.Generic;
using System.Linq;
using Lab1_SunnyTravel.Core.Entity;
using Lab1_SunnyTravel.Core.Extensions;
using Lab1_SunnyTravel.Core.Models;
using Lab1_SunnyTravel.Core.Repositories;

namespace Lab1_SunnyTravel.Core.Services
{
    internal class EventService : IEventService
    {
        private readonly IEventRepository _repository;

        public EventService(IEventRepository repository)
        {
            _repository = repository;
        }

        public ICollection<Hotel> GetFilteredHotels(EventFilterModelIn model, bool filterNestedCollections = true)
        {
            var filterFunc = FilterFuncHelper.BuildHotelFilterFunc(model);
            var hotels = _repository.Where(filterFunc);

            if (filterNestedCollections && !hotels.IsNullOrEmpty())
            {
                var filterFuncRoom = FilterFuncHelper.BuildRoomFilterFunc(model);
                var filterFuncMeal = FilterFuncHelper.BuildMealFilterFunc(model);
                var filterFuncTour = FilterFuncHelper.BuildTourFilterFunc(model);

                //filter nested collections
                foreach (var hotel in hotels)
                {
                    hotel.Meals = hotel.Meals.Where(filterFuncMeal).ToArray();
                    hotel.Tours = hotel.Tours.Where(filterFuncTour).ToArray();
                    hotel.Rooms = hotel.Rooms.Where(filterFuncRoom).ToArray();
                }
            }

            return hotels;
        }
    }
}