using MediatR;
using WhatSport.Domain.Models;
using WhatSport.Domain.Repositories;
using WhatSport.Domain.Extensions;

namespace WhatSport.Application.Commands.Users
{
    internal class DeleteFriendCommandHandler : IRequestHandler<DeleteFriendCommand, bool>
    {
        private readonly IFriendRepository repository;

        public DeleteFriendCommandHandler(IFriendRepository repository)
        {
            this.repository = repository;
        }

        public async Task<bool> Handle(DeleteFriendCommand request, CancellationToken cancellationToken)
        {
            var value = new Friend
            {
                UserId = request.UserId,
                FriendUserId=request.UserFriendId
            };

            await repository.RemoveFriendAsync(value);

            return await repository.UnitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
