using MediatR;
using WhatSport.Application.Models;

namespace WhatSport.Application.Queries.Countries
{
    public class CountryByIdQuery : IRequest<Country>
    {
        public CountryByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
