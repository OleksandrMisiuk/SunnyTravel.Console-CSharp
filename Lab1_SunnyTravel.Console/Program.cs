using System;
using System.Collections.Generic;
using Autofac;
using System.Linq;
using Lab1_SunnyTravel.Core;
using Lab1_SunnyTravel.Core.Entity;
using Lab1_SunnyTravel.Core.Models;
using LinqKit;

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
                    var filterFunc = BuildFilterFunc(model);

                    var repository = scope.Resolve<IEventRepository>();
                    var events = repository.Where(filterFunc);
                    PrintEvents(events);

                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        private static Func<Hotel, bool> BuildFilterFunc(EventFilterModelIn model)
        {

            var builder = PredicateBuilder.New<Hotel>(true);

            // IndexOf has StringComparison
            if (!model.CityPartName.IsNullOrEmpty())
            {
                builder = builder.And(e => e.City.Name.IndexOf(model.CityPartName, StringComparison.OrdinalIgnoreCase) >= 0);
            }

            if (!model.CountryPartName.IsNullOrEmpty())
            {
                builder = builder.And(e => e.City.Country.Name.IndexOf(model.CountryPartName, StringComparison.OrdinalIgnoreCase) >= 0);
            }

            if (model.DateDepart != null)
            {
                builder = builder.And(e => e.Tours.Any(t => t.DateDepart == model.DateDepart));
            }

            if (model.Duration != null)
            {
                builder = builder.And(e => e.Tours.Any(t => t.Duration.Equals(model.Duration)));
            }

            if (model.Meal != null)
            {
                builder = builder.And(e => e.Meals.Any(t => t.Type.IndexOf(model.Meal, StringComparison.OrdinalIgnoreCase) >= 0));
            }

            if (model.MinHotelRating != null)
            {
                builder = builder.And(e => e.Rating >= model.MinHotelRating);
            }

            if (model.MinSeaDistance != null)
            {
                builder = builder.And(e => e.SeaDistance <= model.MinSeaDistance);
            }

            if (model.NumberOfPeople != null)
            {
                builder = builder.And(e => e.Rooms.Any(t => t.Seats.Equals(model.NumberOfPeople)));
            }

            if (model.RoomType != null)
            {
                builder = builder.And(e => e.Rooms.Any(t => t.Type.IndexOf(model.RoomType, StringComparison.OrdinalIgnoreCase) >= 0));
            }

            var filterFunc = builder.Compile();
            return filterFunc;
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
                Console.WriteLine($"{shiftPrefix}Rooms:");
                foreach (var room in @hotel.Rooms)
                {
                    Console.WriteLine($"{shiftPrefix}Name: {room.Type}");
                    Console.WriteLine($"{shiftPrefix}Price: {room.Price}");
                    Console.WriteLine($"{shiftPrefix}Seats: {room.Seats}");
                }
                Console.WriteLine($"{shiftPrefix}Meals:");
                foreach (var meal in @hotel.Meals)
                {
                    Console.WriteLine($"{shiftPrefix}Name: {meal.Type}");
                    Console.WriteLine($"{shiftPrefix}Price: {meal.Price}");
                }
                Console.WriteLine($"{shiftPrefix}Tours:");
                foreach (var tour in @hotel.Tours)
                {
                    Console.WriteLine($"{shiftPrefix}Name: {tour.Description}");
                    Console.WriteLine($"{shiftPrefix}Price: {tour.Price}");
                    Console.WriteLine($"{shiftPrefix}Seats: {tour.Duration}");
                    Console.WriteLine($"{shiftPrefix}Seats: {tour.DateDepart}");
                }
                Console.WriteLine("\n".PadLeft(25, '-'));
            }
        }
    }
}
