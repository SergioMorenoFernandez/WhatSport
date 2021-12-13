using MediatR;
using WhatSport.Application.Models;

namespace WhatSport.Application.Queries.Clubs
{
    public class ClubByIdQuery : IRequest<Club>
    {
        public ClubByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
