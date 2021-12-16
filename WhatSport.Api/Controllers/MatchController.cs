using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WhatSport.Api.Models;
using WhatSport.Application.Commands.Matches;
using WhatSport.Application.Models;
using WhatSport.Application.Queries.Matches;
using WhatSport.Application.Queries.Users;
using WhatSport.Domain.Extensions;

namespace WhatSport.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class MatchController : ControllerBase
    {
        private readonly ILogger<MatchController> logger;
        private readonly IMediator mediator;

        public MatchController(ILogger<MatchController> logger, IMediator mediator)
        {
            this.logger = logger;
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<Match[]>> Get([FromQuery] MatchQuery query)
        {
            logger.LogInformation(
               "----- Sending command: {CommandName}: ({@Command})",
               query.GetGenericTypeName(),
               query);

            return await mediator.Send(query);
        }

        [HttpGet("{id}/team/{idTeam}")]
        public async Task<ActionResult<User[]>> GetPlayers([FromRoute] int id, [FromRoute] int idTeam)
        {
            var query = new PlayerQuery(id,idTeam);

            logger.LogInformation(
               "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
               query.GetGenericTypeName(),
               nameof(query.MatchId),
               query.MatchId,
               query);

            return await mediator.Send(query);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Match>> GetById([FromRoute] int id)
        {
            var query = new MatchByIdQuery(id);

            logger.LogInformation(
               "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
               query.GetGenericTypeName(),
               nameof(query.Id),
               query.Id,
               query);

            return await mediator.Send(query);
        }

        [HttpGet("TotalMatch")]
        public async Task<ActionResult<long>> TotalMatchByUser([FromQuery] MatchTotalQuery query)
        {
            logger.LogInformation(
               "----- Sending command: {CommandName}: ({@Command})",
               query.GetGenericTypeName(),
               query);

            return await mediator.Send(query);
        }


        [HttpPost]
        public async Task<ActionResult<bool>> Post([FromBody] CreateMatchCommand command)
        {
            logger.LogInformation(
               "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
               command.GetGenericTypeName(),
               nameof(command.SportId),
               command.SportId,
               command);

            return await mediator.Send(command);
        }

        [HttpPost("/match/{id}/Join")]
        public async Task<ActionResult<bool>> Join([FromRoute] int id,[FromBody] PlayerJoin request)
        {
            var command = new JoinMatchCommand(request.UserId,request.Team,id);

            logger.LogInformation(
               "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
               command.GetGenericTypeName(),
               nameof(command.MatchId),
               command.MatchId,
               command);
            

            return await mediator.Send(command);
        }

        [HttpDelete("/match/{id}/disjoin/{idUser}")]
        public async Task<ActionResult<bool>> DisJoin([FromRoute] int id, [FromRoute] int idUser)
        {

            var command = new DisJoinMatchCommand(idUser, id);
            logger.LogInformation(
               "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
               command.GetGenericTypeName(),
               nameof(command.MatchId),
               command.MatchId,
               command);


            return await mediator.Send(command);
        }


    }
}
