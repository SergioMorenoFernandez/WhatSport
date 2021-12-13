using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WhatSport.Domain.Models;

namespace WhatSport.Domain.Repositories
{
    public interface ILevelRepository
    {
        IUnitOfWork UnitOfWork { get; }

        Task<IEnumerable<Level>> GetLevelsByUserAsync(int userId, CancellationToken cancellationToken = default);
    }
}
