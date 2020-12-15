using CourierAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourierAPI.Data
{
    public class CourierDBContext : DbContext
    {
        public CourierDBContext(DbContextOptions<CourierDBContext> options)
            :base(options)
        {

        }

        public DbSet<Location> Locations { get; set; }
        public DbSet<Courier> Couriers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedLocationDB();
            modelBuilder.SeedCourierDB();
        }
    }
}
