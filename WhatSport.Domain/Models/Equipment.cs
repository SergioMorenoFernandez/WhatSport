namespace WhatSport.Domain.Models
{
    public class Equipment
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Number { get; set; }
        public int MatchId { get; set; }
        public Match? Match { get; set; }
        public int PlayerId { get; set; }
        public Player? Player { get; set; }
    }
}
