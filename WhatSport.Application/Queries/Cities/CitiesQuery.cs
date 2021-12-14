using MediatR;
using WhatSport.Application.Models;

namespace WhatSport.Application.Queries.Cities
{
    public class CitiesQuery : IRequest<City[]>
    {
        public CitiesQuery ()
        { }
    }
}
