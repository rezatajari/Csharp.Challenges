using Domain.Entities;
using Domain.ValueObjects;

namespace Application.Dtos.Requests
{
    public record CreateAccountRequest(
        string Name,
        Money Balance, 
        AccountType Type,
        Money CreditLimit
        );
}
