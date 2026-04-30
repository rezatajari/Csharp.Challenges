using Domain.Entities;
using Domain.ValueObjects;

namespace Application.Dtos.Requests
{
   public record InputTxRequest(
       int accountId,
       int targetAccountId,
       Money amount,
       Category category,
       TransactionType transactionType,
       string? description);
}
