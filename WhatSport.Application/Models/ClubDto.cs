namespace WhatSport.Application.Models
{
    public class ClubDto
    {
        public ClubDto(Domain.Models.Club club)
        {
            Id = club.Id;
            Name = club.Name;
            PostalCode = club.PostalCode;
            CityName = club.City?.Name ?? throw new ArgumentException("City of club cannot be null");
            Sports = club.ClubSports.Select(cs => cs.Sport?.Name ?? throw new ArgumentException("Sport of clubSport cannot be null")).ToArray();
        }

        public int Id { get; }
        public string Name { get; }
        public int PostalCode { get; }
        public string CityName { get; }
        public string[] Sports { get; }
    }
}
