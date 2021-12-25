using MediatR;
using WhatSport.Domain.Models;
using WhatSport.Domain.Repositories;

namespace WhatSport.Application.Commands.Equipments
{
    internal class DeleteEquipmentCommandCommandHandler : IRequestHandler<DeleteEquipmentCommand, bool>
    {
        private readonly IEquipmentRepository repository;

        public DeleteEquipmentCommandCommandHandler(IEquipmentRepository repository)
        {
            this.repository = repository;
        }

        public async Task<bool> Handle(DeleteEquipmentCommand request, CancellationToken cancellationToken)
        {
            var value = new Equipment
            {
                Id = request.Id,
            };

            var equipment = await repository.GetEquipmentAsync(request.Id, cancellationToken);


            if (equipment.MatchId != request.Matchid)
            {
                throw new ApplicationException("Equipment is not from this match!!");
            }

            repository.RemoveEquipmentAsync(value);

            return await repository.UnitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
