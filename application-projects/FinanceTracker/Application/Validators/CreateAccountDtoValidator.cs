using Application.Dtos;
using Domain.Entities;
using FluentValidation;

namespace Application.Validators
{
    public class CreateAccountDtoValidator : AbstractValidator<CreateAccountDto>
    {
        public CreateAccountDtoValidator()
        {
            RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Account name is required.")
            .MaximumLength(100).WithMessage("Name is too long.");

            RuleFor(x => x.Balance.Amount)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Initial balance cannot be negative.");

            RuleFor(x => x.Balance.Currency)
                .IsInEnum().WithMessage("A valid currency type must be selected");

            RuleFor(x => x.Type)
                .IsInEnum().WithMessage("A valid account type must be selected.");

            RuleFor(x => x.CreditLimit.Amount)
                .GreaterThan(0)
                .When(x => x.Type == AccountType.CreditCard)
                .WithMessage("Credit card must have a credit limit greater than 0.");

            RuleFor(x => x.CreditLimit.Currency)
                .IsInEnum()
                .When(x => x.Type == AccountType.CreditCard)
                .WithMessage("A valid currency type must be selected");
        }
    }
}
