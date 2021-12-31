using WhatSport.Domain.Models;

namespace WhatSport.Application.Models
{
    public class ScoreDto
    {
        public ScoreDto(Score score)
        {
            Value = score.Value;
            NumberTimes = score.Number;
            Team = score.Team;
        }

        public int Value { get; }
        public int NumberTimes { get; }

        public int Team { get; }
    }
}
