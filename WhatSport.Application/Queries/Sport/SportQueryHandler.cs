using MediatR;
using WhatSport.Application.Models;
using WhatSport.Domain.Repositories;

namespace WhatSport.Application.Queries.Users
{
    internal class SportQueryHandler : IRequestHandler<SportQuery, Sport[]>
    {
        private readonly ISportRepository repository;

        public SportQueryHandler(ISportRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Sport[]> Handle(SportQuery request, CancellationToken cancellationToken)
        {
            var value = await repository.GetAllSportAsync(cancellationToken);

            return value.Select(c => new Sport(c)).ToArray();
        }
    }
}
