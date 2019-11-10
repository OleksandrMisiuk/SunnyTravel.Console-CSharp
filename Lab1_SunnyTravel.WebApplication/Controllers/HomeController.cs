using Lab1_SunnyTravel.Core.Entity;
using Lab1_SunnyTravel.WebApplication.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
                hotels = db.Hotel.ToList();
            }
            return hotels;
        }
    }
}
