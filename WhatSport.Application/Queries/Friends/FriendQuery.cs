using MediatR;
using WhatSport.Application.Models;

namespace WhatSport.Application.Queries.Matches
{
    public  class FriendQuery : IRequest<UserDto[]>
    {
        public FriendQuery(int userId)
        {
            this.UserId = userId;
            
        }

        public int UserId { get;  }
    }
}
