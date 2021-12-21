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

            var player = repositoryPlayer.GetPlayerByMatchAndUserAsync(request.UserId, request.MatchId);

            var scores = await repository.GetScoresAsync(request.MatchId, cancellationToken);

            foreach(var score in scores)
            {
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
