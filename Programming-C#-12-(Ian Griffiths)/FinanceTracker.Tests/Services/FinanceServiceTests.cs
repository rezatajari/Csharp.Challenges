using FinanceTracker.Data;
using FinanceTracker.Entities;
using FinanceTracker.Interfaces;
using FinanceTracker.Services;
using FinanceTracker.ValueObjects;
using Moq;

namespace FinanceTracker.Tests.Services
{
    public class FinanceServiceTests
    {
        private readonly Mock<Repository<IAccount>> _mockAccountRepo;
        private readonly FinanceService _service;

        public FinanceServiceTests()
        {
            _mockAccountRepo = new Mock<Repository<IAccount>>();

            _service=new FinanceService(_mockAccountRepo.Object, new Repository<Transaction>());
        }

        [Fact]
        public void CreateAccount_Should_AddAccountToRepository()
        {
            var account=Account.Create("Travel Fund",Money.Create(500,Currency.USD),TypeName.Bank);
            _service.OpenAccount(account, Money.Create(500, Currency.USD));

            _mockAccountRepo.Verify(repo => repo.Add(account), Times.Once());
        }

        [Fact]
        public void Transfer_Should_UpdateBothBalances_WhenFundsAreSufficient()
        {
            var acc1 = Account.Create("From Account", Money.Create(200, Currency.USD), TypeName.Bank);
            _service.OpenAccount(acc1, Money.Default());
            var acc2 = Account.Create("To Account", Money.Default(), TypeName.Bank);
            _service.OpenAccount(acc2, Money.Default());

            _service.ExecuteTransfer(acc1.Id, acc2.Id, Money.Create(50, Currency.USD));

            Assert.Equal(Money.Create(150, Currency.USD), acc1.Balance);
            Assert.Equal(Money.Create(50, Currency.USD), acc2.Balance);
        }

        [Fact]
        public void Transfer_Should_ThrowException_WhenSenderHasInsufficientFunds()
        {
            var acc1 = Account.Create("From Account", Money.Create(10, Currency.USD), TypeName.Bank);
            _service.OpenAccount(acc1, Money.Default());
            var acc2 = Account.Create("To Account", Money.Default(), TypeName.Bank);
            _service.OpenAccount(acc2, Money.Default());

            var result = _service.ExecuteTransfer(acc1.Id, acc2.Id, Money.Create(100, Currency.USD));

            Assert.False(result.IsSuccess);
            Assert.Contains("Insufficient", result.ErrorMessage);
        }

        [Fact]
        public void GetTotalBalance_Should_SumAllAccounts_InSpecificCurrency()
        {
            var acc1 = Account.Create("Acc 1", Money.Create(100, Currency.USD), TypeName.Bank);
            _service.OpenAccount(acc1, Money.Default());
            var acc2 = Account.Create("Acc 2", Money.Create(100, Currency.USD), TypeName.Bank);
            _service.OpenAccount(acc2, Money.Default());
            var acc3 = Account.Create("Acc 3", Money.Create(100, Currency.USD), TypeName.Bank);
            _service.OpenAccount(acc3, Money.Default());

            var result =_service.GetTotalNetWorth(Currency.USD);

            Assert.Equal(300, result.Value?.Amount);

        }
    }
}
