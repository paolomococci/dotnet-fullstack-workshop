using Trekking.Application.Common.Interfaces;
using FluentValidation;

namespace Trekking.Application.TrekLists.Commands.UpdateTrekList
{
    public class UpdateTrekListCommandValidator : AbstractValidator<UpdateTrekListCommand>
    {
        private readonly IApplicationDbContext _iApplicationDbContext;

        public UpdateTrekListCommandValidator(IApplicationDbContext context)
        {
            _iApplicationDbContext = context;

            RuleFor(updateTrekListCommand => updateTrekListCommand.Country)
                .NotEmpty().WithMessage("Country field is required")
                .MaximumLength(128).WithMessage("The Country field accepts a maximum of 128 characters");

            RuleFor(updateTrekListCommand => updateTrekListCommand.City)
                .NotEmpty().WithMessage("City field is required")
                .MaximumLength(128).WithMessage("The City field accepts a maximum of 128 characters");
        }
    }
}
