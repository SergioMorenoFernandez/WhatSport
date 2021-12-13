using System;
using System.Threading;
using System.Threading.Tasks;

namespace WhatSport.Domain
{
    public interface IUnitOfWork
    {
        Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
