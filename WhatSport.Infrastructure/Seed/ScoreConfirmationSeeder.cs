using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WhatSport.Domain.Models;

namespace WhatSport.Infrastructure.Seed
{
    public static class ScoreConfirmationSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var cities = new List<ScoreConfirmation>
            {
                new ScoreConfirmation { Id = 1, Confirmed=true, ScoreId=1,PlayerId=1 },
                new ScoreConfirmation { Id = 2, Confirmed=true, ScoreId=2,PlayerId=1 },
                new ScoreConfirmation { Id = 3, Confirmed=true, ScoreId=3,PlayerId=1 },
                new ScoreConfirmation { Id = 4, Confirmed=true, ScoreId=4,PlayerId=1 },
                new ScoreConfirmation { Id = 5, Confirmed=true, ScoreId=5,PlayerId=1 },
                new ScoreConfirmation { Id = 6, Confirmed=true, ScoreId=6,PlayerId=1 },
                new ScoreConfirmation { Id = 7, Confirmed=true, ScoreId=1,PlayerId=3 },
                new ScoreConfirmation { Id = 8, Confirmed=true, ScoreId=2,PlayerId=3 },
                new ScoreConfirmation { Id = 9, Confirmed=true, ScoreId=3,PlayerId=3 },
                new ScoreConfirmation { Id = 10, Confirmed=true, ScoreId=4,PlayerId=3 },
                new ScoreConfirmation { Id = 11, Confirmed=true, ScoreId=5,PlayerId=3 },
                new ScoreConfirmation { Id = 12, Confirmed=true, ScoreId=6,PlayerId=3 },
            };

            modelBuilder.Entity<ScoreConfirmation>().HasData(cities);
        }
    }
}
