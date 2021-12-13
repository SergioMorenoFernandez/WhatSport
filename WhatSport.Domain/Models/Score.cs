using System.Collections.Generic;

namespace WhatSport.Domain.Models
{
    public class Score
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public int Number { get; set; }
        public int Team { get; set; }
        public int MatchId { get; set; }
        public Match? Match { get; set; }
        public IEnumerable<ScoreConfirmation> ScoreConfirmations { get; set; } = new List<ScoreConfirmation>();
    }
}
