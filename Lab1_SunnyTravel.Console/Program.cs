using System;
using System.Collections.Generic;
using Autofac;
using System.Linq;
using Lab1_SunnyTravel.Core;
using Lab1_SunnyTravel.Core.Entity;
using Lab1_SunnyTravel.Core.Models;

namespace Lab1_SunnyTravel.ConsoleProject
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = CreateContainer();
            using (var scope = container.BeginLifetimeScope())
            {
                var fakeLoader = scope.Resolve<IFakeEventDataLoader>();
                fakeLoader.Load();

                while (true)
                {
                    var model = GetUserRequirements();
                    var filterFunc = FilterFuncHelper.BuildHotelFilterFunc(model);
                    var filterFuncRoom = FilterFuncHelper.BuildRoomFilterFunc(model);
                    var filterFuncMeal = FilterFuncHelper.BuildMealFilterFunc(model);
                    var filterFuncTour = FilterFuncHelper.BuildTourFilterFunc(model);

                    var repository = scope.Resolve<IEventRepository>();
                    var hotels = repository.Where(filterFunc);

                    if(hotels == null || !hotels.Any())
                    {
                        Console.WriteLine("No results.");
                        continue;
                    }

                    //filter nested collections
                    foreach (var hotel in hotels)
                    {
                        hotel.Meals = hotel.Meals.Where(filterFuncMeal).ToArray();
                        hotel.Tours = hotel.Tours.Where(filterFuncTour).ToArray();
                        hotel.Rooms = hotel.Rooms.Where(filterFuncRoom).ToArray();
                    }

                    PrintEvents(hotels);

                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        private static EventFilterModelIn GetUserRequirements()
        {
            // todo: use reflection
            var filterModel = new EventFilterModelIn();
            filterModel.CountryPartName = GetValue(nameof(filterModel.CountryPartName));

            filterModel.CityPartName = GetValue(nameof(filterModel.CityPartName));

            filterModel.DateDepart = GetValue(nameof(filterModel.DateDepart))
                .TryToType<DateTime>();

            filterModel.Duration = GetValue(nameof(filterModel.Duration))
                .TryToType<int>();

            filterModel.MinHotelRating = GetValue(nameof(filterModel.MinHotelRating))
                .TryToType<int>();

            filterModel.MinSeaDistance = GetValue(nameof(filterModel.MinSeaDistance))
                .TryToType<int>();

            filterModel.NumberOfPeople = GetValue(nameof(filterModel.NumberOfPeople))
                .TryToType<int>();

            filterModel.Meal = GetValue(nameof(filterModel.Meal));

            filterModel.RoomType = GetValue(nameof(filterModel.RoomType));


            return filterModel;
        }

        private static string GetValue(string parameterName)
        {
            Console.Write($"Please enter {parameterName}(press enter to skip): ");
            var value = Console.ReadLine();
            return value;
        }

        private static IContainer CreateContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<MemoryDataRepository>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            return builder.Build();
        }

        private static void PrintEvents(ICollection<Hotel> hotels)
        {
            foreach (var @hotel in hotels)
            {
                Console.WriteLine($"Country Name: {@hotel.City.Country.Name}");
                Console.WriteLine($"City Name: {@hotel.City.Name}");
                Console.WriteLine($"Hotel Name: {@hotel.Name}");
                Console.WriteLine($"Rating: {@hotel.Rating}");
                Console.WriteLine($"Sea Distance: {@hotel.SeaDistance}");
                var shiftPrefix = string.Empty.PadLeft(5);
                var shiftPrefix2X = string.Empty.PadLeft(10);
                Console.WriteLine($"{shiftPrefix}Rooms:");
                foreach (var room in @hotel.Rooms)
                {
                    Console.WriteLine($"{shiftPrefix2X}Name: {room.Type}");
                    Console.WriteLine($"{shiftPrefix2X}Price: {room.Price}");
                    Console.WriteLine($"{shiftPrefix2X}Seats: {room.Seats}");
                }
                Console.WriteLine($"{shiftPrefix}Meals:");
                foreach (var meal in @hotel.Meals)
                {
                    Console.WriteLine($"{shiftPrefix2X}Name: {meal.Type}");
                    Console.WriteLine($"{shiftPrefix2X}Price: {meal.Price}");
                }
                Console.WriteLine($"{shiftPrefix}Tours:");
                foreach (var tour in @hotel.Tours)
                {
                    Console.WriteLine($"{shiftPrefix2X}Name: {tour.Description}");
                    Console.WriteLine($"{shiftPrefix2X}Price: {tour.Price}");
                    Console.WriteLine($"{shiftPrefix2X}Duration: {tour.Duration}");
                    Console.WriteLine($"{shiftPrefix2X}DateDepart: {tour.DateDepart}");
                }
                Console.WriteLine("\n".PadLeft(25, '-'));
            }
        }
    }
}
