using MediatR;
using WhatSport.Application.Models;

namespace WhatSport.Application.Queries.Users
{
    public class UserByIdQuery : IRequest<User>
    {
        public UserByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
