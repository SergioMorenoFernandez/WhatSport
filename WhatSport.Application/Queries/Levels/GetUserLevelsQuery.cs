using MediatR;
using WhatSport.Application.Models;

namespace WhatSport.Application.Queries.Levels
{
    public class GetUserLevelsQuery : IRequest<LevelDto[]>
    {
        public GetUserLevelsQuery(int userId)
        {
            UserId = userId;
        }

        public int UserId { get; }
    }
}
