using FinanceTracker.Data;
using FinanceTracker.Entities;
using FinanceTracker.Interfaces;

namespace FinanceTracker.Services
{
    public class FinanceService
    {
        private readonly Repository<IAccount> _accountRepo;
        private readonly Repository<Transaction> _transactionRepo;

        public FinanceService(
            Repository<IAccount> accountRepo,
            Repository<Transaction> transactionRepo
            )
        {
            _accountRepo = accountRepo;
            _transactionRepo = transactionRepo;
        }
    }
}
