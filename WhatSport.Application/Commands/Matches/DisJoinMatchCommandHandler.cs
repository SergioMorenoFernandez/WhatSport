using MediatR;
using WhatSport.Domain.Models;
using WhatSport.Domain.Repositories;

namespace WhatSport.Application.Commands.Matches
{
    public class DisJoinMatchCommandHandler : IRequestHandler<DisJoinMatchCommand, bool>
    {
        private readonly IPlayerRepository repository;
        private readonly IMatchRepository matchRepository;

        public DisJoinMatchCommandHandler(IPlayerRepository repository, ISportRepository sportRepository, IMatchRepository matchRepository)
        {
            this.repository = repository;
            this.matchRepository = matchRepository;
        }

        public async Task<bool> Handle(DisJoinMatchCommand request, CancellationToken cancellationToken)
        {
            var match = await matchRepository.GetMatchByIdAsync(request.MatchId, cancellationToken);


            var player = match.Players.SingleOrDefault(c => c.UserId == request.UserId);
            //comprobar que existe en el equipo
            if (player == null)
            {
                throw new Exception("User is not joined to this match");
            }

            await repository.RemovePlayerAsync(player, cancellationToken);

            return await repository.UnitOfWork.SaveChangesAsync(cancellationToken);
            
        }
    }
}
