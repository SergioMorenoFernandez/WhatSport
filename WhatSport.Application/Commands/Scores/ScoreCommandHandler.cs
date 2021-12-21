using MediatR;
using WhatSport.Domain.Models;
using WhatSport.Domain.Repositories;

namespace WhatSport.Application.Commands.Scores
{
    internal class ScoreCommandHandler : IRequestHandler<ScoreCommand, bool>
    {
        private readonly IScoreRepository repository;

        public ScoreCommandHandler(IScoreRepository repository)
        {
            this.repository = repository;
        }

        public async Task<bool> Handle(ScoreCommand request, CancellationToken cancellationToken)
        {

            var score = new Score
            {
                MatchId = request.MatchId,
                Team=request.Team,
                Value = request.Value
            };

            await repository.AddScoreAsync(score, cancellationToken);

            return await repository.UnitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
