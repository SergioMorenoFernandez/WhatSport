using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WhatSport.Domain;
using WhatSport.Domain.Models;
using WhatSport.Domain.Repositories;

namespace WhatSport.Infrastructure.Repositories
{
    internal class UserRepository : IUserRepository
    {
        private readonly WhatSportContext context;

        public UserRepository(WhatSportContext context)
        {
            this.context = context;
        }

        public IUnitOfWork UnitOfWork => context;

        public async Task<User> GetUserByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await context.Users
                .Include(u => u.SentFriendRequests)
                .AsNoTracking().SingleAsync(u => u.Id == id, cancellationToken);
        }
        public async Task<IEnumerable<User>> GetUserAsync(CancellationToken cancellationToken = default)
        {
            return await context.Users.AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<User>> GetFriendsAsync(int id, CancellationToken cancellationToken = default)
        {
            return await (from user in context.Set<User>()
                        join friend in context.Set<Friend>()
                            on user.Id equals friend.UserId
                        join userfriend in context.Set<User>()
                            on friend.FriendUserId equals userfriend.Id
                        where user.Id == id
                        select userfriend).AsNoTracking().ToListAsync(cancellationToken);

        }

        public async Task<User?> GetUserByLoginAsync(string login, CancellationToken cancellationToken = default)
        {
            return await context.Users.AsNoTracking().SingleOrDefaultAsync(u => u.Login == login, cancellationToken);
        }

        public async void UpdateUser(User user, CancellationToken cancellationToken = default)
        {
            context.Users.Update(user);
        }
        public async Task CreateUserAsync(User user, CancellationToken cancellationToken = default)
        {
            await context.Users.AddAsync(user,cancellationToken);
        }


    }
}
