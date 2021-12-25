using MediatR;
using WhatSport.Application.Models;
using WhatSport.Domain.Repositories;

namespace WhatSport.Application.Queries.Cities
{
    public class CityByIdQueryHandler : IRequestHandler<CityByIdQuery, CityDto>
    {
        private readonly ICityRepository repository;

        public CityByIdQueryHandler(ICityRepository repository)
        {
            this.repository = repository;
        }

        public async Task<CityDto> Handle(CityByIdQuery request, CancellationToken cancellationToken)
        {
            var city = await repository.GetCityByIdAsync(request.Id, cancellationToken);

            return new CityDto(city);
        }
    }
}
