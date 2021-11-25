using System.Threading;
using System.Threading.Tasks;
using Biking.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Biking.Application.TrekPackages.Commands.UpdateTrekPackageDetail
{
    public class UpdateTrekPackageDetailCommandValidator : AbstractValidator<UpdateTrekPackageDetailCommand>
    {
        private readonly IApplicationDbContext _iApplicationDbContext;

        public UpdateTrekPackageDetailCommandValidator(
            IApplicationDbContext context
        )
        {
            _iApplicationDbContext = context;

            RuleFor(updateTrekPackageDetailCommand => updateTrekPackageDetailCommand.ListId)
                .NotEmpty().WithMessage("ListId field is required")
                .MustAsync(ListIdFieldMustBeUnique).WithMessage("The specified identifier of the list already used.");

            RuleFor(updateTrekPackageDetailCommand => updateTrekPackageDetailCommand.Name)
                .NotEmpty().WithMessage("Name field is required")
                .MaximumLength(128).WithMessage("Name field must not exceed 128 characters.")
                .MustAsync(NameFieldMustBeUnique).WithMessage("The specified name field already used.");

            RuleFor(updateTrekPackageDetailCommand => updateTrekPackageDetailCommand.Hope)
                .MaximumLength(128).WithMessage("Hope field must not exceed 128 characters.")
                .NotEmpty().WithMessage("Hope field is required");

            RuleFor(updateTrekPackageDetailCommand => updateTrekPackageDetailCommand.MapLocation)
                .MaximumLength(128).WithMessage("MapLocation field must not exceed 128 characters.")
                .NotEmpty().WithMessage("MapLocation field is required");

            RuleFor(updateTrekPackageDetailCommand => updateTrekPackageDetailCommand.Price)
                .NotEmpty().WithMessage("Price field is required");

            RuleFor(updateTrekPackageDetailCommand => updateTrekPackageDetailCommand.Duration)
                .NotEmpty().WithMessage("Duration field is required");

            RuleFor(updateTrekPackageDetailCommand => updateTrekPackageDetailCommand.Confirmation)
                .NotEmpty().WithMessage("Confirmation field is required");

            RuleFor(updateTrekPackageDetailCommand => updateTrekPackageDetailCommand.Currency)
                .NotEmpty().WithMessage("Currency field is required");
        }

        public async Task<bool> ListIdFieldMustBeUnique(
            int ListId, CancellationToken cancellationToken
        )
        {
            return await _iApplicationDbContext.TrekPackages.AllAsync(
                trekPackage => trekPackage.ListId != ListId
            );
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
