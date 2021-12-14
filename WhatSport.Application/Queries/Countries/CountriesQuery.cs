﻿using MediatR;
using WhatSport.Application.Models;

namespace WhatSport.Application.Queries.Countries
{
    public class CountriesQuery : IRequest<Country[]>
    {
        public CountriesQuery()
        {
        }
    }
}
