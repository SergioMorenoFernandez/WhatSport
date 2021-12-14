using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WhatSport.Domain.Models;

namespace WhatSport.Infrastructure.Seed
{
    public static class CitySeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var cities = new List<City>
            {
                new City { Id = 1, Name = "Málaga", CountryId = 1 },
                new City { Id = 2, Name = "Granada", CountryId = 1 },
                new City { Id = 3, Name = "Barcelona", CountryId = 1 }
            };

            modelBuilder.Entity<City>().HasData(cities);
        }
    }
}
