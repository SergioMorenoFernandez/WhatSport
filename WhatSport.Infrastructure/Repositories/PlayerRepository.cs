using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WhatSport.Domain;
using WhatSport.Domain.Models;
using WhatSport.Domain.Repositories;


namespace WhatSport.Infrastructure.Repositories
{
    internal class PlayerRepository : IPlayerRepository
    {
        private readonly WhatSportContext context;

        public PlayerRepository(WhatSportContext context)
        {
            this.context = context;
        }

        public IUnitOfWork UnitOfWork => context;


        public async Task<IEnumerable<Player>> GetPlayersByMatchAsync(int matchId, int team, CancellationToken cancellationToken = default)
        {
            return await context.Players
                .Include(c => c.User)
                .Include(c => c.Match)
                .AsNoTracking()
                .Where(c => c.MatchId == matchId && c.Team == team)
                .ToListAsync(cancellationToken);

        }

        public async Task AddPlayerAsync(Player value, CancellationToken cancellationToken = default)
        {
            await context.AddAsync(value, cancellationToken);
        }

        public async Task RemovePlayerAsync(Player value, CancellationToken cancellationToken = default)
        {
            context.Remove(value);
        }
    }
}
