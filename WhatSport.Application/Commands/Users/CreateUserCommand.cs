using MediatR;

namespace WhatSport.Application.Commands.Users
{
    public class CreateUserCommand : IRequest<bool>
    {
        public CreateUserCommand(string login, string password, string name, string lastName)
        {
            Login = login;
            Password = password;
            Name = name;
            LastName = lastName;
        }

        public string Login { get; } = string.Empty;
        public string Password { get;} = string.Empty;
        public string Name { get; } = string.Empty;
        public string LastName { get; } = string.Empty;
    }
}
