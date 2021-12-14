using MediatR;
using WhatSport.Application.Models;
using WhatSport.Domain.Repositories;

namespace WhatSport.Application.Queries.Countries
{
    internal class CountriesQueryHandler : IRequestHandler<CountriesQuery, Country[]>
    {
        private readonly ICountryRepository repository;

        public CountriesQueryHandler(ICountryRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Country[]> Handle(CountriesQuery request, CancellationToken cancellationToken)
        {
            var countries = await repository.GetAllCountriesAsync(cancellationToken);

            return countries.Select(c => new Country(c)).ToArray();
        }
    }
}
