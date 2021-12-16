using MediatR;
using WhatSport.Application.Models;

namespace WhatSport.Application.Queries.Matches
{
    public  class PlayerQuery : IRequest<User[]>
    {
        public PlayerQuery(int matchId, int team)
        {
            this.MatchId = matchId;
            this.Team = team;
        }

        public int MatchId { get;  }
        public int Team { get; }
    }
}
