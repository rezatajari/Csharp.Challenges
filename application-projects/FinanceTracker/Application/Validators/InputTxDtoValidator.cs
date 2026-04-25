using Application.Dtos;
using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Validators
{
    public class InputTxDtoValidator : AbstractValidator<InputTxDto>
    {
        public InputTxDtoValidator()
        {
            RuleFor(x => x.accountId)
                .NotEmpty().WithMessage("Source account is required.");

            RuleFor(x => x.amount.Amount)
                .GreaterThan(0).WithMessage("Transaction amount must be greater than zero.");

            RuleFor(x => x.amount.Currency)
                .IsInEnum().WithMessage("Invalid currency.");

            RuleFor(x => x.transactionType)
                .IsInEnum().WithMessage("Invalid transaction type.");

            RuleFor(x => x.targetAccountId)
                .NotEmpty()
                .NotEqual(x => x.accountId).WithMessage("Cannot transfer money to the same account.")
                .When(x => x.transactionType == TransactionType.Transfer)
                .WithMessage("A valid target account is required for transfers.");

            RuleFor(x => x.description)
                .MaximumLength(250).WithMessage("Description is too long.");
        }
    }
}
