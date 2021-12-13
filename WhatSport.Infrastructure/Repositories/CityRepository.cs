using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WhatSport.Domain;
using WhatSport.Domain.Models;
using WhatSport.Domain.Repositories;

namespace WhatSport.Infrastructure.Repositories
{
    internal class CityRepository : ICityRepository
    {
        private readonly WhatSportContext context;

        public CityRepository(WhatSportContext context)
        {
            this.context = context;
        }

        public IUnitOfWork UnitOfWork => context;

        public async Task<IEnumerable<City>> GetAllCitiesAsync(CancellationToken cancellationToken = default)
        {
            return await context.Cities.Include(c => c.Country).AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task<City> GetCityByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await context.Cities.Include(c => c.Country).AsNoTracking().SingleAsync(c => c.Id == id, cancellationToken);
        }

        public async Task AddCityAsync(City city, CancellationToken cancellationToken = default)
        {
            await context.AddAsync(city, cancellationToken);
        }
    }
}
