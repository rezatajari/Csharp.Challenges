using FinanceTracker.Data;
using FinanceTracker.Entities;
using FinanceTracker.Interfaces;
using FinanceTracker.ValueObjects;

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

        public Guid OpenAccount(IAccount newAccount, Money initialDeposit)
        {
            _accountRepo.Add(newAccount);

            if (initialDeposit.Amount > 0)
            {
                var depositTx = Transaction.CreateForAccount(
                    initialDeposit,
                    TransactionType.Income,
                    Category.Create("Initial Deposit", null, TransactionType.Income),
                    newAccount,
                    "Opening Balance",
                    DateTime.Now
                    );

                _transactionRepo.Add(depositTx);
            }

            return newAccount.Id;
        }
    }
}
