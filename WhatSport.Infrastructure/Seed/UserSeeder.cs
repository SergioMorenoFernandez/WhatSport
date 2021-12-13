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
                new User { Id = 1, Login = "admin", Name = "Sergio", LastName = "Moreno", Password = "test".GetMd5Hash(), Status = true, Role = "Admin" },
                new User { Id = 2, Login = "user", Name = "Pepe", LastName = "Lerepe", Password = "test".GetMd5Hash(), Status = false },
                new User { Id = 3, Login = "user1", Name = "Pepe", LastName = "Lerepe", Password = "test".GetMd5Hash(), Status = true },
            };

            modelBuilder.Entity<User>().HasData(users);
        }
    }
}
