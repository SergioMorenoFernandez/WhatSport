using MediatR;
using WhatSport.Domain.Repositories;

namespace WhatSport.Application.Commands.Users
{
    internal class ChangeUserStatusCommandHandler : IRequestHandler<ChangeUserStatusCommand, bool>
    {
        private readonly IUserRepository userRepository;

        public ChangeUserStatusCommandHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<bool> Handle(ChangeUserStatusCommand request, CancellationToken cancellationToken)
        {
            var user = await userRepository.GetUserByIdAsync(request.UserId, cancellationToken);

            user.Status = request.NewStatus;

            userRepository.UpdateUser(user);

            return await userRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
