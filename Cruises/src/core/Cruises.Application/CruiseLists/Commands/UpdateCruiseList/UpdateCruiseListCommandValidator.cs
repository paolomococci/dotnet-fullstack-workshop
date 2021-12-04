using Cruises.Application.Common.Interfaces;
using FluentValidation;

namespace Cruises.Application.CruiseLists.Commands.UpdateCruiseList
{
  public class UpdateCruiseListCommandValidator
    : AbstractValidator<UpdateCruiseListCommand>
  {
    private readonly IApplicationDbContext _iApplicationDbContext;

    public UpdateCruiseListCommandValidator(IApplicationDbContext context)
    {
      _iApplicationDbContext = context;

      RuleFor(updateCruiseListCommand => updateCruiseListCommand.Country)
        .NotEmpty().WithMessage("Country field is required")
        .MaximumLength(128).WithMessage(
          "The Country field accepts a maximum of 128 characters"
        );

      RuleFor(updateCruiseListCommand => updateCruiseListCommand.City)
        .NotEmpty().WithMessage("City field is required")
        .MaximumLength(128).WithMessage(
          "The City field accepts a maximum of 128 characters"
        );
    }
  }
}
