using MediatR;

namespace WhatSport.Application.Commands.Cities
{
    public class CreateCityCommand : IRequest<bool>
    {
        public CreateCityCommand(string name, int countryId)
        {
            Name = name;
            CountryId = countryId;
        }

        public string Name { get; }
        public int CountryId { get;}
    }
}
