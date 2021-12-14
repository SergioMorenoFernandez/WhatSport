using MediatR;
using WhatSport.Application.Models;

namespace WhatSport.Application.Queries.Matches
{
    public class MatchByIdQuery : IRequest<Match>
    {
        public MatchByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}