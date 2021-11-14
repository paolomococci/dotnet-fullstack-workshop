using FluentValidation;
using Voyage.Application.Common.Interfaces;

namespace Voyage.Application.TrekPackages.Commands.UpdateTrekPackageDetail
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
                .NotEmpty().WithMessage("ListId field is required");

            RuleFor(updateTrekPackageDetailCommand => updateTrekPackageDetailCommand.Name)
                .NotEmpty().WithMessage("Name field is required");

            RuleFor(updateTrekPackageDetailCommand => updateTrekPackageDetailCommand.Hope)
                .NotEmpty().WithMessage("Hope field is required");

            RuleFor(updateTrekPackageDetailCommand => updateTrekPackageDetailCommand.MapLocation)
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
    }
}
