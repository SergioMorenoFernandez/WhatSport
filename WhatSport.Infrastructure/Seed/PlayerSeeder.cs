using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WhatSport.Domain.Models;

namespace WhatSport.Infrastructure.Seed
{
    public static class PlayerSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var cities = new List<Player>
            {
                new Player { Id = 1, UserId=1,MatchId=1,Team=1,Assist=true },
                new Player { Id = 2, UserId=2,MatchId=1,Team=2,Assist=false },
                new Player { Id = 3, UserId=3,MatchId=1,Team=1,Assist=true },
                new Player { Id = 4, UserId=1,MatchId=2,Team=1 },
                new Player { Id = 5, UserId=2,MatchId=2,Team=1 },
                new Player { Id = 6, UserId=3,MatchId=2,Team=2 },
                new Player { Id = 7, UserId=4,MatchId=2,Team=2 },
                new Player { Id = 8, UserId=3,MatchId=3,Team=1 },
                new Player { Id = 9, UserId=4,MatchId=4,Team=1 },
                new Player { Id = 10, UserId=4,MatchId=4,Team=1 },
                new Player { Id = 11, UserId=5,MatchId=5,Team=1 },
                new Player { Id = 12, UserId=5,MatchId=6,Team=1 },
                new Player { Id = 13, UserId=6,MatchId=10,Team=1 },
                new Player { Id = 14, UserId=5,MatchId=9,Team=1 },
                new Player { Id = 15, UserId=1,MatchId=9,Team=2 },
                new Player { Id = 16, UserId=4,MatchId=9,Team=2 },
            };

            modelBuilder.Entity<Player>().HasData(cities);
        }
    }
}
