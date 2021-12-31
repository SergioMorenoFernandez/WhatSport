using System;
using System.Collections.Generic;

namespace WhatSport.Domain.Models
{
    public class Match
    {
        public int Id { get; set; }
        public DateTime DateStart { get; set; } = DateTime.Now;
        public int TimeInMinutes { get; set; }
        //public DateTime DateEnd { get; set; } = DateTime.Now;
        public string OtherPlace { get; set; } = string.Empty;
        public string Note { get; set; } = string.Empty;

        public int SportId { get; set; }
        public Sport? Sport { get; set; }
        public int? ClubId { get; set; }
        public Club? Club { get; set; }

        public int? CityId { get; set; }
        public City? City { get; set; }

        public IEnumerable<Score> Scores { get; set; } = new List<Score>();
        public IEnumerable<Player> Players { get; set; } = new List<Player>();
        public IEnumerable<Equipment> Equipments { get; set; } = new List<Equipment>();
    }
}
