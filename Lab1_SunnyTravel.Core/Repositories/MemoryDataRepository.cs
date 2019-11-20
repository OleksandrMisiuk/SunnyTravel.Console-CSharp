using System;
using System.Collections.Generic;
using System.Linq;
using Lab1_SunnyTravel.Core.Entity;

namespace Lab1_SunnyTravel.Core.Repositories
{
    internal class MemoryDataRepository : IEventRepository, IFakeEventDataLoader
    {
        private readonly List<Hotel> _hotels = new List<Hotel>();

        public ICollection<Hotel> Where(Func<Hotel, bool> predicate)
        {
            return _hotels.Where(predicate).ToArray();
        }

        public void Load()
        {
            var country1 = new Country
            {
                Name = "Egypt",
                Cities = new List<City>()
            };

            var c1city1 = new City
            {
                Name = "Kom Jombo",
                Country = country1
            };

            var c1city2 = new City
            {
                Name = "Mol Kombo",
                Country = country1
            };

            country1.Cities.Add(c1city1);
            country1.Cities.Add(c1city2);

            var room1 = new Room
            {
                Type = "Luxe",
                Price = 1500,
                Seats = 2
            };

            var room2 = new Room
            {
                Type = "Standard",
                Price = 700,
                Seats = 2
            };

            var room3 = new Room
            {
                Type = "Medium",
                Price = 1150,
                Seats = 2
            };

            var room4 = new Room
            {
                Type = "Luxe",
                Price = 2200,
                Seats = 3
            };

            var room5 = new Room
            {
                Type = "Standard",
                Price = 850,
                Seats = 3
            };

            var room6 = new Room
            {
                Type = "Medium",
                Price = 1500,
                Seats = 3
            };

            var meal1 = new Meal
            {
                Type = "HB",
                Price = 200
            };

            var meal2 = new Meal
            {
                Type = "FB",
                Price = 700
            };

            var meal3 = new Meal
            {
                Type = "SB",
                Price = 350
            };

            var hotel1 = new Hotel
            {
                City = c1city1,
                Name = "Hotel Kom Jombo",
                Rating = 4,
                SeaDistance = 500,
                Meals = new List<Meal>(),
                Tours = new List<Tour>(),
                Rooms = new List<Room>()
            };

            var hotel2 = new Hotel
            {
                City = c1city2,
                Name = "Hotell Mol Kombo",
                Rating = 5,
                SeaDistance = 400,
                Meals = new List<Meal>(),
                Tours = new List<Tour>(),
                Rooms = new List<Room>()
            };

            hotel1.Rooms.Add(room1);
            hotel1.Rooms.Add(room2);
            hotel1.Rooms.Add(room3);
            hotel1.Rooms.Add(room6);
            hotel1.Rooms.Add(room4);

            hotel2.Rooms.Add(room1);
            hotel2.Rooms.Add(room4);
            hotel2.Rooms.Add(room5);
            hotel2.Rooms.Add(room6);
            hotel2.Rooms.Add(room3);

            hotel1.Meals.Add(meal1);
            hotel1.Meals.Add(meal2);
            hotel1.Meals.Add(meal3);

            hotel2.Meals.Add(meal1);
            hotel2.Meals.Add(meal2);
            hotel2.Meals.Add(meal3);

            var tour1 = new Tour
            {
                Description = "Best tour Egypt ever",
                DateDepart = new DateTime(2019, 09, 30),
                Duration = 7,
                Price = 10000,
                Hotel = hotel1
            };

            var tour2 = new Tour
            {
                Description = "Second Best tour Egypt ever",
                DateDepart = new DateTime(2019, 09, 29),
                Duration = 12,
                Price = 16075,
                Hotel = hotel1
            };

            var tour3 = new Tour
            {
                Description = "Third Best tour Egypt ever",
                DateDepart = new DateTime(2019, 10, 15),
                Duration = 10,
                Price = 12560,
                Hotel = hotel1
            };

            var tour5 = new Tour
            {
                Description = "Good tour Egypt",
                DateDepart = new DateTime(2019, 09, 5),
                Duration = 8,
                Price = 12650,
                Hotel = hotel2
            };

            var tour6 = new Tour
            {
                Description = "Good tour Egypt second",
                DateDepart = new DateTime(2019, 10, 20),
                Duration = 10,
                Price = 15250,
                Hotel = hotel2
            };

            var tour4 = new Tour
            {
                Description = "Third Good tour Egypt",
                DateDepart = new DateTime(2019, 10, 26),
                Duration = 9,
                Price = 14520,
                Hotel = hotel2
            };

            hotel1.Tours.Add(tour1);
            hotel1.Tours.Add(tour2);
            hotel1.Tours.Add(tour3);

            hotel2.Tours.Add(tour4);
            hotel2.Tours.Add(tour5);
            hotel2.Tours.Add(tour6);

            _hotels.Add(hotel1);
            _hotels.Add(hotel2);

        }
    }
}