using FluentValidation;

namespace Core.Features.Spares.Commands.CreateSpare
{
    public class CreateSpareValidator : AbstractValidator<CreateSpareCommand>
    {
        public CreateSpareValidator()
        {
            RuleFor(sb => sb.Sku)
                 .NotEmpty().WithMessage("{PropertyName} is required.");


        }
    }
}
