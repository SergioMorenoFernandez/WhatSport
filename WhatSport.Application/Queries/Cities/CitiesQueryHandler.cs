using MediatR;
using WhatSport.Application.Models;
using WhatSport.Domain.Repositories;

namespace WhatSport.Application.Queries.Cities
{
    public class CountriesQueryHandler : IRequestHandler<CitiesQuery, City[]>
    {
        private readonly ICityRepository repository;

        public CountriesQueryHandler(ICityRepository repository)
        {
            this.repository = repository;
        }

        public async Task<City[]> Handle(CitiesQuery request, CancellationToken cancellationToken)
        {
            var cities = await repository.GetAllCitiesAsync(cancellationToken);

            return cities.Select(c => new City(c)).ToArray();
        }
    }
}
