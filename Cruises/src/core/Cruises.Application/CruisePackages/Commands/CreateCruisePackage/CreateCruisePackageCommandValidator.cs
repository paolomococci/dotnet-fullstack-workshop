using System.Threading;
using System.Threading.Tasks;
using Cruises.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Cruises.Application.CruisePackages.Commands.CreateCruisePackage
{
  public class CreateCruisePackageCommandValidator
    : AbstractValidator<CreateCruisePackageCommand>
  {
    private readonly IApplicationDbContext _iApplicationDbContext;

    public CreateCruisePackageCommandValidator(IApplicationDbContext context)
    {
      _iApplicationDbContext = context;

      RuleFor(createCruisePackageCommand => createCruisePackageCommand.Name)
        .NotEmpty().WithMessage("Name field is required.")
        .MaximumLength(128).WithMessage("Name field must not exceed 128 characters.")
        .MustAsync(NameFieldMustBeUnique).WithMessage("The specified name field already used.");

      RuleFor(createCruisePackageCommand => createCruisePackageCommand.ListId)
        .NotEmpty().WithMessage("ListId field is required");
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
