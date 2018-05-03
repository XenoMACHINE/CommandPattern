using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CommandPattern
{
    public class DBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<People> Peoples { get; set; }
        public DbSet<Car> Cars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source =database.db");
        }

        public void showAll()
        {
            Console.WriteLine("------------------- PEOPLES -------------------");
            showPeoples();
            Console.WriteLine("-------------------- CARS ---------------------");
            showCars();
            Console.WriteLine("-----------------------------------------------");

        }

        public void showUsers(){
            foreach (User user in Users){
                Console.WriteLine(user);
            }
        }

        public void showPeoples()
        {
            foreach (People people in Peoples)
            {
                Console.WriteLine(people);
            }
        }

        public void showCars()
        {
            foreach (Car car in Cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
