using MediatR;
using WhatSport.Application.Models;

namespace WhatSport.Application.Queries.Scores
{
    public class ScoreQuery : IRequest<ScoreDto[]>
    {
        public ScoreQuery(int matchId)
        {
            MatchId = matchId;
        }


        public int MatchId { get; }
    }
}
