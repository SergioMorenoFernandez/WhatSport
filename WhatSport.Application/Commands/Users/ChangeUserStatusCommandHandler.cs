using MediatR;
using WhatSport.Domain.Repositories;

namespace WhatSport.Application.Commands.Users
{
    internal class ChangeUserStatusCommandHandler : IRequestHandler<ChangeUserStatusCommand, bool>
    {
        private readonly IUserRepository repository;

        public ChangeUserStatusCommandHandler(IUserRepository repository)
        {
            this.repository = repository;
        }

        public async Task<bool> Handle(ChangeUserStatusCommand request, CancellationToken cancellationToken)
        {
            var user = await repository.GetUserByIdAsync(request.UserId, cancellationToken);

            user.Status = request.NewStatus;

            repository.UpdateUser(user);

            return await repository.UnitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
