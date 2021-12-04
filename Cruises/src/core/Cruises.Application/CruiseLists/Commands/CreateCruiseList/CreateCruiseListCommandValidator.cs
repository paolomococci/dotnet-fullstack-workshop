using Cruises.Application.Common.Interfaces;
using FluentValidation;

namespace Cruises.Application.CruiseLists.Commands.CreateCruiseList
{
  public class CreateCruiseListCommandValidator
    : AbstractValidator<CreateCruiseListCommand>
  {
    private readonly IApplicationDbContext _iApplicationDbContext;

    public CreateCruiseListCommandValidator(IApplicationDbContext context)
    {
      _iApplicationDbContext = context;

      RuleFor(createCruiseListCommand => createCruiseListCommand.Country)
        .NotEmpty().WithMessage("Country field is required")
        .MaximumLength(128).WithMessage(
          "The Country field accepts a maximum of 128 characters"
        );

      RuleFor(createCruiseListCommand => createCruiseListCommand.City)
        .NotEmpty().WithMessage("City field is required")
        .MaximumLength(128).WithMessage(
          "The City field accepts a maximum of 128 characters"
        );
    }
  }
}
