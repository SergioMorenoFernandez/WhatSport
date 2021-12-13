using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WhatSport.Domain.Models;

namespace WhatSport.Domain.Repositories
{
    public interface ICountryRepository
    {
        IUnitOfWork UnitOfWork { get; }

        Task<IEnumerable<Country>> GetAllCountriesAsync(CancellationToken cancellationToken = default);
        Task<Country> GetCountryByIdAsync(int id, CancellationToken cancellationToken = default);
        Task AddCountryAsync(Country country, CancellationToken cancellationToken = default);
    }
}
