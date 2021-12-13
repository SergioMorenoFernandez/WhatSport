﻿using System.Threading;
using System.Threading.Tasks;
using WhatSport.Domain.Models;

namespace WhatSport.Domain.Repositories
{
    public interface IUserRepository
    {
        IUnitOfWork UnitOfWork { get; }

        Task<User?> GetUserByLoginAsync(string login, CancellationToken cancellationToken = default);
        Task<User> GetUserByIdAsync(int id, CancellationToken cancellationToken = default);
        void UpdateUser(User user);
    }
}