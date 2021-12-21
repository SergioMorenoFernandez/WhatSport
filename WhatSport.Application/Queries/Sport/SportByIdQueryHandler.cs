using MediatR;
using WhatSport.Application.Models;
using WhatSport.Domain.Repositories;

namespace WhatSport.Application.Queries.Users
{
    internal class SportByIdQueryHandler : IRequestHandler<SportByIdQuery, Sport>
    {
        private readonly ISportRepository repository;

        public SportByIdQueryHandler(ISportRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Sport> Handle(SportByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await repository.GetSportAsync(request.Id, cancellationToken);

            return new Sport(value);
        }
    }
}
