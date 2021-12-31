using MediatR;
using WhatSport.Application.Models;
using WhatSport.Domain.Repositories;

namespace WhatSport.Application.Queries.Scores
{
    internal class ScoreQueryHandler : IRequestHandler<ScoreQuery, ScoreDto[]>
    {
        private readonly IScoreRepository repository;

        public ScoreQueryHandler(IScoreRepository repository)
        {
            this.repository = repository;
        }

        public async Task<ScoreDto[]> Handle(ScoreQuery request, CancellationToken cancellationToken)
        {
            var result = await repository.GetScoresAsync(request.MatchId, cancellationToken);

            return result.Select(c => new ScoreDto(c)).OrderBy(x => x.Team).ThenBy(x => x.NumberTimes).ToArray();
        }
    }
}
