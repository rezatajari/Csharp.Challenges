using Domain.Entities;
using Domain.ValueObjects;

namespace Application.Dtos.Reponses
{
    public record DashboardResponse(List<DashboardAccounts> Accounts);
    public record DashboardAccounts(string AccountName,AccountType Type, Money Balance);
}
