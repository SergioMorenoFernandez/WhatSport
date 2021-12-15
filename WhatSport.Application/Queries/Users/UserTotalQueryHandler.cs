using MediatR;
using WhatSport.Domain.Repositories;

namespace WhatSport.Application.Queries.Users
{
    internal class UserTotalQueryHandler : IRequestHandler<UserTotalQuery, long>
    {
        private readonly IUserRepository repository;

        public UserTotalQueryHandler(IUserRepository repository)
        {
            this.repository = repository;
        }

        public async Task<long> Handle(UserTotalQuery request, CancellationToken cancellationToken)
        {
            var value = await repository.GetUserAsync(cancellationToken);

            return value.Count();
        }
    }
}
