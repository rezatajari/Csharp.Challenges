using FinanceTracker.Entities;
using FinanceTracker.Exceptions;
using FinanceTracker.ValueObjects;

namespace FinanceTracker.Tests.Entities
{
    public class AccountTests
    {
        [Fact]
        public void Account_Should_SetInitialBalance_WhenCreated()
        {
            // Arrange
            var initialAmount = Money.Create(100, Currency.USD);

            // Act
            var account = Account.Create("My Savings", initialAmount, TypeName.Bank);

            // Assert
            Assert.Equal(100, account.Balance.Amount);
        }

        [Fact]
        public void Deposit_Should_IncreaseBalance_WhenAmountIsPositive()
        {
            var initialAmount = Money.Create(100, Currency.USD);
            var depositAmount = Money.Create(50, Currency.USD);
            var account = Account.Create("My Savings", initialAmount, TypeName.Bank);

            account.Deposit(depositAmount, Category.Create("Income", null, TransactionType.Income), null, DateTime.Now);

            Assert.Equal(150, account.Balance.Amount);
        }

        [Fact]
        public void Withdraw_Should_DecreaseBalance_WhenFundsAreSufficient()
        {
            var account = Account.Create("My Savings", Money.Create(200, Currency.USD),TypeName.Bank);

            account.Withdraw(Money.Create(80, Currency.USD));

            Assert.Equal(120, account.Balance.Amount);
        }

        [Fact]
        public void Withdraw_Should_ThrowException_WhenBalanceIsTooLow()
        {
            var account = Account.Create("My Savings", Money.Create(50, Currency.USD), TypeName.Bank);

            Assert.Throws<InsufficientFundsException>(() => account.Withdraw(Money.Create(100, Currency.USD)));
        }
    }
}

