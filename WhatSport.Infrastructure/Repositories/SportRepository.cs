using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WhatSport.Domain;
using WhatSport.Domain.Models;
using WhatSport.Domain.Repositories;

namespace WhatSport.Infrastructure.Repositories
{
    internal class SportRepository : ISportRepository
    {
        private readonly WhatSportContext context;

        public SportRepository(WhatSportContext context)
        {
            this.context = context;
        }

        public IUnitOfWork UnitOfWork => context;

        public async Task<IEnumerable<Sport>> GetAllSportAsync(CancellationToken cancellationToken = default)
        {
            return await context.Sports.AsNoTracking().ToListAsync(cancellationToken);
        }

    }
}
