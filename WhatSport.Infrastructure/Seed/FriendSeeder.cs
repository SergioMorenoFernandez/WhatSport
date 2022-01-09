using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WhatSport.Domain.Models;
using WhatSport.Domain.Extensions;

namespace WhatSport.Infrastructure.Seed
{
    public static class FriendSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var users = new List<Friend>
            {
                new Friend { Id = 1, UserId=2, FriendUserId=6},
                new Friend { Id = 2, UserId=6, FriendUserId=2},
                new Friend { Id = 3, UserId=6, FriendUserId=4 },
                new Friend { Id = 4, UserId=4, FriendUserId=6 },
            };

            modelBuilder.Entity<User>().HasData(users);
        }
    }
}
