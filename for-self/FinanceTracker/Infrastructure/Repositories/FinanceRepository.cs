using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class FinanceRepository : BaseRepository<BaseAccount>, IFinanceRepository
    {
        public FinanceRepository(FinanceDbContext context) : base(context) { }
        public async Task<BaseAccount?> GetAccountWithTransactionsAsync(int id)
        {
            return await _dbSet.Include(a=>a.Transactions).FirstOrDefaultAsync(a => a.Id == id);
        }
    }
}
