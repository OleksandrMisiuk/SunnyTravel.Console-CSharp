using Lab1_SunnyTravel.Core.Entity;
using Lab1_SunnyTravel.WebApplication.App_Start;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Lab1_SunnyTravel.WebApplication.Controllers
{
    public class HomeController : ApiController
    {
        public IEnumerable<Hotel> Get()
        {
            List<Hotel> hotels = new List<Hotel>();
            using (ApplicationContext db = new ApplicationContext())
            {
                db.GetService<ILoggerFactory>().AddProvider(new MyLoggerProvider());

                hotels = db.Hotel
                    .Include(hotel=> hotel.City)
                        .ThenInclude(city => city.Country)
                    .Include(hotel => hotel.Meals)
                    .Include(hotel => hotel.Rooms)
                    .Include(hotel => hotel.Tours)
                    .ToList();
            }
            return hotels;
        }
    }
}
