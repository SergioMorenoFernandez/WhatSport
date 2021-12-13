using MediatR;
using WhatSport.Domain.Models;
using WhatSport.Domain.Repositories;

namespace WhatSport.Application.Commands.Cities
{
    public class CreateCountryCommandHandler : IRequestHandler<CreateCityCommand, bool>
    {
        private readonly ICityRepository cityRepository;

        public CreateCountryCommandHandler(ICityRepository cityRepository)
        {
            this.cityRepository = cityRepository;
        }

        public async Task<bool> Handle(CreateCityCommand request, CancellationToken cancellationToken)
        {
            var city = new City
            {
                Name = request.Name,
                CountryId = request.CountryId,
            };

            await cityRepository.AddCityAsync(city, cancellationToken);

            return await cityRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
