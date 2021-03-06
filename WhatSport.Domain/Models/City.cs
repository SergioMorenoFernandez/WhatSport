using System.Collections.Generic;

namespace WhatSport.Domain.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int CountryId { get; set; }
        public Country? Country { get; set; }
        public IEnumerable<Club> Clubs { get; set; } = new List<Club>();
    }
}