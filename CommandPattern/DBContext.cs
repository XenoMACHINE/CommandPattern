using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CommandPattern
{
    public class DBContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source =database.db");
        }
    }
}
