using Domain.ValueObjects;

namespace Application.Dtos
{
   public record class InputTxDto(
       int accountId,
       Money amount,
       Category category,
       string? description);
}
