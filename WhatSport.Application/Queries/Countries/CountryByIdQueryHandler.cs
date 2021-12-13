using MediatR;
using WhatSport.Application.Models;
using WhatSport.Domain.Repositories;

namespace WhatSport.Application.Queries.Countries
{
    public class CountryByIdQueryHandler : IRequestHandler<CountryByIdQuery, Country>
    {
        private readonly ICountryRepository countryRepository;

        public CountryByIdQueryHandler(ICountryRepository countryRepository)
        {
            this.countryRepository = countryRepository;
        }

        public async Task<Country> Handle(CountryByIdQuery request, CancellationToken cancellationToken)
        {
            var country = await countryRepository.GetCountryByIdAsync(request.Id, cancellationToken);

            return new Country(country);
        }
    }
}
