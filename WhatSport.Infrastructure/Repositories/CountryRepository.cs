using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WhatSport.Domain;
using WhatSport.Domain.Models;
using WhatSport.Domain.Repositories;

namespace WhatSport.Infrastructure.Repositories
{
    internal class CountryRepository : ICountryRepository
    {
        private readonly WhatSportContext context;

        public CountryRepository(WhatSportContext context)
        {
            this.context = context;
        }

        public IUnitOfWork UnitOfWork => context;

        public async Task AddCountryAsync(Country country, CancellationToken cancellationToken = default)
        {
            await context.AddAsync(country, cancellationToken);
        }

        public async Task<IEnumerable<Country>> GetAllCountriesAsync(CancellationToken cancellationToken = default)
        {
            return await context.Countries.AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task<Country> GetCountryByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await context.Countries.AsNoTracking().SingleAsync(c => c.Id == id, cancellationToken);
        }
    }
}
