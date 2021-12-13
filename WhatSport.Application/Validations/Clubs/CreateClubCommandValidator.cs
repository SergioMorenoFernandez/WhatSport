using FluentValidation;
using Microsoft.Extensions.Logging;
using WhatSport.Application.Commands.Clubs;

namespace WhatSport.Application.Validations.Clubs
{
    public class CreateClubCommandValidator : AbstractValidator<CreateClubCommand>
    {
        public CreateClubCommandValidator(ILogger<CreateClubCommandValidator> logger)
        {
            RuleFor(command => command.Name).NotEmpty();
            RuleFor(command => command.CityId).GreaterThan(0);

            logger.LogTrace("----- INSTANCE CREATED - {ClassName}", GetType().Name);
        }
    }
}
