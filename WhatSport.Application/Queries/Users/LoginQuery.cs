using MediatR;
using WhatSport.Application.Models;

namespace WhatSport.Application.Queries.Users
{
    public class LoginQuery : IRequest<User>
    {
        public LoginQuery(string login, string password)
        {
            Login = login;
            Password = password;
        }

        public string Login { get; }
        public string Password { get; } 
    }
}
