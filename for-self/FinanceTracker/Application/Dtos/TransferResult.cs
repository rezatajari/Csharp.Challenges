using Domain.Entities;

namespace Application.Dtos
{
    public record TransferResult(Transaction sourceTx,Transaction destTx);
}