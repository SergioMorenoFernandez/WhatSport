using MediatR;
using WhatSport.Domain.Repositories;

namespace WhatSport.Application.Queries.Scores
{
    internal class ScoreConfirmationHandler : IRequestHandler<ScoreConfirmationQuery, int>
    {
        private readonly IScoreRepository repository;

        public ScoreConfirmationHandler(IScoreRepository repository)
        {
            this.repository = repository;
        }

        public async Task<int> Handle(ScoreConfirmationQuery request, CancellationToken cancellationToken)
        {
            var result = await repository.GetScoresAsync(request.MatchId, cancellationToken);

            if(!result.Any())
            {
                return 0;
            }

            return result.First().ScoreConfirmations.Count();
        }
    }
}
