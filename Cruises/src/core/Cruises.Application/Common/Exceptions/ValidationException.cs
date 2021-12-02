using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;

namespace Cruises.Application.Common.Exceptions
{
  public class ValidationException
    : Exception
  {
    public IDictionary<string, string[]> validationExceptionErrors { get; }

    public ValidationException()
      : base("At least one validation error has occurred!")
    {
      validationExceptionErrors = new Dictionary<string, string[]>();
    }

    public ValidationException(
      IEnumerable<ValidationFailure> failures
    ) : this()
    {
      var failureGroups = failures.GroupBy(
        validationFailure => validationFailure.PropertyName,
        validationFailure => validationFailure.ErrorMessage
      );

      foreach (var failureGroup in failureGroups)
      {
        var propertyName = failureGroup.Key;
        var propertyFailures = failureGroup.ToArray();
        validationExceptionErrors.Add(propertyName, propertyFailures);
      }
    }
  }
}
