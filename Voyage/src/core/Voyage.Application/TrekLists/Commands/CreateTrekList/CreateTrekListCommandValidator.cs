using FluentValidation;
using Voyage.Application.Common.Interfaces;

namespace Voyage.Application.TrekLists.Commands.CreateTrekList
{
    public class CreateTrekListCommandValidator : AbstractValidator<CreateTrekListCommand>
    {
        private readonly IApplicationDbContext _iApplicationDbContext;

        public CreateTrekListCommandValidator(IApplicationDbContext context)
        {
            _iApplicationDbContext = context;

            RuleFor(createTrekListCommand => createTrekListCommand.Country)
                .NotEmpty().WithMessage("Country field is required")
                .MaximumLength(128).WithMessage("The Country field accepts a maximum of 128 characters");

            RuleFor(createTrekListCommand => createTrekListCommand.City)
                .NotEmpty().WithMessage("City field is required")
                .MaximumLength(128).WithMessage("The City field accepts a maximum of 128 characters");
        }
    }
}
