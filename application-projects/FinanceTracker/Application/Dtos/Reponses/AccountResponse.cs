using Domain.Entities;
using Domain.ValueObjects;

namespace Application.Dtos.Reponses
{
    public record AccountResponse(
        int Id,
        string Name,
        Money Balance,
        AccountType Type,
        Money? CreditLimit = null
        );
}
