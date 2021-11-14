using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Voyage.Application.Common.Interfaces;

namespace Voyage.Application.TrekPackages.Commands.UpdateTrekPackage
{
    public class UpdateTrekPackageCommandValidator : AbstractValidator<UpdateTrekPackageCommand>
    {
        private readonly IApplicationDbContext _iApplicationDbContext;

        public UpdateTrekPackageCommandValidator(
            IApplicationDbContext context
        )
        {
            _iApplicationDbContext = context;

            RuleFor(updateTrekPackageCommand => updateTrekPackageCommand.Name)
                .NotEmpty().WithMessage("Name field is required.")
                .MaximumLength(128).WithMessage("Name field must not exceed 128 characters.")
                .MustAsync(NameFieldMustBeUnique).WithMessage("The specified name field already used.");
        }

        public async Task<bool> NameFieldMustBeUnique(
            string name, CancellationToken cancellationToken
        )
        {
            return await _iApplicationDbContext.TrekPackages.AllAsync(
                trekPackage => trekPackage.Name != name
            );
        }
    }
}
