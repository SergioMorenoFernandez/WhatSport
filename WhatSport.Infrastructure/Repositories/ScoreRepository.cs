using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WhatSport.Domain;
using WhatSport.Domain.Models;
using WhatSport.Domain.Repositories;

namespace WhatSport.Infrastructure.Repositories
{
    internal class ScoreRepository : IScoreRepository
    {
        private readonly WhatSportContext context;

        public ScoreRepository(WhatSportContext context)
        {
            this.context = context;
        }

        public IUnitOfWork UnitOfWork => context;

        public async Task AddScoreAsync(Score value, CancellationToken cancellationToken = default)
        {
            await context.AddAsync(value, cancellationToken);
        }

        public async Task AddScoreConfirmationAsync(ScoreConfirmation value, CancellationToken cancellationToken = default)
        {
            await context.AddAsync(value, cancellationToken);
        }

        public async Task<IEnumerable<Score>> GetScoresAsync(int matchId, CancellationToken cancellationToken = default)
        {
            return await context.Scores
                .Include(u => u.ScoreConfirmations)
                .Where(s => s.MatchId == matchId)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

    }
}
