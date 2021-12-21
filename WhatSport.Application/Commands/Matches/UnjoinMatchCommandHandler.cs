using MediatR;
using WhatSport.Domain.Models;
using WhatSport.Domain.Repositories;

namespace WhatSport.Application.Commands.Matches
{
    public class UnjoinMatchCommandHandler : IRequestHandler<UnjoinMatchCommand, bool>
    {
        private readonly IPlayerRepository repository;
        private readonly IMatchRepository matchRepository;

        public UnjoinMatchCommandHandler(IPlayerRepository repository, IMatchRepository matchRepository)
        {
            this.repository = repository;
            this.matchRepository = matchRepository;
        }

        public async Task<bool> Handle(UnjoinMatchCommand request, CancellationToken cancellationToken)
        {
            var match = await matchRepository.GetMatchByIdAsync(request.MatchId, cancellationToken);

            var player = match.Players.SingleOrDefault(c => c.UserId == request.UserId);
            //comprobar que existe en el equipo
            if (player == null)
                throw new Exception("User is not joined to this match");

            repository.RemovePlayer(player, cancellationToken);

            return await repository.UnitOfWork.SaveChangesAsync(cancellationToken);
            
        }
    }
}
