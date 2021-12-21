using MediatR;

namespace WhatSport.Application.Commands.Scores
{
    public class ScoreCommand : IRequest<bool>
    {
        public ScoreCommand(int value, int Number, int Team)
        {
            this.Value = value;
            this.Number = Number;
            this.Team = Team;
        }

        public int Value { get; }
        public int Number { get;}
        public int Team { get; }
        public int MatchId { get; set; }


    }
}
