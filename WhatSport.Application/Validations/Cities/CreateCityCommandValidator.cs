using FluentValidation;
using Microsoft.Extensions.Logging;
using WhatSport.Application.Commands.Cities;

namespace WhatSport.Application.Validations.Cities
{
    public class CreateCityCommandValidator : AbstractValidator<CreateCityCommand>
    {
        public CreateCityCommandValidator(ILogger<CreateCityCommandValidator> logger)
        {
            RuleFor(command => command.Name).NotEmpty();
            RuleFor(command => command.CountryId).GreaterThan(0);

            logger.LogTrace("----- INSTANCE CREATED - {ClassName}", GetType().Name);
        }
    }
}
