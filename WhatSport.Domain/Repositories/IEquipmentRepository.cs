using System.Threading;
using System.Threading.Tasks;
using WhatSport.Domain.Models;

namespace WhatSport.Domain.Repositories
{
    public interface IEquipmentRepository
    {
        IUnitOfWork UnitOfWork { get; }
        Task AddEquipmentAsync(Equipment value, CancellationToken cancellationToken = default);

        void UpdateEquipmentAsync(Equipment value, CancellationToken cancellationToken = default);
    }
}
