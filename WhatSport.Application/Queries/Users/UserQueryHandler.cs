using MediatR;
using WhatSport.Application.Models;
using WhatSport.Domain.Repositories;

namespace WhatSport.Application.Queries.Users
{
    internal class UserQueryHandler : IRequestHandler<UserQuery, User[]>
    {
        private readonly IUserRepository repository;

        public UserQueryHandler(IUserRepository repository)
        {
            this.repository = repository;
        }

        public async Task<User[]> Handle(UserQuery request, CancellationToken cancellationToken)
        {
            var value = await repository.GetUserAsync(cancellationToken);

            return value.Select(c => new User(c)).ToArray();
        }
    }
}
