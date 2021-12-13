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
    internal class LevelRepository : ILevelRepository
    {
        private readonly WhatSportContext context;

        public LevelRepository(WhatSportContext context)
        {
            this.context = context;
        }

        public IUnitOfWork UnitOfWork => context;

        public async Task<IEnumerable<Level>> GetLevelsByUserAsync(int userId, CancellationToken cancellationToken = default)
        {
            return await context.Levels.Include(l => l.Sport).AsNoTracking().Where(l => l.UserId == userId).ToListAsync(cancellationToken);
        }
    }
}
