using System.Collections.Generic;

namespace WhatSport.Domain.Models
{
    public class Club
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int PostalCode { get; set; }
        public int CityId { get; set; }
        public City? City { get; set; }
        public IEnumerable<Match> Matches { get; set; } = new List<Match>();
        public IEnumerable<ClubSport> ClubSports { get; set; } = new List<ClubSport>();
    }
}
