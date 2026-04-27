using Domain.Entities;

namespace Application.Interfaces.IRepositories
{
    public interface IAuthRepository : IBaseRepository<User>
    {
        Task<User?> GetByEmailAsync(string email, CancellationToken ct);
    }
}
