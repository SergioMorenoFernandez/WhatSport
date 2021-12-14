using MediatR;
using WhatSport.Application.Models;
using WhatSport.Domain.Extensions;
using WhatSport.Domain.Repositories;

namespace WhatSport.Application.Queries.Users
{
    internal class LoginQueryHandler : IRequestHandler<LoginQuery, User>
    {
        private readonly IUserRepository repository;

        public LoginQueryHandler(IUserRepository repository)
        {
            this.repository = repository;
        }

        public async Task<User> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var user = await repository.GetUserByLoginAsync(request.Login, cancellationToken);

            if (user == null || !user.Password.Equals(request.Password.GetMd5Hash()) || !user.Status)
                throw new UnauthorizedAccessException();

            return new User(user);
        }
    }
}
