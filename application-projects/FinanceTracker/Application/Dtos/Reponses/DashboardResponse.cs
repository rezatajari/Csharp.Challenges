using Domain.ValueObjects;

namespace Application.Dtos.Reponses
{
    public record DashboardResponse(List<DashboardAccounts> accounts);
    public record DashboardAccounts(string AccountName,Money Balance);
}
