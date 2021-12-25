using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WhatSport.Application.Commands.Countries;
using WhatSport.Application.Models;
using WhatSport.Application.Queries.Countries;
using WhatSport.Domain.Extensions;

namespace WhatSport.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class CountriesController : ControllerBase
    {
        private readonly ILogger<CountriesController> logger;
        private readonly IMediator mediator;

        public CountriesController(ILogger<CountriesController> logger, IMediator mediator)
        {
            this.logger = logger;
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<CountryDto[]>> GetAll()
        {
            var query = new CountriesQuery();

            logger.LogInformation(
               "----- Sending command: {CommandName}: ({@Command})",
               query.GetGenericTypeName(),
               query);

            return await mediator.Send(query);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CountryDto>> GetById([FromRoute] int id)
        {
            var query = new CountryByIdQuery(id);

            logger.LogInformation(
               "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
               query.GetGenericTypeName(),
               nameof(query.Id),
               query.Id,
               query);

            return await mediator.Send(query);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> Post([FromBody] CreateCountryCommand command)
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