using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.IRepositories
{
    public interface IFinanceRepository:IBaseRepository<BaseAccount>
    {
        Task<BaseAccount?> GetAccountWithTransactionsAsync(int id, CancellationToken ct);
        Task<List<BaseAccount>> GetAccountsByIdAsync(int id,CancellationToken ct);
    }
}
