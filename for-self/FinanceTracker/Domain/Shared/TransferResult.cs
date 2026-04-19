using Domain.Entities;

namespace Domain.Shared
{
    public record TransferResult(Transaction sourceTx,Transaction destTx);
}