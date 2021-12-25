using MediatR;
using WhatSport.Application.Models;
using WhatSport.Domain.Repositories;

namespace WhatSport.Application.Queries.Users
{
    internal class UserByIdQueryHandler : IRequestHandler<UserByIdQuery, UserDto>
    {
        private readonly IUserRepository repository;

        public UserByIdQueryHandler(IUserRepository repository)
        {
            this.repository = repository;
        }

        public async Task<UserDto> Handle(UserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await repository.GetUserByIdAsync(request.Id, cancellationToken);

            return new UserDto(user);
        }
    }
}
