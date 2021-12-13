namespace WhatSport.Application.Models
{
    public class City
    {
        public City(Domain.Models.City city)
        {
            Id = city.Id;
            Name = city.Name;
            CountryName = city.Country?.Name ?? throw new ApplicationException("Country of city cannot be null");
        }

        public int Id { get; }
        public string Name { get; }
        public string CountryName { get; }
    }
}
