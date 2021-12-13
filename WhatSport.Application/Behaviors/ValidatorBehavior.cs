using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using WhatSport.Domain.Exceptions;
using WhatSport.Domain.Extensions;

namespace WhatSport.Application.Behaviors
{
    public class ValidatorBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
    {
        private readonly IEnumerable<IValidator<TRequest>> validators;
        private readonly ILogger<ValidatorBehavior<TRequest, TResponse>> logger;

        public ValidatorBehavior(IEnumerable<IValidator<TRequest>> validators,
                                 ILogger<ValidatorBehavior<TRequest, TResponse>> logger)
        {
            this.validators = validators;
            this.logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (!validators.Any())
            {
                return await next();
            }

            var typeName = request.GetGenericTypeName();

            logger.LogInformation("----- Validating command {CommandType}", typeName);

            var context = new ValidationContext<TRequest>(request);

            var errorsDictionary = validators
                .Select(x => x.Validate(context))
                .SelectMany(x => x.Errors)
                .Where(x => x != null)
                .GroupBy(
                    x => x.PropertyName,
                    x => x.ErrorMessage,
                    (propertyName, errorMessages) => new
                    {
                        Key = propertyName,
                        Values = errorMessages.Distinct().ToArray()
                    })
                .ToDictionary(x => x.Key, x => x.Values);

            if (errorsDictionary.Any())
            {
                logger.LogWarning("Validation errors - {CommandType} - Command: {@Command} - Errors: {@ValidationErrors}", typeName, request, errorsDictionary.Values);

                throw new Domain.Exceptions.ValidationException(errorsDictionary);
            }

            return await next();
        }
    }
}
