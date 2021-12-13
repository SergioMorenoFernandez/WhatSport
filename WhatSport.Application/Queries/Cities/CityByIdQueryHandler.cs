using MediatR;
using WhatSport.Application.Models;
using WhatSport.Domain.Repositories;

namespace WhatSport.Application.Queries.Cities
{
    public class CountryByIdQueryHandler : IRequestHandler<CountryByIdQuery, City>
    {
        private readonly ICityRepository cityRepository;

        public CountryByIdQueryHandler(ICityRepository cityRepository)
        {
            this.cityRepository = cityRepository;
        }

        public async Task<City> Handle(CountryByIdQuery request, CancellationToken cancellationToken)
        {
            var city = await cityRepository.GetCityByIdAsync(request.Id, cancellationToken);

            return new City(city);
        }
    }
}
