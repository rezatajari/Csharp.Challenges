using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repositories
{
    public class FinanceRepository(FinanceDbContext context, ILogger<FinanceRepository> logger) : BaseRepository<BaseAccount>(context, logger), IFinanceRepository
    {
        public async Task<BaseAccount?> GetAccountWithTransactionsAsync(int id,CancellationToken ct)
        {
            logger.LogDebug("Querying database for Account {AccountId} with Transactions included", id);
            return await _dbSet
                .Include(a=>a.Transactions)
                .FirstOrDefaultAsync(a => a.Id == id,ct);
        }
    }
}
