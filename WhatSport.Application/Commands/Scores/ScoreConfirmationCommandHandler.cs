using MediatR;
using WhatSport.Domain.Models;
using WhatSport.Domain.Repositories;

namespace WhatSport.Application.Commands.Scores
{
    internal class ScoreConfirmationCommandHandler : IRequestHandler<ScoreConfirmationCommand, bool>
    {
        private readonly IScoreRepository repository;
        private readonly IPlayerRepository repositoryPlayer;

        public ScoreConfirmationCommandHandler(IScoreRepository repository, IPlayerRepository repositoryPlayer)
        {
            this.repository = repository;
            this.repositoryPlayer = repositoryPlayer;
        }

        public async Task<bool> Handle(ScoreConfirmationCommand request, CancellationToken cancellationToken)
        {

            var player = await  repositoryPlayer.GetPlayerByMatchAndUserAsync(request.UserId, request.MatchId);

            if (player == null)
            {
                throw new ApplicationException("This user does not belong to this match.");
            }

            var scores = await repository.GetScoresAsync(request.MatchId, cancellationToken);

            if (scores == default || !scores.Any())
            {
                throw new ApplicationException("There are not results to this match!");
            }

            foreach (var score in scores)
            {
                if(score.ScoreConfirmations.Any(x => x.PlayerId == player.Id))
                {
                    throw new ApplicationException("This user already confirmed the match");
                }
                
                var value = new ScoreConfirmation
                {
                    ScoreId = score.Id,
                    Confirmed=true,
                    PlayerId = player.Id
                };
                await repository.AddScoreConfirmationAsync(value, cancellationToken);
                
            }

            return await repository.UnitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
