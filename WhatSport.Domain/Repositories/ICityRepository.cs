using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WhatSport.Domain.Models;

namespace WhatSport.Domain.Repositories
{
    public interface ICityRepository
    {
        IUnitOfWork UnitOfWork { get; }

        Task<IEnumerable<City>> GetAllCitiesAsync(CancellationToken cancellationToken = default);
        Task<City> GetCityByIdAsync(int id, CancellationToken cancellationToken = default);
        Task AddCityAsync(City city, CancellationToken cancellationToken = default);
    }
}
