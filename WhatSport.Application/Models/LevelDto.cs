namespace WhatSport.Application.Models
{
    public class LevelDto
    {
        public LevelDto(Domain.Models.Level level)
        {
            Id = level.Id;
            SportName = level.Sport?.Name ?? throw new ArgumentException("Sport of level cannot be null");
            NumLevel = level.NumLevel;
        }

        public int Id { get; }
        public string SportName { get; }
        public int NumLevel { get; }
    }
}
