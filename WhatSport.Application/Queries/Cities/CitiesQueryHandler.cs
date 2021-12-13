using MediatR;
using WhatSport.Application.Models;
using WhatSport.Domain.Repositories;

namespace WhatSport.Application.Queries.Cities
{
    public class CountriesQueryHandler : IRequestHandler<CitiesQuery, City[]>
    {
        private readonly ICityRepository cityRepository;

        public CountriesQueryHandler(ICityRepository cityRepository)
        {
            this.cityRepository = cityRepository;
        }

        public async Task<City[]> Handle(CitiesQuery request, CancellationToken cancellationToken)
        {
            var cities = await cityRepository.GetAllCitiesAsync(cancellationToken);

            return cities.Select(c => new City(c)).ToArray();
        }
    }
}
