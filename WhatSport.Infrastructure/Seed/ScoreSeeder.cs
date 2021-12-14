using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WhatSport.Domain.Models;

namespace WhatSport.Infrastructure.Seed
{
    public static class ScoreSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var cities = new List<Score>
            {
                new Score { Id = 1, MatchId=1,Number=1,Value=6,Team=1 },
                new Score { Id = 2, MatchId=1,Number=1,Value=2,Team=2 },
                new Score { Id = 3, MatchId=1,Number=2,Value=3,Team=1 },
                new Score { Id = 4, MatchId=1,Number=2,Value=6,Team=2 },
                new Score { Id = 5, MatchId=1,Number=3,Value=6,Team=1 },
                new Score { Id = 6, MatchId=1,Number=3,Value=0,Team=2 },
                new Score { Id = 7, MatchId=2,Number=1,Value=6,Team=1 },
                new Score { Id = 8, MatchId=2,Number=1,Value=2,Team=2 },
                new Score { Id = 9, MatchId=2,Number=2,Value=6,Team=1 },
                new Score { Id = 10, MatchId=2,Number=2,Value=3,Team=2 },
            };

            modelBuilder.Entity<Score>().HasData(cities);
        }
    }
}
