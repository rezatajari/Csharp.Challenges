using FinanceTracker.ValueObjects;

namespace FinanceTracker.Dtos
{
   public record class InputRecordTxDto(int accountId,Money amount,Category category,string? description);
}
