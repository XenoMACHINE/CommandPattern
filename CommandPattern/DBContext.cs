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
    }
}
