using CourierAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourierAPI.Data
{
    public static class ModelBuilderExtensions
    {
        public static void SeedLocationDB(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Location>().HasData(
                new Location
                {
                    Id = 1,
                    Name = "Chandigarh"
                },
                new Location
                {
                    Id = 2,
                    Name = "Delhi"
                },
                new Location
                {
                    Id = 3,
                    Name = "Amritsar"
                },
                new Location
                {
                    Id = 4,
                    Name = "Shimla"
                },
                new Location
                {
                    Id = 5,
                    Name = "Mohali"
                },
                new Location
                {
                    Id = 6,
                    Name = "Panchkula"
                },
                new Location
                {
                    Id = 7,
                    Name = "Manali"
                }
            );
        }

        public static void SeedCourierDB(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Courier>().HasData(
                new Courier
                {
                    Id = 1,
                    FromName="Ravi Sharma",
                    FromAddress="111, Sector 11, chandigarh",
                    FromContactNumber="9876543210",
                    ToName="Saroj Sharma",
                    ToAddress="1232/A, Pahadganj, New Delhi",
                    ToContactNumber="011-4345632",
                    LocationId=1,
                    Insured="Yes"
                }
            );
        }
    }
}
