using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WhatSport.Domain.Models;

namespace WhatSport.Infrastructure.Seed
{
    public static class CountrySeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var countries = new List<Country>
            {
                new Country { Id = 1, Name = "España" }
            };

            modelBuilder.Entity<Country>().HasData(countries);
        }
    }
}
