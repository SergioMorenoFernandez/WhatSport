using MediatR;
using WhatSport.Application.Models;

namespace WhatSport.Application.Queries.Clubs
{
    public class ClubsQuery : IRequest<ClubDto[]>
    {
        public ClubsQuery()
        {
        }
    }
}
