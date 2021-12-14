using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WhatSport.Domain.Models;

namespace WhatSport.Domain.Repositories
{
    public interface IMatchRepository
    {
        IUnitOfWork UnitOfWork { get; }

        Task<IEnumerable<Match>> GetAllMatchesAsync(CancellationToken cancellationToken = default);
        Task<Match> GetMatchByIdAsync(int id, CancellationToken cancellationToken = default);

        Task<IEnumerable<Match>> GetMatchBySportAsync(int sportId, CancellationToken cancellationToken = default);
        Task<IEnumerable<Match>> GetMatchByUserAsync(int sportId, int userId,  CancellationToken cancellationToken = default);
        Task AddMatchAsync(Match match, CancellationToken cancellationToken = default);
    }
}
