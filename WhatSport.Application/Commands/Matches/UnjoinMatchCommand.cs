using MediatR;

namespace WhatSport.Application.Commands.Matches
{
    public  class UnjoinMatchCommand : IRequest<bool>
    {
        public UnjoinMatchCommand(int matchId, int userId)
        {
            MatchId = matchId;
            UserId = userId;

        }
        public int MatchId { get; }
        public int UserId { get; }
    }
}
