using MediatR;
using WhatSport.Application.Models;
using WhatSport.Domain.Repositories;

namespace WhatSport.Application.Queries.Matches
{
    internal class MatchByIdQueryHandler : IRequestHandler<MatchByIdQuery, Match>
    {
        private readonly IMatchRepository repository;

        public MatchByIdQueryHandler(IMatchRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Match> Handle(MatchByIdQuery request, CancellationToken cancellationToken)
        {
            var club = await repository.GetMatchByIdAsync(request.Id, cancellationToken);

            return new Match(club);
        }
    }
}
