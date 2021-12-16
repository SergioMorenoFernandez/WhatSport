using System.Collections.Generic;

namespace WhatSport.Domain.Models
{
    public class Sport
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int NumberTimes { get; set; }
        
        public int NumberPlayers { get; set; }
        public IEnumerable<Level> Levels { get; set; } = new List<Level>();
        public IEnumerable<Match> Matches { get; set; } = new List<Match>();
        public IEnumerable<ClubSport> ClubSports { get; set; } = new List<ClubSport>();
    }
}
