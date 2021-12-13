using System.Collections.Generic;

namespace WhatSport.Domain.Models
{
    public class Player
    {
        public int Id { get; set; }
        public bool Assist { get; set; }
        public string Note { get; set; } = string.Empty;
        public int Team { get; set; }

        public int MatchId { get; set; }
        public Match? Match { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public IEnumerable<Equipment> Equipments { get; set; } = new List<Equipment>();
        public IEnumerable<ScoreConfirmation> ScoreConfirmations { get; set; } = new List<ScoreConfirmation>();
    }
}
