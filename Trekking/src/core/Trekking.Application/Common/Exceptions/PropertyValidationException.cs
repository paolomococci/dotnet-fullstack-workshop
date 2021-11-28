using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;

namespace Trekking.Application.Common.Exceptions
{
    public class PropertyValidationException : Exception
    {
        public IDictionary<string, string[]> Errors { get; }

        public PropertyValidationException() : base("Validation failure")
        {
            Errors = new Dictionary<string, string[]>();
        }

        public PropertyValidationException(IEnumerable<ValidationFailure> failures) : this()
        {
            var failureGroups = failures.GroupBy(
                validationFailure => validationFailure.PropertyName,
                validationFailure => validationFailure.ErrorMessage
            );

            foreach (var failureGroup in failureGroups)
            {
                var propertyName = failureGroup.Key;
                var propertyFailures = failureGroup.ToArray();
                Errors.Add(propertyName, propertyFailures);
            }
        }
    }
}
