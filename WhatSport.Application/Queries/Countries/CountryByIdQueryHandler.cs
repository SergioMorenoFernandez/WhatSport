using MediatR;
using WhatSport.Application.Models;
using WhatSport.Domain.Repositories;

namespace WhatSport.Application.Queries.Countries
{
    public class CountryByIdQueryHandler : IRequestHandler<CountryByIdQuery, CountryDto>
    {
        private readonly ICountryRepository repository;

        public CountryByIdQueryHandler(ICountryRepository repository)
        {
            this.repository = repository;
        }

        public async Task<CountryDto> Handle(CountryByIdQuery request, CancellationToken cancellationToken)
        {
            var country = await repository.GetCountryByIdAsync(request.Id, cancellationToken);

            return new CountryDto(country);
        }
    }
}
