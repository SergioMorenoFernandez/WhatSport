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
    internal class ClubRepository : IClubRepository
    {
        private readonly WhatSportContext context;

        public ClubRepository(WhatSportContext context)
        {
            this.context = context;
        }

        public IUnitOfWork UnitOfWork => context;

        public async Task AddClubAsync(Club club, CancellationToken cancellationToken = default)
        {
            await context.AddAsync(club, cancellationToken);
        }

        public async Task<IEnumerable<Club>> GetAllClubsAsync(CancellationToken cancellationToken = default)
        {
            return await context.Clubs.Include(c => c.City)
                .Include(c => c.ClubSports).ThenInclude(cs => cs.Sport)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public async Task<Club> GetClubByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await context.Clubs.Include(c => c.City)
                .Include(c => c.ClubSports).ThenInclude(cs => cs.Sport)
                .AsNoTracking()
                .SingleAsync(c => c.Id == id, cancellationToken);
        }
    }
}
