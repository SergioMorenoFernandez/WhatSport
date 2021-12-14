using MediatR;
using WhatSport.Domain.Models;
using WhatSport.Domain.Repositories;

namespace WhatSport.Application.Commands.Clubs
{
    internal class CreateClubCommandHandler : IRequestHandler<CreateClubCommand, bool>
    {
        private readonly IClubRepository repository;

        public CreateClubCommandHandler(IClubRepository repository)
        {
            this.repository = repository;
        }

        public async Task<bool> Handle(CreateClubCommand request, CancellationToken cancellationToken)
        {
            var club = new Club
            {
                Name = request.Name,
                PostalCode = request.PostalCode,
                CityId = request.CityId
            };

            await repository.AddClubAsync(club, cancellationToken);
            
            return await repository.UnitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
