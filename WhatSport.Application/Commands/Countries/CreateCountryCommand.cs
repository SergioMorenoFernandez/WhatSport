using MediatR;

namespace WhatSport.Application.Commands.Countries
{
    public class CreateCountryCommand : IRequest<bool>
    {
        public CreateCountryCommand(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}
