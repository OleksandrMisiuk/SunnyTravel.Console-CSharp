using Autofac;
using Lab1_SunnyTravel.Core;
using Lab1_SunnyTravel.Core.Entity;
using Lab1_SunnyTravel.Core.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Lab1_SunnyTravel.WFProject
{
    public partial class Form1 : Form
    {
        private static IFakeEventDataLoader fakeLoader;
        private static IEventRepository repository;
        public Form1(ILifetimeScope scope)
        {
            InitializeComponent();
            fakeLoader = scope.Resolve<IFakeEventDataLoader>();
            fakeLoader.Load();
            repository = scope.Resolve<IEventRepository>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var model = this.GetUserRequeriments();
            var filterFunc = FilterFuncHelper.BuildHotelFilterFunc(model);
            var filterFuncRoom = FilterFuncHelper.BuildRoomFilterFunc(model);
            var filterFuncMeal = FilterFuncHelper.BuildMealFilterFunc(model);
            var filterFuncTour = FilterFuncHelper.BuildTourFilterFunc(model);

            textBox3.Clear();

            var hotels = repository.Where(filterFunc);

            if (hotels == null || !hotels.Any())
            {
                textBox3.Text = "No Result";
            }

            //filter nested collections
            foreach (var hotel in hotels)
            {
                hotel.Meals = hotel.Meals.Where(filterFuncMeal).ToArray();
                hotel.Tours = hotel.Tours.Where(filterFuncTour).ToArray();
                hotel.Rooms = hotel.Rooms.Where(filterFuncRoom).ToArray();
            }

            this.PrintResults(hotels);
        }

        private EventFilterModelIn GetUserRequeriments()
        {
            var filterModel = new EventFilterModelIn();
            filterModel.CountryPartName = textBox1.Text;
            filterModel.CityPartName = textBox2.Text;
            if (dateTimePicker1.Value.Date != DateTime.Today)
            {
                filterModel.DateDepart = dateTimePicker1.Value.Date;
            }
            filterModel.NumberOfPeople = Decimal.ToInt32(numericUpDown2.Value);
            filterModel.Duration = Decimal.ToInt32(numericUpDown1.Value);
            filterModel.MinSeaDistance = Decimal.ToInt32(numericUpDown3.Value);
            filterModel.MinHotelRating = Decimal.ToInt32(numericUpDown4.Value);
            if (listBox1.SelectedItem != null)
            {
                filterModel.RoomType = listBox1.SelectedItem.ToString();
                Console.WriteLine(filterModel.RoomType);
            }
            if (listBox2.SelectedItem != null)
            {
                filterModel.Meal = listBox2.SelectedItem.ToString();
            }
            return filterModel;
        }

        private void PrintResults(ICollection<Hotel> hotels)
        {
            foreach (var @hotel in hotels)
            {
                var newLine = Environment.NewLine;
                textBox3.AppendText($"Country Name: {@hotel.City.Country.Name}" + newLine);
                textBox3.AppendText($"City Name: {@hotel.City.Name}" + newLine);
                textBox3.AppendText($"Hotel Name: {@hotel.Name}" + newLine);
                textBox3.AppendText($"Rating: {@hotel.Rating}" + newLine);
                textBox3.AppendText($"Sea Distance: {@hotel.SeaDistance}" + newLine);
                var shiftPrefix = string.Empty.PadLeft(5);
                var shiftPrefix2X = string.Empty.PadLeft(10);
                textBox3.AppendText($"{shiftPrefix}Rooms:" + newLine);
                foreach (var room in @hotel.Rooms)
                {
                    textBox3.AppendText($"{shiftPrefix2X}Name: {room.Type}" + newLine);
                    textBox3.AppendText($"{shiftPrefix2X}Price: {room.Price}" + newLine);
                    textBox3.AppendText($"{shiftPrefix2X}Seats: {room.Seats}" + newLine);
                }

                textBox3.AppendText($"{shiftPrefix}Meals:" + newLine);
                foreach (var meal in @hotel.Meals)
                {
                    textBox3.AppendText($"{shiftPrefix2X}Name: {meal.Type}" + newLine);
                    textBox3.AppendText($"{shiftPrefix2X}Price: {meal.Price}" + newLine);
                }
                textBox3.AppendText($"{shiftPrefix}Tours:" + newLine);
                foreach (var tour in @hotel.Tours)
                {
                    textBox3.AppendText($"{shiftPrefix2X}Name: {tour.Description}" + newLine);
                    textBox3.AppendText($"{shiftPrefix2X}Price: {tour.Price}" + newLine);
                    textBox3.AppendText($"{shiftPrefix2X}Duration: {tour.Duration}" + newLine);
                    textBox3.AppendText($"{shiftPrefix2X}DateDepart: {tour.DateDepart}" + newLine);
                }
                textBox3.AppendText("\n".PadLeft(25, '-') + newLine);
            }
        }
    }
}
