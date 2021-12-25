namespace WhatSport.Domain.Models
{
    public class Equipment
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public int MatchId { get; set; }
        public Match? Match { get; set; }
        public int? PlayerId { get; set; }
        public Player? Player { get; set; }
    }
}
