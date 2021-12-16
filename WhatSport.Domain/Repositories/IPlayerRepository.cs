using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WhatSport.Domain.Models;

namespace WhatSport.Domain.Repositories
{
    public interface IPlayerRepository
    {
        IUnitOfWork UnitOfWork { get; }

        Task<IEnumerable<Player>> GetPlayersByMatchAsync(int matchId, int team, CancellationToken cancellationToken = default);

        Task AddPlayerAsync(Player value, CancellationToken cancellationToken = default);

        Task RemovePlayerAsync(Player value, CancellationToken cancellationToken = default);
    }
}
