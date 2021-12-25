namespace WhatSport.Application.Models
{
    public class CountryDto
    {
        public CountryDto(Domain.Models.Country country)
        {
            Id = country.Id;
            Name = country.Name;
        }

        public int Id { get; }
        public string Name { get; }
    }
}
