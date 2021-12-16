using MediatR;

namespace WhatSport.Application.Commands.Users
{
    public class CreateFriendCommand : IRequest<bool>
    {
        public CreateFriendCommand(int userId, int userFriendId)
        {
            UserFriendId = userFriendId;
            UserId = userId;
        }

        public int UserId { get; } 
        public int UserFriendId { get; }

    }
}
