using MediatR;
using WhatSport.Application.Models;
using WhatSport.Domain.Repositories;

namespace WhatSport.Application.Queries.Countries
{
    internal class CountriesQueryHandler : IRequestHandler<CountriesQuery, CountryDto[]>
    {
        private readonly ICountryRepository repository;

        public CountriesQueryHandler(ICountryRepository repository)
        {
            this.repository = repository;
        }

        public async Task<CountryDto[]> Handle(CountriesQuery request, CancellationToken cancellationToken)
        {
            var countries = await repository.GetAllCountriesAsync(cancellationToken);

            return countries.Select(c => new CountryDto(c)).ToArray();
        }
    }
}
