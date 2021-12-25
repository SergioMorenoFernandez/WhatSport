using MediatR;
using WhatSport.Application.Models;

namespace WhatSport.Application.Queries.Users
{
    public class SportQuery : IRequest<SportDto[]>
    {
        public SportQuery()
        {

        }
        
    }
}
