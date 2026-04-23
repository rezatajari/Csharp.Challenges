using Domain.Entities;
using Domain.ValueObjects;

namespace Application.Dtos
{
   public record class InputTxDto(
       int accountId,
       Money amount,
       Category category,
       TransactionType transactionType,
       string? description);
}
