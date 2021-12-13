using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WhatSport.Domain.Models;

namespace WhatSport.Domain.Repositories
{
    public interface IClubRepository
    {
        IUnitOfWork UnitOfWork { get; }

        Task<IEnumerable<Club>> GetAllClubsAsync(CancellationToken cancellationToken = default);
        Task<Club> GetClubByIdAsync(int id, CancellationToken cancellationToken = default);
        Task AddClubAsync(Club club, CancellationToken cancellationToken = default);
    }
}
