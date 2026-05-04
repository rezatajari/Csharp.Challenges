using Domain.Entities;
using Domain.ValueObjects;
using System.Reflection.Metadata.Ecma335;

namespace Application.Dtos.Requests
{
        public record AddTransaction(
            int accountId,
            int targetAccountId,
            Money amount,
            Category category,
            TransactionType type,
            string? des);
}
