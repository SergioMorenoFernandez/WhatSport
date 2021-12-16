using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WhatSport.Domain.Models;

namespace WhatSport.Domain.Repositories
{
    public interface ISportRepository
    {
        Task<IEnumerable<Sport>> GetAllSportAsync(CancellationToken cancellationToken = default);
        Task<Sport> GetSportAsync(int id, CancellationToken cancellationToken = default);
    }
}
