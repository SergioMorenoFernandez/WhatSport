using MediatR;

namespace WhatSport.Application.Commands.Clubs
{
    public class CreateClubCommand : IRequest<bool>
    {
        public CreateClubCommand(string name, int postalCode, int cityId)
        {
            Name = name;
            PostalCode = postalCode;
            CityId = cityId;
        }

        public string Name { get; }
        public int PostalCode { get; }
        public int CityId { get; }
    }
}
