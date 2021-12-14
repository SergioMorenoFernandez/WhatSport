using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WhatSport.Application.Models;
using WhatSport.Application.Queries.Levels;
using WhatSport.Domain.Extensions;

namespace WhatSport.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class LevelsController : ControllerBase
    {
        private readonly ILogger<LevelsController> logger;
        private readonly IMediator mediator;

        public LevelsController(ILogger<LevelsController> logger, IMediator mediator)
        {
            this.logger = logger;
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<Level[]>> GetUserLevels()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");
            var query = new GetUserLevelsQuery(userId);

            logger.LogInformation(
               "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
               query.GetGenericTypeName(),
               nameof(query.UserId),
               query.UserId,
               query);

            return await mediator.Send(query);
        }
    }
}
