using Domain.Entities;

namespace FinanceTracker.Dtos
{
    public record TransferResult(Transaction sourceTx,Transaction destTx);
}