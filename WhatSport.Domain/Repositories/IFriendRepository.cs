using System.Threading;
using System.Threading.Tasks;
using WhatSport.Domain.Models;

namespace WhatSport.Domain.Repositories
{
    public interface IFriendRepository
    {
        IUnitOfWork UnitOfWork { get; }

        Task AddFriendAsync(Friend value, CancellationToken cancellationToken = default);
        Task RemoveFriendAsync(Friend value, CancellationToken cancellationToken = default);
    }
}
