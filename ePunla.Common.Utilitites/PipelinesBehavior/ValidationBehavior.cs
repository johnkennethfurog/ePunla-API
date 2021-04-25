using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ePunla.Common.Utilitites.Response;
using ePunla.Common.Utilitites.Validations;
using FluentValidation;
using MediatR;

namespace ePunla.Common.Utilitites.PipelinesBehavior
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TResponse : MediatrResponse, new()
    {

        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var validationFailures = _validators
                .Select(x => x.Validate(request))
                .SelectMany(validationResult => validationResult.Errors)
                .Where(validationFailure => validationFailure != null)
                .ToList();

            if(validationFailures.Any())
            {
                var errors = new List<ErrorMessage>();
                validationFailures.ForEach(failure => errors.Add(new ErrorMessage(failure.ErrorMessage)));
                var ret = new TResponse();
                ret.ErrorMessages = errors;
                return Task.FromResult(ret);
            }

           return next();
        }
    }
}
