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
        public async Task<ActionResult<Country[]>> GetAll()
        {
            var countriesQuery = new CountriesQuery();

            logger.LogInformation(
               "----- Sending command: {CommandName}: ({@Command})",
               countriesQuery.GetGenericTypeName(),
               countriesQuery);

            return await mediator.Send(countriesQuery);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Country>> GetById([FromRoute] CountryByIdQuery countryByIdQuery)
        {
            logger.LogInformation(
               "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
               countryByIdQuery.GetGenericTypeName(),
               nameof(countryByIdQuery.Id),
               countryByIdQuery.Id,
               countryByIdQuery);

            return await mediator.Send(countryByIdQuery);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> Post([FromBody] CreateCountryCommand createCountryCommand)
        {
            logger.LogInformation(
               "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
               createCountryCommand.GetGenericTypeName(),
               nameof(createCountryCommand.Name),
               createCountryCommand.Name,
               createCountryCommand);

            return await mediator.Send(createCountryCommand);
        }
    }
}