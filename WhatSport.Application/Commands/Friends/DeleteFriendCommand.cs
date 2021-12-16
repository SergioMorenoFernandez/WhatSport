using MediatR;

namespace WhatSport.Application.Commands.Users
{
    public class DeleteFriendCommand : IRequest<bool>
    {
        public DeleteFriendCommand(int userId, int userFriendId)
        {
            UserFriendId = userFriendId;
            UserId = userId;
        }

        public int UserId { get; } 
        public int UserFriendId { get; }

    }
}
