using MediatR;
using WhatSport.Application.Models;

namespace WhatSport.Application.Queries.Cities
{
    public class CountryByIdQuery : IRequest<City>
    {
        public CountryByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
