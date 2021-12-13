using MediatR;
using WhatSport.Domain.Models;
using WhatSport.Domain.Repositories;

namespace WhatSport.Application.Commands.Clubs
{
    internal class CreateClubCommandHandler : IRequestHandler<CreateClubCommand, bool>
    {
        private readonly IClubRepository clubRepository;

        public CreateClubCommandHandler(IClubRepository clubRepository)
        {
            this.clubRepository = clubRepository;
        }

        public async Task<bool> Handle(CreateClubCommand request, CancellationToken cancellationToken)
        {
            var club = new Club
            {
                Name = request.Name,
                PostalCode = request.PostalCode,
                CityId = request.CityId
            };

            await clubRepository.AddClubAsync(club, cancellationToken);
            
            return await clubRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
