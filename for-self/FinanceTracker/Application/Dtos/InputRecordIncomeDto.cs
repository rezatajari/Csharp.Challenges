using FinanceTracker.ValueObjects;

namespace Application.Dtos
{
   public record class InputRecordTxDto(int accountId,Money amount,Category category,string? description);
}
