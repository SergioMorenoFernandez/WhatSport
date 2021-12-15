using MediatR;
using WhatSport.Domain.Models;
using WhatSport.Domain.Repositories;

namespace WhatSport.Application.Queries.Matches
{
    internal class MatchTotalQueryHandler : IRequestHandler<MatchTotalQuery,long>
    {
        private readonly IMatchRepository repository;

        public MatchTotalQueryHandler(IMatchRepository repository)
        {
            this.repository = repository;
        }

        public async Task<long> Handle(MatchTotalQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Match> value;

            if (request.UserId.HasValue)
            {
                value = await repository.GetMatchByUserAsync(request.SportId, request.UserId.Value, cancellationToken);
            }
            else
            {
                value = await repository.GetMatchBySportAsync(request.SportId, cancellationToken);
            }

            return value.Count();
        }


    }
}
