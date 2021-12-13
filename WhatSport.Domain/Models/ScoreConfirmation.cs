namespace WhatSport.Domain.Models
{
    public class ScoreConfirmation
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public Player? Player { get; set; }
        public int ScoreId { get; set; }
        public Score? Score { get; set; }
        public bool Confirmed { get; set; }        
    }
}
