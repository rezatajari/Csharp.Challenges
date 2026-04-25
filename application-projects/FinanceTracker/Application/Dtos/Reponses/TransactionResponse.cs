using Domain.Entities;
using Domain.ValueObjects;

namespace Application.Dtos.Reponses
{
    public record TransactionResponse(
        Money Amount,
        Category Category,
        string? Description,
        TransactionType Type,
        DateTime CreatedAt);
}
