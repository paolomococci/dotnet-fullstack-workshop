using System.Threading;
using System.Threading.Tasks;
using Cruises.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Cruises.Application.CruisePackages.Commands.UpdateCruisePackage
{
  public class UpdateCruisePackageCommandValidator
    : AbstractValidator<UpdateCruisePackageCommand>
  {
    private readonly IApplicationDbContext _iApplicationDbContext;

    public UpdateCruisePackageCommandValidator(
      IApplicationDbContext context
    )
    {
      _iApplicationDbContext = context;

      RuleFor(updateCruisePackageCommand => updateCruisePackageCommand.Name)
          .NotEmpty().WithMessage("Name field is required.")
          .MaximumLength(128).WithMessage("Name field must not exceed 128 characters.")
          .MustAsync(NameFieldMustBeUnique).WithMessage("The specified name field already used.");
    }

    public async Task<bool> NameFieldMustBeUnique(
      string name, CancellationToken cancellationToken
    )
    {
      return await _iApplicationDbContext.CruisePackages.AllAsync(
        cruisePackage => cruisePackage.Name != name
      );
    }
  }
}
