﻿using MediatR;
using WhatSport.Application.Models;

namespace WhatSport.Application.Queries.Users
{
    public class SportByIdQuery : IRequest<Sport>
    {
        public SportByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
