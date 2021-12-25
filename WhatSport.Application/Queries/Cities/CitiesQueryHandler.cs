using MediatR;
using WhatSport.Application.Models;
using WhatSport.Domain.Repositories;

namespace WhatSport.Application.Queries.Cities
{
    public class CountriesQueryHandler : IRequestHandler<CitiesQuery, CityDto[]>
    {
        private readonly ICityRepository repository;

        public CountriesQueryHandler(ICityRepository repository)
        {
            this.repository = repository;
        }

        public async Task<CityDto[]> Handle(CitiesQuery request, CancellationToken cancellationToken)
        {
            var cities = await repository.GetAllCitiesAsync(cancellationToken);

            return cities.Select(c => new CityDto(c)).ToArray();
        }
    }
}
