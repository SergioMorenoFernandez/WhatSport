using MediatR;
using WhatSport.Domain.Models;
using WhatSport.Domain.Repositories;

namespace WhatSport.Application.Commands.Matches
{
    public class CreateMatchCommandHandler : IRequestHandler<CreateMatchCommand, bool>
    {
        private readonly IMatchRepository repository;

        public CreateMatchCommandHandler(IMatchRepository repository)
        {
            this.repository = repository;
        }

        public async Task<bool> Handle(CreateMatchCommand request, CancellationToken cancellationToken)
        {
            var value = new Match
            {
                ClubId= request.ClubId,
                SportId= request.SportId,
                DateEnd= request.DateEnd,
                DateStart= request.DateStart,
                Note= request.Note,
                OtherPlace= request.OtherPlace
            };

            await repository.AddMatchAsync(value, cancellationToken);

            return await repository.UnitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
