using Application.Dtos.Requests;
using Domain.Entities;
using FluentValidation;

namespace Application.Shared.Validators
{
    public class InputTxDtoValidator : AbstractValidator<AddTransaction>
    {
        public InputTxDtoValidator()
        {
            RuleFor(x => x.AccountId)
                .NotEmpty().WithMessage("Source account is required.");

            RuleFor(x => x.Amount.Amount)
                .GreaterThan(0).WithMessage("Transaction amount must be greater than zero.");

            RuleFor(x => x.Amount.Currency)
                .IsInEnum().WithMessage("Invalid currency.");

            RuleFor(x => x.TransactionType)
                .IsInEnum().WithMessage("Invalid transaction type.");

            RuleFor(x => x.TargetAccountId)
                .NotEmpty()
                .NotEqual(x => x.AccountId).WithMessage("Cannot transfer money to the same account.")
                .When(x => x.TransactionType == TransactionType.Transfer)
                .WithMessage("A valid target account is required for transfers.");

            RuleFor(x => x.Description)
                .MaximumLength(250).WithMessage("Description is too long.");
        }
    }
}
