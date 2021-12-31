using MediatR;

namespace WhatSport.Application.Queries.Scores
{
    public class ScoreConfirmationQuery : IRequest<int>
    {
        public ScoreConfirmationQuery(int matchId)
        {
            MatchId = matchId;
        }


        public int MatchId { get; }
    }
}
