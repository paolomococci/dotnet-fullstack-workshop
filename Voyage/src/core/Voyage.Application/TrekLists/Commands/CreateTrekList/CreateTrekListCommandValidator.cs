using FluentValidation;
using Voyage.Application.Common.Interfaces;

namespace Voyage.Application.TrekLists.Commands.CreateTrekList
{
    public class CreateTrekListCommandValidator : AbstractValidator<CreateTrekListCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateTrekListCommandValidator(IApplicationDbContext context)
        {
            _context = context;
            /*
            RuleFor(v => v.Country)
                .NotEmpty().WithMessage("Country field is required")
                .MaximumLength(128).WithMessage("The Country field accepts a maximum of 128 characters");

            RuleFor(v => v.City)
                .NotEmpty().WithMessage("City field is required")
                .MaximumLength(128).WithMessage("The City field accepts a maximum of 128 characters");
            */
        }
    }
}
