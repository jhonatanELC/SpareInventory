using FluentValidation;

namespace Core.Services.SpareService.Commands.Create
{
    public class SpareAddValidator : AbstractValidator<SpareWithBrandToAdd>
    {
        public SpareAddValidator()
        {
            RuleFor(sb => sb.Sku)
                 .NotEmpty().WithMessage("{PropertyName} is required.");


        }
    }
}
