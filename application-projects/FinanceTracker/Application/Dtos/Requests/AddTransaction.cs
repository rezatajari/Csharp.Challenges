using Domain.Entities;
using Domain.ValueObjects;

namespace Application.Dtos.Requests
{
        public record AddTransaction(
            int AccountId,
            int TargetAccountId,
            Money Amount,
            Category Category,
            TransactionType Type,
            string? Description);
}
