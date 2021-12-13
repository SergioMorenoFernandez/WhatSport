using MediatR;
using WhatSport.Application.Models;
using WhatSport.Domain.Repositories;

namespace WhatSport.Application.Queries.Clubs
{
    internal class ClubByIdQueryHandler : IRequestHandler<ClubByIdQuery, Club>
    {
        private readonly IClubRepository clubRepository;

        public ClubByIdQueryHandler(IClubRepository clubRepository)
        {
            this.clubRepository = clubRepository;
        }

        public async Task<Club> Handle(ClubByIdQuery request, CancellationToken cancellationToken)
        {
            var club = await clubRepository.GetClubByIdAsync(request.Id, cancellationToken);

            return new Club(club);
        }
    }
}
