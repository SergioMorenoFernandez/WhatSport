using MediatR;
using WhatSport.Application.Models;
using WhatSport.Domain.Repositories;

namespace WhatSport.Application.Queries.Countries
{
    public class CountriesQueryHandler : IRequestHandler<CountriesQuery, Country[]>
    {
        private readonly ICountryRepository countryRepository;

        public CountriesQueryHandler(ICountryRepository countryRepository)
        {
            this.countryRepository = countryRepository;
        }

        public async Task<Country[]> Handle(CountriesQuery request, CancellationToken cancellationToken)
        {
            var countries = await countryRepository.GetAllCountriesAsync(cancellationToken);

            return countries.Select(c => new Country(c)).ToArray();
        }
    }
}
