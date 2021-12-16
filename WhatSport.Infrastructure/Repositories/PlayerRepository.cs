using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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


        public async Task<IEnumerable<User?>> GetPlayersByMatchAsync(int matchId, CancellationToken cancellationToken = default)
        {

            return await context.Players
                .Include(c => c.User)
                .Include(c => c.Match)
                .AsNoTracking()
                .Where(c => c.MatchId == matchId).Select(c => c.User)
                .ToListAsync(cancellationToken);

        }
    }
}
