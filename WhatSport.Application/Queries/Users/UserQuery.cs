using MediatR;
using WhatSport.Application.Models;

namespace WhatSport.Application.Queries.Users
{
    public class UserQuery : IRequest<UserDto[]>
    {
        public UserQuery()
        {

        }
        
    }
}
