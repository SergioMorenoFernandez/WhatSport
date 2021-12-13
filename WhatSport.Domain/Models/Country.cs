using System.Collections.Generic;

namespace WhatSport.Domain.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public IEnumerable<City> Cities { get; set; } = new List<City>();
    }
}
