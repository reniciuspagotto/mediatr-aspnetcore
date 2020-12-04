using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRWithAspNetCore.Behavior
{
    public class FailFastValidationBehavior<TRequest, TResponse> :
        IPipelineBehavior<TRequest, TResponse> where TResponse : Result
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public FailFastValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var failures = _validators
                .Select(validator => validator.Validate(request))
                .SelectMany(result => result.Errors)
                .Where(error => error != null)
                .ToList();

            return failures.Any() ? Errors(failures) : next();
        }

        private static Task<TResponse> Errors(IEnumerable<ValidationFailure> failures)
        {
            var response = new Result();

            foreach (var failure in failures)
            {
                response.Errors.Add(failure.ErrorMessage);
            }

            return Task.FromResult(response as TResponse);
        }
    }
}
