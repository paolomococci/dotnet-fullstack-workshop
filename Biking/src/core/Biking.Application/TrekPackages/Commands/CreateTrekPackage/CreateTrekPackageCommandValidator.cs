using System.Threading;
using System.Threading.Tasks;
using Biking.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Biking.Application.TrekPackages.Commands.CreateTrekPackage
{
    public class CreateTrekPackageCommandValidator : AbstractValidator<CreateTrekPackageCommand>
    {
        private readonly IApplicationDbContext _iApplicationDbContext;

        public CreateTrekPackageCommandValidator(IApplicationDbContext context)
        {
            _iApplicationDbContext = context;

            RuleFor(createTrekPackageCommand => createTrekPackageCommand.Name)
                .NotEmpty().WithMessage("Name field is required.")
                .MaximumLength(128).WithMessage("Name field must not exceed 128 characters.")
                .MustAsync(NameFieldMustBeUnique).WithMessage("The specified name field already used.");

            RuleFor(createTrekPackageCommand => createTrekPackageCommand.ListId)
                .NotEmpty().WithMessage("ListId field is required");
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
