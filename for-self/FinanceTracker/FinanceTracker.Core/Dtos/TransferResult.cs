using FinanceTracker.Entities;

namespace FinanceTracker.Dtos
{
    public record TransferResult(Transaction sourceTx,Transaction destTx);
}