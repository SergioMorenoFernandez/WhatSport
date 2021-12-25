using MediatR;
using WhatSport.Application.Models;
using WhatSport.Domain.Repositories;

namespace WhatSport.Application.Queries.Users
{
    internal class UserQueryHandler : IRequestHandler<UserQuery, UserDto[]>
    {
        private readonly IUserRepository repository;

        public UserQueryHandler(IUserRepository repository)
        {
            this.repository = repository;
        }

        public async Task<UserDto[]> Handle(UserQuery request, CancellationToken cancellationToken)
        {
            var value = await repository.GetUserAsync(cancellationToken);

            return value.Select(c => new UserDto(c)).ToArray();
        }
    }
}
