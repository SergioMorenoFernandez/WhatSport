using MediatR;
using WhatSport.Domain.Models;
using WhatSport.Domain.Repositories;
using WhatSport.Domain.Extensions;

namespace WhatSport.Application.Commands.Scores
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
                Name = request.Name,
            };

            await repository.AddEquipmentAsync(value, cancellationToken);

            return await repository.UnitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
