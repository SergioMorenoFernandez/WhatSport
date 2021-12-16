using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WhatSport.Domain.Models;

namespace WhatSport.Infrastructure.Seed
{
    public static class SportSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var sports = new List<Sport>
            {
                new Sport{ Id = 1, Name = "Padel", NumberTimes = 3,NumberPlayers=4},
                new Sport{ Id = 2, Name = "Voley-Playa", NumberTimes = 2,NumberPlayers=6}
            };

            modelBuilder.Entity<Sport>().HasData(sports);
        }
    }
}
