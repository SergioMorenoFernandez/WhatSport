using MediatR;
using WhatSport.Application.Models;
using WhatSport.Domain.Repositories;

namespace WhatSport.Application.Queries.Clubs
{
    internal class ClubByIdQueryHandler : IRequestHandler<ClubByIdQuery, Club>
    {
        private readonly IClubRepository repository;

        public ClubByIdQueryHandler(IClubRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Club> Handle(ClubByIdQuery request, CancellationToken cancellationToken)
        {
            var club = await repository.GetClubByIdAsync(request.Id, cancellationToken);

            return new Club(club);
        }
    }
}
