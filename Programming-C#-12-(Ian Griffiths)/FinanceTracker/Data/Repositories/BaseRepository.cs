using FinanceTracker.Entities;
using FinanceTracker.Interfaces;

namespace FinanceTracker.Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
    }
}
