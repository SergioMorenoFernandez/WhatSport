using MediatR;
using WhatSport.Application.Models;
using WhatSport.Domain.Repositories;

namespace WhatSport.Application.Queries.Matches
{
    internal class FriendQueryHandler : IRequestHandler<FriendQuery, User[]>
    {
        private readonly IUserRepository repository;

        public FriendQueryHandler(IUserRepository repository)
        {
            this.repository = repository;
        }

        public async Task<User[]> Handle(FriendQuery request, CancellationToken cancellationToken)
        {

            var value = await repository.GetFriendsAsync(request.UserId, cancellationToken);

            if(value == null)
            {
                return Array.Empty<User>();
            }

            return value.Select(c => new User(c)).ToArray();
        }

    }


}
