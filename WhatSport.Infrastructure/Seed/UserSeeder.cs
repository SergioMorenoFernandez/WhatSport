using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WhatSport.Domain.Models;
using WhatSport.Domain.Extensions;

namespace WhatSport.Infrastructure.Seed
{
    public static class UserSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var users = new List<User>
            {
                new User { Id = 1, Login = "admin@uoc.edu", Name = "Sergio", LastName = "Moreno", Password = "test123.123".GetMd5Hash(), Status = true, Role = "Admin" },
                new User { Id = 2, Login = "user", Name = "Pepe", LastName = "Lerepe", Password = "test123.123".GetMd5Hash(), Status = false },
                new User { Id = 3, Login = "user1", Name = "Amparo", LastName = "latrusca", Password = "test123.123".GetMd5Hash(), Status = true },
                new User { Id = 4, Login = "user4", Name = "Florencio", LastName = "Perez", Password = "test123.123*".GetMd5Hash(), Status = true },
                new User { Id = 5, Login = "user5", Name = "Maria", LastName = "Pelaez", Password = "test123.123*".GetMd5Hash(), Status = true },
                new User { Id = 6, Login = "test@uoc.edu", Name = "Sergio", LastName = "Moreno", Password = "test123.123".GetMd5Hash(), Status = true },
            };

            modelBuilder.Entity<User>().HasData(users);
        }
    }
}
