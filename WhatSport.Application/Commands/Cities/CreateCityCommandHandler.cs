using MediatR;
using WhatSport.Domain.Models;
using WhatSport.Domain.Repositories;

namespace WhatSport.Application.Commands.Cities
{
    public class CreateCityCommandHandler : IRequestHandler<CreateCityCommand, bool>
    {
        private readonly ICityRepository repository;

        public CreateCityCommandHandler(ICityRepository repository)
        {
            this.repository = repository;
        }

        public async Task<bool> Handle(CreateCityCommand request, CancellationToken cancellationToken)
        {
            var city = new City
            {
                Name = request.Name,
                CountryId = request.CountryId,
            };

            await repository.AddCityAsync(city, cancellationToken);

            return await repository.UnitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
