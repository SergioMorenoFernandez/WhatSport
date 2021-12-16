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
    internal class MatchRepository : IMatchRepository
    {
        private readonly WhatSportContext context;

        public MatchRepository(WhatSportContext context)
        {
            this.context = context;
        }

        public IUnitOfWork UnitOfWork => context;

        public async Task AddMatchAsync(Match value, CancellationToken cancellationToken = default)
        {
            await context.AddAsync(value, cancellationToken);
        }

        public async Task<IEnumerable<Match>> GetAllMatchesAsync(CancellationToken cancellationToken = default)
        {
            return await context.Matches.Include(c => c.Sport)
                .Include(c => c.Club)
                .Include(c => c.Players)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public async Task<Match> GetMatchByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await context.Matches.Include(c => c.Sport)
                .Include(c => c.Players).ThenInclude(cs => cs.User)
                .Include(c => c.Club)
                .AsNoTracking()
                .SingleAsync(c => c.Id == id, cancellationToken);
        }

        public async Task<IEnumerable<Match>> GetMatchBySportAsync(int sportId, CancellationToken cancellationToken = default)
        {
            return await context.Matches.Include(c => c.Sport)
                .Include(c => c.Club)
                .Include(c => c.Players)
                .AsNoTracking()
                .Where(c=> c.SportId==sportId && c.DateStart>DateTime.Now )
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<Match>> GetMatchByUserAsync(int sportId, int userId, CancellationToken cancellationToken = default)
        {
            return await context.Matches.Include(c => c.Sport)
                .Include(c => c.Club)
                .Include(c => c.Players)
                .AsNoTracking()
                //.Where(c => c.SportId == sportId && c.Players.Contains(x=> x.UserId == userId))
                //TODO --> mostrar solamente los partidos de un jugador
                .Where(c => c.SportId == sportId )
                .ToListAsync(cancellationToken);
        }
    }
}
