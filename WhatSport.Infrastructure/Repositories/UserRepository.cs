using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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
            return await context.Users.AsNoTracking().SingleAsync(u => u.Id == id, cancellationToken);
        }
        public async Task<IEnumerable<User>> GetUserAsync(CancellationToken cancellationToken = default)
        {
            return await context.Users.AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task<User?> GetUserByLoginAsync(string login, CancellationToken cancellationToken = default)
        {
            return await context.Users.AsNoTracking().SingleOrDefaultAsync(u => u.Login == login, cancellationToken);
        }

        public void UpdateUser(User user)
        {
            context.Users.Update(user);
        }
    }
}
