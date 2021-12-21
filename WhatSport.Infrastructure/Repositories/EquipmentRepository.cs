using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WhatSport.Domain;
using WhatSport.Domain.Models;
using WhatSport.Domain.Repositories;

namespace WhatSport.Infrastructure.Repositories
{
    internal class EquipmentRepository : IEquipmentRepository
    {
        private readonly WhatSportContext context;

        public EquipmentRepository(WhatSportContext context)
        {
            this.context = context;
        }

        public IUnitOfWork UnitOfWork => context;

        public async Task AddEquipmentAsync(Equipment value, CancellationToken cancellationToken = default)
        {
            await context.AddAsync(value, cancellationToken);
        }

        public void UpdateEquipmentAsync(Equipment value, CancellationToken cancellationToken = default)
        {
           context.Update(value);
        }
    }
}
