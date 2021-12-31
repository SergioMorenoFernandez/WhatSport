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
                new Match { Id = 1, SportId=1, DateStart=date.AddHours(12), TimeInMinutes =60,CityId=1, OtherPlace="Pistas de carranque"},
                new Match { Id = 2, SportId=1, DateStart=date.AddDays(10).AddHours(12), TimeInMinutes =60,CityId=1, OtherPlace="Urb. lolo",Note="Test note 1" },
                new Match { Id = 3, SportId=1, DateStart=date.AddDays(30).AddHours(16), TimeInMinutes =90,CityId=1, OtherPlace="Pistas la mosca"},
                new Match { Id = 4, SportId=1, DateStart=date.AddDays(20).AddHours(20), TimeInMinutes =90, OtherPlace="Urb. las gaviotas",Note="Test note fff"},
                new Match { Id = 5, SportId=1, DateStart=date.AddDays(38).AddHours(12), TimeInMinutes =90,CityId=1, OtherPlace="Urb. el Almendro"},
                new Match { Id = 6, SportId=1, DateStart=date.AddDays(17).AddHours(16), TimeInMinutes =120,CityId=2, OtherPlace="Pistas de gimnasio turu",Note="Test note afgds"},
                new Match { Id = 7, SportId=2, DateStart=date.AddDays(16).AddHours(15), TimeInMinutes =60,CityId=1, OtherPlace="Playa de huelin"},
                new Match { Id = 8, SportId=2, DateStart=date.AddDays(15).AddHours(12), TimeInMinutes =90,CityId=2, OtherPlace="Sacaba"},
                new Match { Id = 9, SportId=2, DateStart=date.AddDays(30).AddHours(12), TimeInMinutes =120,CityId=1, OtherPlace="Parque badajo",Note="Test note voley 1"},
                new Match { Id = 10, SportId=2, DateStart=date.AddDays(10).AddHours(12), TimeInMinutes =60,CityId=3, OtherPlace="Pista voley carranque"}
            };

            modelBuilder.Entity<Match>().HasData(cities);
        }
    }
}
