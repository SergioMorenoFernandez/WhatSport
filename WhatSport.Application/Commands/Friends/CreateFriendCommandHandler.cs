using MediatR;
using WhatSport.Domain.Models;
using WhatSport.Domain.Repositories;
using WhatSport.Domain.Extensions;

namespace WhatSport.Application.Commands.Users
{
    internal class CreateFriendCommandHandler : IRequestHandler<CreateFriendCommand, bool>
    {
        private readonly IFriendRepository repository;

        public CreateFriendCommandHandler(IFriendRepository repository)
        {
            this.repository = repository;
        }

        public async Task<bool> Handle(CreateFriendCommand request, CancellationToken cancellationToken)
        {
            var value = new Friend
            {
                UserId=request.UserId,
                FriendUserId = request.UserFriendId
            };

            repository.AddFriendAsync(value);

            return await repository.UnitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
