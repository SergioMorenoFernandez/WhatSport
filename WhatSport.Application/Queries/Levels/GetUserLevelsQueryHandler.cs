using MediatR;
using WhatSport.Application.Models;
using WhatSport.Domain.Repositories;

namespace WhatSport.Application.Queries.Levels
{
    internal class GetUserLevelsQueryHandler : IRequestHandler<GetUserLevelsQuery, Level[]>
    {
        private readonly ILevelRepository levelRepository;

        public GetUserLevelsQueryHandler(ILevelRepository levelRepository)
        {
            this.levelRepository = levelRepository;
        }

        public async Task<Level[]> Handle(GetUserLevelsQuery request, CancellationToken cancellationToken)
        {
            var levels = await levelRepository.GetLevelsByUserAsync(request.UserId, cancellationToken);

            return levels.Select(l => new Level(l)).ToArray();
        }
    }
}
