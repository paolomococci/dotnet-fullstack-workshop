using System.Threading;
using System.Threading.Tasks;
using Cruises.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Cruises.Application.CruisePackages.Commands.UpdateCruisePackageDetail
{
  public class UpdateCruisePackageDetailCommandValidator
    : AbstractValidator<UpdateCruisePackageDetailCommand>
  {
    private readonly IApplicationDbContext _iApplicationDbContext;

    public UpdateCruisePackageDetailCommandValidator(
      IApplicationDbContext context
    )
    {
      _iApplicationDbContext = context;

      RuleFor(updateCruisePackageDetailCommand => updateCruisePackageDetailCommand.ListId)
          .NotEmpty().WithMessage("ListId field is required")
          .MustAsync(ListIdFieldMustBeUnique).WithMessage("The specified identifier of the list already used.");

      RuleFor(updateCruisePackageDetailCommand => updateCruisePackageDetailCommand.Name)
          .NotEmpty().WithMessage("Name field is required")
          .MaximumLength(128).WithMessage("Name field must not exceed 128 characters.")
          .MustAsync(NameFieldMustBeUnique).WithMessage("The specified name field already used.");

      RuleFor(updateCruisePackageDetailCommand => updateCruisePackageDetailCommand.Hope)
          .MaximumLength(128).WithMessage("Hope field must not exceed 128 characters.")
          .NotEmpty().WithMessage("Hope field is required");

      RuleFor(updateCruisePackageDetailCommand => updateCruisePackageDetailCommand.MapLocation)
          .MaximumLength(128).WithMessage("MapLocation field must not exceed 128 characters.")
          .NotEmpty().WithMessage("MapLocation field is required");

      RuleFor(updateCruisePackageDetailCommand => updateCruisePackageDetailCommand.Price)
          .NotEmpty().WithMessage("Price field is required");

      RuleFor(updateCruisePackageDetailCommand => updateCruisePackageDetailCommand.Duration)
          .NotEmpty().WithMessage("Duration field is required");

      RuleFor(updateCruisePackageDetailCommand => updateCruisePackageDetailCommand.Confirmation)
          .NotEmpty().WithMessage("Confirmation field is required");

      RuleFor(updateCruisePackageDetailCommand => updateCruisePackageDetailCommand.Currency)
          .NotEmpty().WithMessage("Currency field is required");
    }

    public async Task<bool> ListIdFieldMustBeUnique(
      int ListId, CancellationToken cancellationToken
    )
    {
      return await _iApplicationDbContext.CruisePackages.AllAsync(
        cruisePackage => cruisePackage.ListId != ListId
      );
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
