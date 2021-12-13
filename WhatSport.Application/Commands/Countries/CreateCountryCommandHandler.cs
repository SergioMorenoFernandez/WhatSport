using MediatR;
using WhatSport.Domain.Models;
using WhatSport.Domain.Repositories;

namespace WhatSport.Application.Commands.Countries
{
    public class CreateCountryCommandHandler : IRequestHandler<CreateCountryCommand, bool>
    {
        private readonly ICountryRepository countryRepository;

        public CreateCountryCommandHandler(ICountryRepository countryRepository)
        {
            this.countryRepository = countryRepository;
        }

        public async Task<bool> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
        {
            var country = new Country
            {
                Name = request.Name
            };

            await countryRepository.AddCountryAsync(country, cancellationToken);

            return await countryRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
