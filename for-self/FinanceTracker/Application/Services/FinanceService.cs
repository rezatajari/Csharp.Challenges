using Domain.Entities;
using Application.Dtos;
using Application.Interfaces;
using Domain.Shared;
using Domain.ValueObjects;

namespace Application.Services
{
    public class FinanceService : IFinanceService
    {

        private readonly IBaseRepository<BaseAccount> _accountRepo;

        public FinanceService(IBaseRepository<BaseAccount> accountRepo)
        {
            _accountRepo = accountRepo;
        }

        public async Task<Result<bool>> OpenAccount(CreateAccountDto createAccDto)
        {
            BaseAccount? newAccount = null;

            if (createAccDto.Type == AccountType.Savings)
            {
                newAccount = SavingsAccount.Create(createAccDto.Name, createAccDto.Balance,createAccDto.Type);
            }
            else if (createAccDto.Type == AccountType.CreditCard)
            {
                newAccount = CreditCardAccount.Create(createAccDto.Name, createAccDto.Balance, createAccDto.CreditLimit,createAccDto.Type);
            }

            if (newAccount == null)
                return Result<bool>.Failure("The type of account is not exist");

            await _accountRepo.AddAsync(newAccount);
            var success = await _accountRepo.SaveChangesAsync() > 0;

            return (success)
                ? Result<bool>.Success(true)
                : Result<bool>.Failure("Failed to open account.");
        }

        public async Task<Result<bool>> RecordIncome(InputRecordTxDto IncomeTxDto)
        {
            var account = await _accountRepo.GetByIdAsync(IncomeTxDto.accountId);
            if (account == null)
                return Result<bool>.Failure("Account not found.");

            account.Deposit(IncomeTxDto.amount, IncomeTxDto.category,
                IncomeTxDto.description, DateTime.UtcNow);

            return (await _accountRepo.SaveChangesAsync() > 0)
                ? Result<bool>.Success(true)
                : Result<bool>.Failure("Failed to record income.");
        }

        public async Task<Result<bool>> RecordExpense(InputRecordTxDto ExpenseTxDto)
        {
            throw new NotImplementedException();
        }

        public Task<Result<bool>> TransferFunds(int fromId, int toId, Money amount)
        {
            throw new NotImplementedException();
        }

        public Task<Result<List<BaseAccount>>> GetAccounts()
        {
        }
    }
}
