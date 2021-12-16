namespace WhatSport.Application.Models
{
    public class Sport
    {
        public Sport(Domain.Models.Sport sport)
        {
            Id = sport.Id;
            Name = sport.Name;
            NumberTimes = sport.NumberTimes;
            NumberPlayers = sport.NumberPlayers;
        }

        public int Id { get; }
        public string Name { get; }

        public int NumberTimes { get;  }

        public int NumberPlayers { get; }
    }
}