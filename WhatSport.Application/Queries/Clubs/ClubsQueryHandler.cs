using MediatR;
using WhatSport.Application.Models;
using WhatSport.Domain.Repositories;

namespace WhatSport.Application.Queries.Clubs
{
    internal class ClubsQueryHandler : IRequestHandler<ClubsQuery, ClubDto[]>
    {
        private readonly IClubRepository repository;

        public ClubsQueryHandler(IClubRepository repository)
        {
            this.repository = repository;
        }

        public async Task<ClubDto[]> Handle(ClubsQuery request, CancellationToken cancellationToken)
        {
            var clubs = await repository.GetAllClubsAsync(cancellationToken);

            return clubs.Select(c => new ClubDto(c)).ToArray();
        }
    }
}
