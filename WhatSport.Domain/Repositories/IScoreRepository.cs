using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WhatSport.Domain.Models;

namespace WhatSport.Domain.Repositories
{
    public interface IScoreRepository
    {
        IUnitOfWork UnitOfWork { get; }
        Task AddScoreAsync(Score score, CancellationToken cancellationToken = default);

        Task AddScoreConfirmationAsync(ScoreConfirmation value, CancellationToken cancellationToken = default);

        Task<IEnumerable<Score>> GetScoresAsync(int matchId, CancellationToken cancellationToken = default);

    }
}
