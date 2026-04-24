using Domain.Entities;
using Domain.ValueObjects;

namespace Application.Dtos
{
    public record CreateAccountDto(
        string Name,
        Money Balance, 
        AccountType Type,
        Money CreditLimit
        );
}
