using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WhatSport.Domain.Models;

namespace WhatSport.Infrastructure.Seed
{
    public static class EquipmentSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var cities = new List<Equipment>
            {
                new Equipment { Id = 1, MatchId=9,Description="Red Voley"},
                new Equipment { Id = 2, MatchId=9,Description="Pelota", PlayerId=15},
            };

            modelBuilder.Entity<Equipment>().HasData(cities);
        }
    }
}
