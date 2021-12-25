using MediatR;
using WhatSport.Domain.Models;
using WhatSport.Domain.Repositories;

namespace WhatSport.Application.Commands.Equipments
{
    internal class EquipmentCommandHandler : IRequestHandler<EquipmentCommand, bool>
    {
        private readonly IEquipmentRepository repository;

        public EquipmentCommandHandler(IEquipmentRepository repository)
        {
            this.repository = repository;
        }

        public async Task<bool> Handle(EquipmentCommand request, CancellationToken cancellationToken)
        {
            var value = new Equipment
            {
                MatchId = request.MatchId,
                Description = request.Description,
            };

            await repository.AddEquipmentAsync(value, cancellationToken);

            return await repository.UnitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
