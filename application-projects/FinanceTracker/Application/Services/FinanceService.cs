using Domain.Entities;
using Application.Dtos;
using Application.Interfaces;
using Domain.Shared;
using Domain.ValueObjects;
using Microsoft.Win32.SafeHandles;

namespace Application.Services
{
    public class FinanceService : IFinanceService
    {

        private readonly IFinanceRepository _financeRepo;

        public FinanceService(IFinanceRepository financeRepo)
        {
            _financeRepo = financeRepo;
        }

        public async Task<Result<bool>> OpenAccount(CreateAccountDto createAccDto, CancellationToken ct)
        {
            BaseAccount? newAccount = null;

            if (createAccDto.Type == AccountType.Savings)
            {
                newAccount = SavingsAccount.Create(createAccDto.Name, createAccDto.Balance, createAccDto.Type);
            }
            else if (createAccDto.Type == AccountType.CreditCard)
            {
                newAccount = CreditCardAccount.Create(createAccDto.Name, createAccDto.Balance, createAccDto.CreditLimit, createAccDto.Type);
            }

            if (newAccount == null)
                return Result<bool>.Failure("The type of account is not exist");

            await _financeRepo.AddAsync(newAccount,ct);
            var success = await _financeRepo.SaveChangesAsync(ct) > 0;

            return (success)
                ? Result<bool>.Success(true)
                : Result<bool>.Failure("Failed to open account.");
        }

        public async Task<Result<List<AccountDto>>?> GetAccounts(CancellationToken ct)
        {
            var accounts = await _financeRepo.GetAllAsync(ct);

            var accountDtos = accounts.Select(acc => acc switch
            {
                SavingsAccount s => new AccountDto(
                    s.Id,
                    s.Name,
                    s.Balance,
                    AccountType.Savings),

                CreditCardAccount c => new AccountDto(
                    c.Id,
                    c.Name,
                    c.Balance,
                    AccountType.CreditCard,
                    c.CreditLimit),

                _ => throw new NotSupportedException($"Unknown account type: {acc.GetType()}")
            }).ToList();

            return Result<List<AccountDto>>.Success(accountDtos);
        }

        public async Task<Result<AccountDto>> GetAccount(int Id, CancellationToken ct)
        {
            var accountResult = await _financeRepo.GetByIdAsync(Id,ct);
            if (accountResult == null)
                return Result<AccountDto>.Failure("Your account is not exist");

            var account = accountResult switch
            {
                SavingsAccount s => new AccountDto(
                    Id, s.Name, s.Balance, AccountType.Savings),

                CreditCardAccount c => new AccountDto(
                    Id, c.Name, c.Balance, AccountType.CreditCard, c.CreditLimit),

                _ => throw new NotSupportedException($"Unknown account type: {accountResult.GetType()}")
            };

            return Result<AccountDto>.Success(account);
        }

        public async Task<Result<List<TransactionDto>>> GetTransactionById(int Id, CancellationToken ct)
        {
            var account = await _financeRepo.GetAccountWithTransactionsAsync(Id,ct);
            if (account == null || account.Transactions.Count() == 0)
                return Result<List<TransactionDto>>.Failure("Account is not exist or you have don't have any transaction");

            var tx = account.Transactions.Select(tx =>
            new TransactionDto(tx.Amount, tx.Category, tx.Description,
                tx.Type, tx.CreatedAt)).ToList();

            return Result<List<TransactionDto>>.Success(tx);
        }

        public async Task<Result<bool>> AddTransaction(InputTxDto txDto, CancellationToken ct)
        {
            var account = await _financeRepo.GetByIdAsync(txDto.accountId,ct);
            if (account == null)
                return Result<bool>.Failure("Your account is not exist");

            if (txDto.transactionType == TransactionType.Expense)
            {
                account.Withdraw(txDto.amount,txDto.transactionType, txDto.category,
                    txDto.description, DateTime.UtcNow);
            }
            else if (txDto.transactionType==TransactionType.Income) 
            {
                account.Deposit(txDto.amount,txDto.transactionType, txDto.category,
                    txDto.description, DateTime.UtcNow);
            }
            else
            {
                var toAccount = await _financeRepo.GetByIdAsync(txDto.targetAccountId,ct);
                if (account.Id == toAccount.Id)
                    return Result<bool>.Failure("Cannot transfer to the same account.");
                DateTime now= DateTime.UtcNow;

                account.TransferTo(txDto.amount, txDto.transactionType, txDto.category, 
                    txDto.description, now, toAccount);
            }

            var result = await _financeRepo.SaveChangesAsync(ct) > 0;

            return (result)
                ? Result<bool>.Success(true)
                : Result<bool>.Failure("Failed to record income.");
        }
    }
}
