using MediatR;
using WhatSport.Application.Models;

namespace WhatSport.Application.Queries.Cities
{
    public class CityByIdQuery : IRequest<CityDto>
    {
        public CityByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
