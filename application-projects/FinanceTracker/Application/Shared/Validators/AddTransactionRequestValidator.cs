using Application.Dtos.Requests;
using Domain.Entities;
using FluentValidation;

namespace Application.Shared.Validators
{
    public class AddTransactionRequestValidator : AbstractValidator<AddTransactionRequest>
    {
        public AddTransactionRequestValidator()
        {
            RuleFor(x => x.AccountId)
                .NotEmpty().WithMessage("Source account is required.");

            RuleFor(x => x.Amount)
                .GreaterThan(0).WithMessage("Transaction amount must be greater than zero.");

            RuleFor(x => x.Currency)
                .IsInEnum().WithMessage("Invalid currency.");

            RuleFor(x => x.Type)
                .IsInEnum().WithMessage("Invalid transaction type.");

            RuleFor(x => x.TargetAccountId)
                .NotEmpty()
                .NotEqual(x => x.AccountId).WithMessage("Cannot transfer money to the same account.")
                .When(x => x.Type == TransactionType.Transfer)
                .WithMessage("A valid target account is required for transfers.");

            RuleFor(x => x.TransactionDescription)
                .MaximumLength(250).WithMessage("Transaction Description is too long.");

            RuleFor(x => x.CategoryDescription)
           .MaximumLength(250).WithMessage("Category Description is too long.");
        }
    }
}
