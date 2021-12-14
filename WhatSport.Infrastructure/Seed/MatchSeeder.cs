using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WhatSport.Domain.Models;

namespace WhatSport.Infrastructure.Seed
{
    public static class MatchSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var date = new System.DateTime(2021, 12, 01, 00, 00, 00);

            var cities = new List<Match>
            {
                new Match { Id = 1, SportId=1, DateStart=date.AddHours(12), DateEnd=date.AddHours(13),CityId=1},
                new Match { Id = 2, SportId=1, DateStart=date.AddDays(10).AddHours(12), DateEnd=date.AddDays(10).AddHours(13),CityId=1},
                new Match { Id = 3, SportId=1, DateStart=date.AddDays(30).AddHours(16), DateEnd=date.AddDays(30).AddHours(18),CityId=1},
                new Match { Id = 4, SportId=1, DateStart=date.AddDays(20).AddHours(20), DateEnd=date.AddDays(20).AddHours(21),CityId=1},
                new Match { Id = 5, SportId=1, DateStart=date.AddDays(38).AddHours(12), DateEnd=date.AddDays(38).AddHours(14),CityId=1},
                new Match { Id = 6, SportId=1, DateStart=date.AddDays(17).AddHours(16), DateEnd=date.AddDays(17).AddHours(17),CityId=2},
                new Match { Id = 7, SportId=2, DateStart=date.AddDays(16).AddHours(15), DateEnd=date.AddDays(16).AddHours(17),CityId=1},
                new Match { Id = 8, SportId=2, DateStart=date.AddDays(15).AddHours(12), DateEnd=date.AddDays(15).AddHours(13),CityId=2},
                new Match { Id = 9, SportId=2, DateStart=date.AddDays(30).AddHours(12), DateEnd=date.AddDays(30).AddHours(14),CityId=1},
                new Match { Id = 10, SportId=2, DateStart=date.AddDays(10).AddHours(12), DateEnd=date.AddDays(10).AddHours(14),CityId=3}
            };

            modelBuilder.Entity<Match>().HasData(cities);
        }
    }
}
