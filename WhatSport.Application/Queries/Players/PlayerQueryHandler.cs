using MediatR;
using WhatSport.Application.Models;
using WhatSport.Domain.Repositories;

namespace WhatSport.Application.Queries.Matches
{
    internal class PlayerQueryHandler : IRequestHandler<PlayerQuery, UserDto[]>
    {
        private readonly IPlayerRepository repository;

        public PlayerQueryHandler(IPlayerRepository repository)
        {
            this.repository = repository;
        }

        public async Task<UserDto[]> Handle(PlayerQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Domain.Models.Player> value;

            value = await repository.GetPlayersByMatchAsync(request.MatchId, request.Team, cancellationToken);

            return value.Select(c => new UserDto(c.User)).ToArray();
        }

    }


}
