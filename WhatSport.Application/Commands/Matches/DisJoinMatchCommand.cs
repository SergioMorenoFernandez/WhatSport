using MediatR;

namespace WhatSport.Application.Commands.Matches
{
    public  class DisJoinMatchCommand : IRequest<bool>
    {
        public DisJoinMatchCommand(int userId, int matchId)
        {
            UserId = userId;
            MatchId = matchId;

        }
        public int MatchId { get; set; }
        public int UserId { get;  }
    }
}
