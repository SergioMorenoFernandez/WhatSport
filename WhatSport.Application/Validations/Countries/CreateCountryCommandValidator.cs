using FluentValidation;
using Microsoft.Extensions.Logging;
using WhatSport.Application.Commands.Countries;

namespace WhatSport.Application.Validations.Countries
{
    public class CreateCityCommandValidator : AbstractValidator<CreateCountryCommand>
    {
        public CreateCityCommandValidator(ILogger<CreateCityCommandValidator> logger)
        {
            RuleFor(command => command.Name).NotEmpty();

            logger.LogTrace("----- INSTANCE CREATED - {ClassName}", GetType().Name);
        }
    }
}
