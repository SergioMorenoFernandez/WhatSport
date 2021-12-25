using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WhatSport.Domain;
using WhatSport.Domain.Models;
using WhatSport.Domain.Repositories;
using WhatSport.Infrastructure.Extensions;

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

        public async Task<IEnumerable<Equipment>> GetEquipmentByMatchAsync(int matchId, CancellationToken cancellationToken = default)
        {
            return await context.Equipments
                .Include(s => s.Player)
                .ThenInclude(s => s.User)
                .AsNoTracking()
                .Where(s => s.MatchId == matchId)
                .ToListAsync(cancellationToken);
        }

        
        public void UpdateEquipmentAsync(Equipment value)
        {
            context.Update(value);
            //context.DetachLocal(value, value.Id.ToString());
            //context.SaveChangesAsync(cancellationToken);
        }

        public void RemoveEquipmentAsync(Equipment value)
        {
            context.Remove(value);
        }

        public async Task<Equipment> GetEquipmentAsync(int equipmentId, CancellationToken cancellationToken = default)
        {
            return await context.Equipments
                .AsNoTracking()
                .Include(s => s.Player)
                .ThenInclude(s => s.User).AsNoTracking()
                .Include(s => s.Match)
                .ThenInclude(s => s.Players)
                .ThenInclude(s => s.User)
                .AsNoTracking()
                .Where(s => s.Id == equipmentId)
                .AsNoTracking()
                .SingleAsync(cancellationToken);
        }
    }
}
