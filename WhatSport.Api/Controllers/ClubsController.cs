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
        public async Task<ActionResult<Club[]>> GetAll()
        {
            var clubsQuery = new ClubsQuery();

            logger.LogInformation(
               "----- Sending command: {CommandName}: ({@Command})",
               clubsQuery.GetGenericTypeName(),
               clubsQuery);

            return await mediator.Send(clubsQuery);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Club>> GetById([FromRoute] ClubByIdQuery clubByIdQuery)
        {
            logger.LogInformation(
               "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
               clubByIdQuery.GetGenericTypeName(),
               nameof(clubByIdQuery.Id),
               clubByIdQuery.Id,
               clubByIdQuery);

            return await mediator.Send(clubByIdQuery);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> Post([FromBody] CreateClubCommand createClubCommand)
        {
            logger.LogInformation(
               "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
               createClubCommand.GetGenericTypeName(),
               nameof(createClubCommand.Name),
               createClubCommand.Name,
               createClubCommand);

            return await mediator.Send(createClubCommand);
        }
    }
}
