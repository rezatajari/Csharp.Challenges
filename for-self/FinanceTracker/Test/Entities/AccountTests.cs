using Domain.Entities;
using Domain.Exceptions;
using Domain.ValueObjects;

namespace Test.Entities
{
    public class AccountTests
    {
        [Fact]
        public void Account_Should_SetInitialBalance_WhenCreated()
        {
            // Arrange
            var initialAmount = Money.Create(100, Currency.USD);

            // Act
            var account = SavingsAccount.Create("My Savings", initialAmount, AccountType.Bank);

            // Assert
            Assert.Equal(100, account.Balance.Amount);
        }

        [Fact]
        public void Deposit_Should_IncreaseBalance_WhenAmountIsPositive()
        {
            var initialAmount = Money.Create(100, Currency.USD);
            var depositAmount = Money.Create(50, Currency.USD);
            var account = SavingsAccount.Create("My Savings", initialAmount, AccountType.Bank);

            account.Deposit(depositAmount, Category.Create("Income", null, TransactionType.Income), null, DateTime.Now);

            Assert.Equal(150, account.Balance.Amount);
        }

        [Fact]
        public void Withdraw_Should_DecreaseBalance_WhenFundsAreSufficient()
        {
            var account = SavingsAccount.Create("My Savings", Money.Create(200, Currency.USD), AccountType.Bank);

            account.Withdraw(Money.Create(80, Currency.USD),DateTime.Now);

            Assert.Equal(120, account.Balance.Amount);
        }

        [Fact]
        public void Withdraw_Should_ThrowException_WhenBalanceIsTooLow()
        {
            var account = SavingsAccount.Create("My Savings", Money.Create(50, Currency.USD), AccountType.Bank);

            Assert.Throws<InsufficientFundsException>(() => account.Withdraw(Money.Create(100, Currency.USD),DateTime.Now));
        }

        [Fact]
        public void Constructor_Should_ThrowArgumentException_WhenInitialBalanceIsNegative()
            => Assert.Throws<ArgumentException>(()
                => SavingsAccount.Create("My Savings", Money.Create(-100, Currency.USD), AccountType.Bank));

        [Fact]
        public void TransferTo_Should_ThrowInvalidOperation_WhenSourceAndDestinationAreSame()
        {
            var account = SavingsAccount.Create("My Savings", Money.Create(100, Currency.USD), AccountType.Bank);
            Assert.Throws<InvalidOperationException>(()
                => account.TransferTo(account, Money.Create(50, Currency.USD), DateTime.Now));
        }

        [Fact]
        public void GetBalanceAtDate_Should_ReturnInitialBalance_WhenNoTransactionsExist()
        {
            var account=SavingsAccount.Create("My Savings", Money.Create(100, Currency.USD), AccountType.Bank);
            var result=account.GetBalanceAtDate(DateTime.Now);

            Assert.Equal(100, result.Amount);
        }

        [Fact]
        public void GetBalanceAtDate_Should_IgnoreFutureTransactions_WhenDateIsPast()
        {
            var account=SavingsAccount.Create("My Savings",Money.Create(100,Currency.USD),AccountType.Bank);

            var now = DateTime.Now;
            var tommorow = now.AddDays(1);

            account.Deposit(Money.Create(50, Currency.USD),tommorow);

            Assert.Equal(100, account.GetBalanceAtDate(now).Amount);
        }

        [Fact]
        public void GetBalanceAtDate_Should_ReturnZero_WhenDateIsBeforeAccountCreation()
        {
            var account = SavingsAccount.Create("My Savings", Money.Create(100, Currency.USD), AccountType.Bank);

            var now = DateTime.Now;
            var yesterday = now.AddDays(-1);

            Assert.Equal(Money.Default(), account.GetBalanceAtDate(yesterday));
        }

        [Fact]
        public void GetTotalSpendingByCategory_Should_OnlySumExpenses_AndIgnoreIncome()
        {
            SavingsAccount account = SavingsAccount.Create("My Savings", Money.Default(), AccountType.Bank);

            DateTime now = DateTime.Now;
            Money depositAmount = Money.Create(500, Currency.USD);
            Category incomeCategory = Category.Create("Food", null, TransactionType.Income);
            account.Deposit(depositAmount,incomeCategory,null,now);

            Money withdrawAmount = Money.Create(100, Currency.USD);
            Category withdrawCategory = Category.Create("Food", null, TransactionType.Expense);
            account.Withdraw(withdrawAmount, withdrawCategory, null, now);

            Assert.Equal(100, account.GetTotalSpendingByCategory(withdrawCategory));
        }

        [Fact]
        public void GetSpendingSummary_Should_GroupMultipleTransactions_ByCommonCategoryName()
        {
            SavingsAccount account = SavingsAccount.Create("My Savings", Money.Create(100,Currency.USD), AccountType.Bank);
            DateTime now = DateTime.Now;

            Money coffee1 = Money.Create(5, Currency.USD);
            Money coffee2= Money.Create(5, Currency.USD);
            Category coffee = Category.Create("coffee", null, TransactionType.Expense);

            account.Withdraw(coffee1, coffee, null, now);
            account.Withdraw(coffee2, coffee, null, now);

            var spendingCategories= account.GetSpendingSummoryByCategory();
            var result = spendingCategories.FirstOrDefault(c => c.CategoryName == "coffee");

            Assert.Equal(10, result?.TotalAmount);
        }

        [Fact]
        public void Indexer_Should_ReturnCorrectTransaction_ByIntegerIndex()
        {
            SavingsAccount account = SavingsAccount.Create("My Savings", Money.Create(100, Currency.USD), AccountType.Bank);
            var depositAmount = Money.Create(50, Currency.USD);
            DateTime now = DateTime.Now;
             account.Deposit(depositAmount,now);

            var tx = account[0];

            Assert.NotNull(tx);
            Assert.Equal(50, tx.Amount.Amount);
        }

        [Fact]
        public void Indexer_Should_ReturnCorrectTransaction_ByGuid()
        {
            SavingsAccount account = SavingsAccount.Create("My Savings", Money.Create(100, Currency.USD), AccountType.Bank);
            var depositAmount = Money.Create(50, Currency.USD);
            DateTime now = DateTime.Now;
            var createdTx = account.Deposit(depositAmount, now);

            var fountTx = account[createdTx.Id];

            Assert.NotNull(fountTx);
            Assert.Equal(createdTx.Id, fountTx.Id);
            Assert.Equal(50,fountTx.Amount.Amount);
        }
    }
}

