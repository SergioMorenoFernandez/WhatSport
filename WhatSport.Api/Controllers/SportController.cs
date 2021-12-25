using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WhatSport.Application.Models;
using WhatSport.Application.Queries.Users;
using WhatSport.Domain.Extensions;
namespace WhatSport.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class SportController : ControllerBase
    {
        private readonly ILogger<SportController> logger;
        private readonly IMediator mediator;

        public SportController(ILogger<SportController> logger, IMediator mediator)
        {
            this.logger = logger;
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<SportDto[]>> GetAll()
        {
            var query = new SportQuery();

            logger.LogInformation(
               "----- Sending command: {CommandName}: ({@Command})",
               query.GetGenericTypeName(),
               query);

            return await mediator.Send(query);
        }

        [HttpGet("{sportId}")]
        public async Task<ActionResult<SportDto>> Get([FromRoute] int sportId)
        {
            var query = new SportByIdQuery(sportId);

            logger.LogInformation(
               "----- Sending command: {CommandName}: ({@Command})",
               query.GetGenericTypeName(),
               query);

            return await mediator.Send(query);
        }
    }
}
