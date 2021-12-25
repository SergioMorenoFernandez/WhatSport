using MediatR;
using WhatSport.Application.Models;
using WhatSport.Domain.Repositories;

namespace WhatSport.Application.Queries.Users
{
    internal class SportQueryHandler : IRequestHandler<SportQuery, SportDto[]>
    {
        private readonly ISportRepository repository;

        public SportQueryHandler(ISportRepository repository)
        {
            this.repository = repository;
        }

        public async Task<SportDto[]> Handle(SportQuery request, CancellationToken cancellationToken)
        {
            var value = await repository.GetAllSportAsync(cancellationToken);

            return value.Select(c => new SportDto(c)).ToArray();
        }
    }
}
