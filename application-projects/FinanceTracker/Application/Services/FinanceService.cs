using Domain.Entities;
using Application.Interfaces;
using Microsoft.Extensions.Logging;
using Application.Dtos.Reponses;
using Application.Dtos.Requests;
using Application.Shared;
using Application.Interfaces.IRepositories;

namespace Application.Services
{
    public class FinanceService(IFinanceRepository financeRepo, ILogger<FinanceService> logger) : IFinanceService
    {
        public async Task<Result<bool>> OpenAccount(CreateAccountRequest createAccDto, CancellationToken ct)
        {
            logger.LogInformation("Attempting to open a new account of type {AccountType} with name {AccountName}", createAccDto.Type, createAccDto.Name);

            BaseAccount? newAccount = null;

            if (createAccDto.Type == AccountType.Savings)
            {
                newAccount = SavingsAccount.Create(createAccDto.UserId, createAccDto.Name, createAccDto.Balance, createAccDto.Type);
            }
            else if (createAccDto.Type == AccountType.CreditCard)
            {
                newAccount = CreditCardAccount.Create(createAccDto.UserId, createAccDto.Name, createAccDto.Balance, createAccDto.CreditLimit, createAccDto.Type);
            }

            if (newAccount == null)
            {
                logger.LogWarning("Account opening failed: Unsupported account type {AccountType}", createAccDto.Type);
                return Result<bool>.Failure("The type of account is not exist");
            }

            await financeRepo.AddAsync(newAccount, ct);
            var success = await financeRepo.SaveChangesAsync(ct) > 0;

            if (!success)
            {
                logger.LogError("Database failure: Could not save new account {AccountName} to the database", createAccDto.Name);
                return Result<bool>.Failure("Failed to open account.");
            }

            logger.LogInformation("Successfully opened new {AccountType} account for {AccountName}", createAccDto.Type, createAccDto.Name);

            return Result<bool>.Success(true);
        }

        public async Task<Result<List<AccountResponse>>?> GetAccounts(CancellationToken ct)
        {
            logger.LogInformation("Retrieving all accounts from the database");

            var accounts = await financeRepo.GetAllAsync(ct);

            try
            {
                var accountDtos = accounts.Select(acc => acc switch
                {
                    SavingsAccount s => new AccountResponse(
                        s.Id,
                        s.Name,
                        s.Balance,
                        AccountType.Savings),

                    CreditCardAccount c => new AccountResponse(
                        c.Id,
                        c.Name,
                        c.Balance,
                        AccountType.CreditCard,
                        c.CreditLimit),

                    _ => throw new NotSupportedException($"Unknown account type: {acc.GetType()}")
                }).ToList();

                logger.LogInformation("Successfully retrieved and mapped {Count} accounts", accountDtos.Count);

                return Result<List<AccountResponse>>.Success(accountDtos);
            }
            catch (NotSupportedException ex)
            {
                logger.LogError(ex, "Mapping failure: One or more accounts in the database have an unsupported type");
                throw;
            }
        }

        public async Task<Result<AccountResponse>> GetAccount(int Id, CancellationToken ct)
        {
            logger.LogInformation("Fetching account details for AccountId: {AccountId}", Id);

            var accountResult = await financeRepo.GetByIdAsync(Id, ct);

            if (accountResult == null)
            {
                logger.LogWarning("Account lookup failed: AccountId {AccountId} does not exist", Id);
                return Result<AccountResponse>.Failure("Your account is not exist");
            }

            try
            {
                var account = accountResult switch
                {
                    SavingsAccount s => new AccountResponse(Id, s.Name, s.Balance, AccountType.Savings),
                    CreditCardAccount c => new AccountResponse(Id, c.Name, c.Balance, AccountType.CreditCard, c.CreditLimit),
                    _ => throw new NotSupportedException($"Unknown account type: {accountResult.GetType()}")
                };

                logger.LogInformation("Successfully retrieved account details for AccountId: {AccountId}", Id);
                return Result<AccountResponse>.Success(account);
            }
            catch (NotSupportedException ex)
            {
                logger.LogError(ex, "Mapping error for AccountId {AccountId}: Unsupported type encountered", Id);
                throw;
            }
        }

        public async Task<Result<List<TransactionResponse>>> GetAccountTransactions(int Id, CancellationToken ct)
        {
            logger.LogInformation("Retrieving transactions for AccountId: {AccountId}", Id);

            var account = await financeRepo.GetAccountWithTransactionsAsync(Id, ct);

            if (account == null)
            {
                logger.LogWarning("Transaction lookup failed: AccountId {AccountId} does not exist", Id);
                return Result<List<TransactionResponse>>.Failure("Account is not exist");
            }

            if (!account.Transactions.Any())
            {
                logger.LogInformation("No transactions found for AccountId: {AccountId}", Id);
                return Result<List<TransactionResponse>>.Failure("You don't have any transaction");
            }

            var tx = account.Transactions.Select(tx =>
                new TransactionResponse(tx.Amount, tx.Category, tx.Description,
                    tx.Type, tx.CreatedAt)).ToList();

            logger.LogInformation("Successfully mapped {Count} transactions for AccountId: {AccountId}", tx.Count, Id);

            return Result<List<TransactionResponse>>.Success(tx);
        }

        public async Task<Result<bool>> AddTransaction(InputTxRequest txDto, CancellationToken ct)
        {
            logger.LogInformation("Processing {TransactionType} for AccountId: {AccountId}. Amount: {Amount}",
                txDto.transactionType, txDto.accountId, txDto.amount);

            var account = await financeRepo.GetByIdAsync(txDto.accountId, ct);
            if (account == null)
            {
                logger.LogWarning("Transaction failed: Source AccountId {AccountId} does not exist", txDto.accountId);
                return Result<bool>.Failure("Your account is not exist");
            }

            if (txDto.transactionType == TransactionType.Expense)
            {
                account.Withdraw(txDto.amount, txDto.transactionType, txDto.category,
                    txDto.description, DateTime.UtcNow);
            }
            else if (txDto.transactionType == TransactionType.Income)
            {
                account.Deposit(txDto.amount, txDto.transactionType, txDto.category,
                    txDto.description, DateTime.UtcNow);
            }
            else
            {
                var toAccount = await financeRepo.GetByIdAsync(txDto.targetAccountId, ct);

                if (toAccount == null)
                {
                    logger.LogWarning("Transfer failed: Target AccountId {TargetAccountId} does not exist", txDto.targetAccountId);
                    return Result<bool>.Failure("Target account does not exist.");
                }

                if (account.Id == toAccount.Id)
                {
                    logger.LogWarning("Transfer rejected: Source and Target AccountId are the same ({AccountId})", account.Id);
                    return Result<bool>.Failure("Cannot transfer to the same account.");
                }

                DateTime now = DateTime.UtcNow;
                account.TransferTo(txDto.amount, txDto.transactionType, txDto.category,
                    txDto.description, now, toAccount);

                logger.LogInformation("Transfer initialized from {SourceId} to {TargetId}", account.Id, toAccount.Id);
            }

            var result = await financeRepo.SaveChangesAsync(ct) > 0;

            if (!result)
            {
                logger.LogError("Database failure: Failed to persist {TransactionType} for AccountId {AccountId}",
                    txDto.transactionType, txDto.accountId);
                return Result<bool>.Failure("Failed to record transaction.");
            }

            logger.LogInformation("Successfully completed {TransactionType} for AccountId: {AccountId}",
                txDto.transactionType, txDto.accountId);

            return Result<bool>.Success(true);
        }
    }
}
