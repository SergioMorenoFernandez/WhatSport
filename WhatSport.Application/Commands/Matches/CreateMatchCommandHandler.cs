using MediatR;
using WhatSport.Domain.Models;
using WhatSport.Domain.Repositories;

namespace WhatSport.Application.Commands.Matches
{
    public class CreateMatchCommandHandler : IRequestHandler<CreateMatchCommand, int>
    {
        private readonly IMatchRepository repository;

        public CreateMatchCommandHandler(IMatchRepository repository)
        {
            this.repository = repository;
        }

        public async Task<int> Handle(CreateMatchCommand request, CancellationToken cancellationToken)
        {
            var value = new Match
            {
                ClubId= request.ClubId,
                SportId= request.SportId,
                TimeInMinutes= request.TimeInMinutes,
                DateStart= request.DateStart,
                Note= request.Note,
                OtherPlace= request.OtherPlace
            };

            await repository.AddMatchAsync(value, cancellationToken);

            await repository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return value.Id;
        }
    }
}
