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
                new Sport{ Id = 1, Name = "Padel", NumberTimes = 3},
                new Sport{ Id = 2, Name = "Futbol", NumberTimes = 2}
            };

            modelBuilder.Entity<Sport>().HasData(sports);
        }
    }
}
