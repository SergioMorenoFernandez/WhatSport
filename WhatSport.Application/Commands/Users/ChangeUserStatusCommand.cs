using MediatR;

namespace WhatSport.Application.Commands.Users
{
    public class ChangeUserStatusCommand : IRequest<bool>
    {
        public ChangeUserStatusCommand(int userId, bool newStatus)
        {
            UserId = userId;
            NewStatus = newStatus;
        }

        public int UserId { get; }
        public bool NewStatus { get; }
    }
}
