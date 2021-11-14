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
        }
    }
}
