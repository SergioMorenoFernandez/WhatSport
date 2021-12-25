using MediatR;
using WhatSport.Application.Models;

namespace WhatSport.Application.Queries.Matches
{
    public  class MatchQuery : IRequest<MatchDto[]>
    {
        public MatchQuery()
        {
        }

        public int SportId { get; set; }
        public int? UserId { get; set; }
    }
}
