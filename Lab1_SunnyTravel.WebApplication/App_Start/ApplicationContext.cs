using Lab1_SunnyTravel.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab1_SunnyTravel.WebApplication.App_Start
{
    public class ApplicationContext: DbContext
    {
        public DbSet<Country> Country { get; set; }
        public DbSet<Hotel> Hotel { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Tour> Package { get; set; }
        public DbSet<Meal> Meal { get; set; }
        public DbSet<Room> Room { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=TravelAgency;Username=postgres;Password=1111");
        }
    }
}