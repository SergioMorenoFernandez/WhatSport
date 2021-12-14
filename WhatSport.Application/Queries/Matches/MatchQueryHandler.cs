using MediatR;
using WhatSport.Application.Models;
using WhatSport.Domain.Repositories;

namespace WhatSport.Application.Queries.Matches
{
    internal class MatchQueryHandler : IRequestHandler<MatchQuery, Match[]>
    {
        private readonly IMatchRepository repository;

        public MatchQueryHandler(IMatchRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Match[]> Handle(MatchQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Domain.Models.Match> value;

            if (request.UserId.HasValue)
            {
                value = await repository.GetMatchByUserAsync(request.SportId, request.UserId.Value, cancellationToken);
            }
            else
            {
                value  = await repository.GetMatchBySportAsync(request.SportId, cancellationToken);
            }

            return value.Select(c => new Match(c)).ToArray();
        }

    }


}
