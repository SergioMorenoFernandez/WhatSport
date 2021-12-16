using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WhatSport.Domain;
using WhatSport.Domain.Models;
using WhatSport.Domain.Repositories;

namespace WhatSport.Infrastructure.Repositories
{
    internal class FriendRepository : IFriendRepository
    {
        private readonly WhatSportContext context;

        public FriendRepository(WhatSportContext context)
        {
            this.context = context;
        }

        public IUnitOfWork UnitOfWork => context;

        public async Task AddFriendAsync(Friend value, CancellationToken cancellationToken = default)
        {
            await context.AddAsync(value, cancellationToken);
        }

        public async Task RemoveFriendAsync(Friend value, CancellationToken cancellationToken = default)
        {
            context.Remove(value);
        }


    }
}
