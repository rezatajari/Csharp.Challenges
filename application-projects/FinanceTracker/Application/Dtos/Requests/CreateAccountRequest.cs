using Domain.Entities;
using Domain.ValueObjects;

namespace Application.Dtos.Requests
{
    public record CreateAccountRequest(
        int UserId,
        string Name,
        Money Balance, 
        AccountType Type,
        Money CreditLimit
        );
}
