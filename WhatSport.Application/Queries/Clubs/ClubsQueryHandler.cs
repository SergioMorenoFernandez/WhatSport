using MediatR;
using WhatSport.Application.Models;
using WhatSport.Domain.Repositories;

namespace WhatSport.Application.Queries.Clubs
{
    internal class ClubsQueryHandler : IRequestHandler<ClubsQuery, Club[]>
    {
        private readonly IClubRepository clubRepository;

        public ClubsQueryHandler(IClubRepository clubRepository)
        {
            this.clubRepository = clubRepository;
        }

        public async Task<Club[]> Handle(ClubsQuery request, CancellationToken cancellationToken)
        {
            var clubs = await clubRepository.GetAllClubsAsync(cancellationToken);

            return clubs.Select(c => new Club(c)).ToArray();
        }
    }
}
