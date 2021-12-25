using MediatR;
using WhatSport.Domain.Models;
using WhatSport.Domain.Repositories;

namespace WhatSport.Application.Commands.Equipments
{
    internal class AssignEquipmentCommandCommandHandler : IRequestHandler<AssignEquipmentCommand, bool>
    {
        private readonly IEquipmentRepository repository;

        public AssignEquipmentCommandCommandHandler(IEquipmentRepository repository)
        {
            this.repository = repository;
        }

        public async Task<bool> Handle(AssignEquipmentCommand request, CancellationToken cancellationToken)
        {
            var equipment = await repository.GetEquipmentAsync(request.EquipmentId,cancellationToken);

            var player = equipment.Match?.Players.Where(s => s.UserId == request.UserId).FirstOrDefault();

            if (player == default)
            {
                throw new ApplicationException("user not found for selected match!!");
            }

            if (request.Assign == true)
            { 
                if(equipment.PlayerId != default)
                {
                    throw new ApplicationException("equipment already assigned!!");
                }

                equipment.PlayerId = player.Id;
            }
            else
            {
                if (equipment.PlayerId == default)
                {
                    throw new ApplicationException("equipment whitout assign!!");
                }
                else if (equipment.Player?.UserId != request.UserId)
                {
                    throw new ApplicationException("It is not possible to unassign equipment of other player!!");
                }

                equipment.PlayerId = null;
                equipment.Player = null;
            }

            repository.UpdateEquipmentAsync(equipment);

            return await repository.UnitOfWork.SaveChangesAsync(cancellationToken);

        }
    }
}
