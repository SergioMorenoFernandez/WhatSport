using MediatR;

namespace WhatSport.Application.Commands.Scores
{
    public class ScoreConfirmationCommand : IRequest<bool>
    {
        public ScoreConfirmationCommand(int matchId, int userId)
        {
            MatchId = matchId;
            UserId = userId;
        }

        public int MatchId { get; }
        public int UserId { get; }

    }
}
