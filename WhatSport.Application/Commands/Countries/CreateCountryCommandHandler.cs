using MediatR;
using WhatSport.Domain.Models;
using WhatSport.Domain.Repositories;

namespace WhatSport.Application.Commands.Countries
{
    public class CreateCountryCommandHandler : IRequestHandler<CreateCountryCommand, bool>
    {
        private readonly ICountryRepository repository;

        public CreateCountryCommandHandler(ICountryRepository repository)
        {
            this.repository = repository;
        }

        public async Task<bool> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
        {
            var country = new Country
            {
                Name = request.Name
            };

            await repository.AddCountryAsync(country, cancellationToken);

            return await repository.UnitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
