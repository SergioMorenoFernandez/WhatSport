namespace WhatSport.Domain.Models
{
    public class ClubSport
    {
        public int Id { get; set; }
        public int ClubId { get; set; }
        public Club? Club { get; set; }
        public int SportId { get; set; }
        public Sport? Sport { get; set; }

    }
}