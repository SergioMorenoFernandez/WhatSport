using MediatR;
using WhatSport.Application.Models;
using WhatSport.Domain.Repositories;

namespace WhatSport.Application.Queries.Equipments
{
    internal class EquipmentQueryHandler : IRequestHandler<EquipmentQuery, EquipmentDto[]>
    {
        private readonly IEquipmentRepository repository;

        public EquipmentQueryHandler(IEquipmentRepository repository)
        {
            this.repository = repository;
        }

        public async Task<EquipmentDto[]> Handle(EquipmentQuery request, CancellationToken cancellationToken)
        {
            var result = await repository.GetEquipmentByMatchAsync(request.MatchId, cancellationToken);

            return result.Select(c => new EquipmentDto(c)).ToArray();
        }
    }
}
