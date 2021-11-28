using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Trekking.Application.Common.Exceptions;
using FluentValidation;
using MediatR;

namespace Trekking.Application.Common.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _iEnumerableIValidatorTRequest;

        public ValidationBehavior(
            IEnumerable<IValidator<TRequest>> validators
        )
        {
            _iEnumerableIValidatorTRequest = validators;
        }

        public async Task<TResponse> Handle(
            TRequest request,
            CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next
        )
        {
            if (!_iEnumerableIValidatorTRequest.Any())
            {
                return await next();
            }

            var context = new ValidationContext<TRequest>(request);

            var validationResults = await Task.WhenAll(
                _iEnumerableIValidatorTRequest.Select(
                    validator => validator.ValidateAsync(context, cancellationToken)
                )
            );

            var failures = validationResults
                .SelectMany(validationResult => validationResult.Errors)
                .Where(validationFailure => validationFailure != null).ToList();

            if (failures.Count != 0)
            {
                throw new PropertyValidationException(failures);
            }

            return await next();
        }
    }
}
