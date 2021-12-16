using MediatR;
using WhatSport.Application.Models;

namespace WhatSport.Application.Queries.Matches
{
    public  class PlayerQuery : IRequest<User[]>
    {
        public PlayerQuery(int matchId)
        {
            this.MatchId = matchId;
        }

        public int MatchId { get;  }
    }
}
