using Application.Interfaces.IRepositories;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repositories
{
    public class AuthRepository(FinanceDbContext context, ILogger<AuthRepository> logger) : BaseRepository<User>(context, logger), IAuthRepository
    {
        public async Task<User?> GetByEmailAsync(string email, CancellationToken ct)
            => await _dbSet
                .FirstOrDefaultAsync(u => u.Email == email, ct);
    }
}
