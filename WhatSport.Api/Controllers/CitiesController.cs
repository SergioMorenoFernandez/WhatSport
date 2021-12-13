using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WhatSport.Application.Commands.Cities;
using WhatSport.Application.Models;
using WhatSport.Application.Queries.Cities;
using WhatSport.Domain.Extensions;

namespace WhatSport.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class CitiesController : ControllerBase
    {
        private readonly ILogger<CitiesController> logger;
        private readonly IMediator mediator;

        public CitiesController(ILogger<CitiesController> logger, IMediator mediator)
        {
            this.logger = logger;
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<City[]>> GetAll()
        {
            var citiesQuery = new CitiesQuery();

            logger.LogInformation(
               "----- Sending command: {CommandName}: ({@Command})",
               citiesQuery.GetGenericTypeName(),
               citiesQuery);

            return await mediator.Send(citiesQuery);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<City>> GetById([FromRoute] CountryByIdQuery cityByIdQuery)
        {
            logger.LogInformation(
               "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
               cityByIdQuery.GetGenericTypeName(),
               nameof(cityByIdQuery.Id),
               cityByIdQuery.Id,
               cityByIdQuery);

            return await mediator.Send(cityByIdQuery);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> Post([FromBody] CreateCityCommand createCityCommand)
        {
            logger.LogInformation(
               "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
               createCityCommand.GetGenericTypeName(),
               nameof(createCityCommand.Name),
               createCityCommand.Name,
               createCityCommand);

            return await mediator.Send(createCityCommand);
        }
    }
}