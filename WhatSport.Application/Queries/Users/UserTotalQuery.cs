using MediatR;

namespace WhatSport.Application.Queries.Users
{
    public class UserTotalQuery : IRequest<long>
    {

        public UserTotalQuery()
        {

        }
    }
}
