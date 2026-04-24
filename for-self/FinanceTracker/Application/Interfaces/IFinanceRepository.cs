using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface IFinanceRepository:IBaseRepository<BaseAccount>
    {
        Task<BaseAccount?> GetAccountWithTransactionsAsync(int id);
    }
}
