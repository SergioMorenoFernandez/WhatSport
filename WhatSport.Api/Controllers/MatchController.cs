using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WhatSport.Api.Models;
using WhatSport.Application.Commands.Matches;
using WhatSport.Application.Commands.Scores;
using WhatSport.Application.Models;
using WhatSport.Application.Queries.Matches;
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

        [HttpPost("{matchId}/join/{team}")]
        public async Task<ActionResult<bool>> Join([FromRoute] int matchId, [FromRoute] int team)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");
            var command = new JoinMatchCommand(userId, team, matchId);

            logger.LogInformation(
               "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
               command.GetGenericTypeName(),
               nameof(command.MatchId),
               command.MatchId,
               command);
            

            return await mediator.Send(command);
        }

        [HttpDelete("{matchId}/unjoin/{playerId}")]
        public async Task<ActionResult<bool>> Unjoin([FromRoute] int matchId, [FromRoute] int playerId)
        {
            var command = new UnjoinMatchCommand(matchId, playerId);
            logger.LogInformation(
               "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
               command.GetGenericTypeName(),
               nameof(command.MatchId),
               command.MatchId,
               command);


            return await mediator.Send(command);
        }

        [HttpPost("{id}/equipment")]
        public async Task<ActionResult<bool>> AddEquipment([FromRoute] int id, [FromBody] PlayerJoin request)
        {
            //var command = new JoinMatchCommand(request.UserId, request.Team, id);

            //logger.LogInformation(
            //   "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
            //   command.GetGenericTypeName(),
            //   nameof(command.MatchId),
            //   command.MatchId,
            //   command);


            //return await mediator.Send(command);

            return true;
        }

        [HttpDelete("{id}/equipment/{idEquipment}")]
        public async Task<ActionResult<bool>> RemmoveEquipment([FromRoute] int id, [FromRoute] int idEquipment)
        {
            //var command = new JoinMatchCommand(request.UserId, request.Team, id);

            //logger.LogInformation(
            //   "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
            //   command.GetGenericTypeName(),
            //   nameof(command.MatchId),
            //   command.MatchId,
            //   command);


            //return await mediator.Send(command);

            return true;
        }

        [HttpPut("{id}/equipment/{idEquipment}/assign")]
        public async Task<ActionResult<bool>> AssignEquipment([FromRoute] int id, [FromRoute] int idEquipment)
        {
            //var command = new JoinMatchCommand(request.UserId, request.Team, id);

            //logger.LogInformation(
            //   "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
            //   command.GetGenericTypeName(),
            //   nameof(command.MatchId),
            //   command.MatchId,
            //   command);


            //return await mediator.Send(command);

            return true;
        }

        [HttpPut("{id}/equipment/{idEquipment}/unassign")]
        public async Task<ActionResult<bool>> UnassignEquipment([FromRoute] int id, [FromRoute] int idEquipment)
        {
            //var command = new JoinMatchCommand(request.UserId, request.Team, id);

            //logger.LogInformation(
            //   "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
            //   command.GetGenericTypeName(),
            //   nameof(command.MatchId),
            //   command.MatchId,
            //   command);


            //return await mediator.Send(command);

            return true;
        }

        [HttpPost("{id}/score")]
        public async Task<ActionResult<bool>> AddScore([FromRoute] int id, [FromBody] ScoreCommand command)
        {

            command.MatchId= id;

            logger.LogInformation(
               "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
               command.GetGenericTypeName(),
               nameof(command.MatchId),
               command.MatchId,
               command);


            return await mediator.Send(command);

        }

        [HttpPut("{id}/score/Confirm")]
        public async Task<ActionResult<bool>> ConfirmScore([FromRoute] int id)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");
            var command = new ScoreConfirmationCommand(id,userId);

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
