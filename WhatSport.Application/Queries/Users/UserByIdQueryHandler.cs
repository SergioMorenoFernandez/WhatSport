using MediatR;
using WhatSport.Application.Models;
using WhatSport.Domain.Repositories;

namespace WhatSport.Application.Queries.Users
{
    internal class UserByIdQueryHandler : IRequestHandler<UserByIdQuery, User>
    {
        private readonly IUserRepository userRepository;

        public UserByIdQueryHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<User> Handle(UserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await userRepository.GetUserByIdAsync(request.Id, cancellationToken);

            return new User(user);
        }
    }
}
