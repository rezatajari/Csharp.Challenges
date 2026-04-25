using Application.Dtos;
using FluentValidation;

namespace Application.Validators
{
    public class CreateAccountValidator:AbstractValidator<CreateAccountDto>
    {
        public CreateAccountValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Account name is required.")
                .MaximumLength(50).WithMessage("Name cannot exceed 50 characters.");

            RuleFor(x => x.Balance.Amount)
                .GreaterThanOrEqualTo(0).WithMessage("Initial balance cannot be negative.");

            RuleFor(x => x.Balance.Currency)
                .IsInEnum().WithMessage("Invalid account type.");
        }
    }
}
