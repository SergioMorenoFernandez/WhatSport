using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WhatSport.Application.Commands.Clubs;
using WhatSport.Application.Models;
using WhatSport.Application.Queries.Clubs;
using WhatSport.Domain.Extensions;

namespace WhatSport.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class ClubsController : ControllerBase
    {
        private readonly ILogger<ClubsController> logger;
        private readonly IMediator mediator;

        public ClubsController(ILogger<ClubsController> logger, IMediator mediator)
        {
            this.logger = logger;
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<ClubDto[]>> GetAll()
        {
            var query = new ClubsQuery();

            logger.LogInformation(
               "----- Sending command: {CommandName}: ({@Command})",
               query.GetGenericTypeName(),
               query);

            return await mediator.Send(query);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClubDto>> GetById([FromRoute] int id)
        {
            var query = new ClubByIdQuery(id);

            logger.LogInformation(
               "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
               query.GetGenericTypeName(),
               nameof(query.Id),
               query.Id,
               query);

            return await mediator.Send(query);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> Post([FromBody] CreateClubCommand command)
        {
            logger.LogInformation(
               "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
               command.GetGenericTypeName(),
               nameof(command.Name),
               command.Name,
               command);

            return await mediator.Send(command);
        }
    }
}
