namespace WhatSport.Domain.Models
{
    public class Level
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public int SportId { get; set; }
        public Sport? Sport { get; set; }
        public int NumLevel { get; set; }
    }
}
