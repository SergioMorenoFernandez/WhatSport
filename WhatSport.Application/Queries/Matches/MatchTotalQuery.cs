using MediatR;

namespace WhatSport.Application.Queries.Matches
{
    public class MatchTotalQuery : IRequest<long>
    {
        public MatchTotalQuery()
        {
        }
        public int SportId { get; set; }
        public int? UserId { get; set; }
    }
}