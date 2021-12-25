using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WhatSport.Domain.Models;

namespace WhatSport.Domain.Repositories
{
    public interface IEquipmentRepository
    {
        IUnitOfWork UnitOfWork { get; }

        Task<Equipment> GetEquipmentAsync(int equipmentId, CancellationToken cancellationToken = default);

        Task<IEnumerable<Equipment>> GetEquipmentByMatchAsync(int matchId, CancellationToken cancellationToken = default);

        Task AddEquipmentAsync(Equipment value, CancellationToken cancellationToken = default);

        void RemoveEquipmentAsync(Equipment value);

        void UpdateEquipmentAsync(Equipment value);
    }
}
