using MediatR;
using WhatSport.Domain.Models;
using WhatSport.Domain.Repositories;

namespace WhatSport.Application.Commands.Matches
{
    public class JoinMatchCommandHandler : IRequestHandler<JoinMatchCommand, bool>
    {
        private readonly IPlayerRepository repository;
        private readonly IMatchRepository matchRepository;

        public JoinMatchCommandHandler(IPlayerRepository repository, ISportRepository sportRepository, IMatchRepository matchRepository)
        {
            this.repository = repository;
            this.matchRepository = matchRepository;
        }

        public async Task<bool> Handle(JoinMatchCommand request, CancellationToken cancellationToken)
        {
            var match = await matchRepository.GetMatchByIdAsync(request.MatchId, cancellationToken);

            //comprobar que hay hueco en el equipo
            if (match.Players.Where(c => c.Team == request.Team).Count() >= match.Sport?.NumberPlayers / 2)
            {
                throw new Exception("There is no gap in the team");
            }

            //comprobar que no este ya añadido al equipo
            if (match.Players.Any(c => c.UserId == request.UserId))
            {
                throw new ApplicationException("User is already joined to match");
            }

            var value = new Player
                {
                    MatchId = request.MatchId,
                    UserId = request.UserId,
                    Team = request.Team
                };

                await repository.AddPlayerAsync(value, cancellationToken);

                return await repository.UnitOfWork.SaveChangesAsync(cancellationToken);
            
        }
    }
}
