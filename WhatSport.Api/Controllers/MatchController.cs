using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using WhatSport.Application.Commands.Matches;
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


    }
}
