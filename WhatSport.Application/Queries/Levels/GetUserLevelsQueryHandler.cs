using MediatR;
using WhatSport.Application.Models;
using WhatSport.Domain.Repositories;

namespace WhatSport.Application.Queries.Levels
{
    internal class GetUserLevelsQueryHandler : IRequestHandler<GetUserLevelsQuery, LevelDto[]>
    {
        private readonly ILevelRepository repository;

        public GetUserLevelsQueryHandler(ILevelRepository repository)
        {
            this.repository = repository;
        }

        public async Task<LevelDto[]> Handle(GetUserLevelsQuery request, CancellationToken cancellationToken)
        {
            var levels = await repository.GetLevelsByUserAsync(request.UserId, cancellationToken);

            return levels.Select(l => new LevelDto(l)).ToArray();
        }
    }
}
