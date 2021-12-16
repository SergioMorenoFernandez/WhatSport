using MediatR;

namespace WhatSport.Application.Commands.Matches
{
    public  class JoinMatchCommand : IRequest<bool>
    {
        public JoinMatchCommand(int userId, int team, int matchId)
        {
            Team = team;
            UserId = userId;
            MatchId = matchId;

        }
        public int MatchId { get; }
        public int Team { get; }
        public int UserId { get;  }
    }
}
