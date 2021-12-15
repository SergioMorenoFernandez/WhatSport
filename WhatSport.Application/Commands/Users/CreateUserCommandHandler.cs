using MediatR;
using WhatSport.Domain.Models;
using WhatSport.Domain.Repositories;
using WhatSport.Domain.Extensions;

namespace WhatSport.Application.Commands.Users
{
    internal class CreateUserCommanddHandler : IRequestHandler<CreateUserCommand, bool>
    {
        private readonly IUserRepository repository;

        public CreateUserCommanddHandler(IUserRepository repository)
        {
            this.repository = repository;
        }

        public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var value = new User
            {
                Name = request.Name,
                LastName = request.LastName,
                Password = request.Password.GetMd5Hash(),
                Login = request.Login,
                Role="User",
                Status=true
            };

            repository.CreateUser(value);

            return await repository.UnitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
