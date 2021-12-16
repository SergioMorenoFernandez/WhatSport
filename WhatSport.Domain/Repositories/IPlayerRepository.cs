using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WhatSport.Domain.Models;

namespace WhatSport.Domain.Repositories
{
    public interface IPlayerRepository
    {
        IUnitOfWork UnitOfWork { get; }

        Task<IEnumerable<User>> GetPlayersByMatchAsync(int matchId, CancellationToken cancellationToken = default);
    }
}
