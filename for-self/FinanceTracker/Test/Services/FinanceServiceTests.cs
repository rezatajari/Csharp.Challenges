using Domain.Entities;
using Moq;
using Domain.ValueObjects;
using Application.Services;

namespace Test.Services
{
    public class FinanceServiceTests
    {
        private readonly Mock<JsonRepository<BaseAccount>> _mockAccountRepo;
        private readonly FinanceService _service;

        public FinanceServiceTests()
        {
            _mockAccountRepo = new Mock<JsonRepository<BaseAccount>>();

            _service=new FinanceService(_mockAccountRepo.Object, new Repository<Transaction>());
        }

        [Fact]
        public void CreateAccount_Should_AddAccountToRepository()
        {
            var account=SavingsAccount.Create("Travel Fund",Money.Create(500,Currency.USD),TypeName.Bank);
            _service.OpenAccount(account);

            _mockAccountRepo.Verify(repo => repo.Add(account), Times.Once());
        }

        [Fact]
        public void Transfer_Should_UpdateBothBalances_WhenFundsAreSufficient()
        {
            var acc1 = SavingsAccount.Create("From Account", Money.Create(200, Currency.USD), TypeName.Bank);
            _service.OpenAccount(acc1);
            var acc2 = SavingsAccount.Create("To Account", Money.Default(), TypeName.Bank);
            _service.OpenAccount(acc2);

            _service.ExecuteTransfer(acc1.Id, acc2.Id, Money.Create(50, Currency.USD));

            Assert.Equal(Money.Create(150, Currency.USD), acc1.Balance);
            Assert.Equal(Money.Create(50, Currency.USD), acc2.Balance);
        }

        [Fact]
        public void Transfer_Should_ThrowException_WhenSenderHasInsufficientFunds()
        {
            var acc1 = SavingsAccount.Create("From Account", Money.Create(10, Currency.USD), TypeName.Bank);
            _service.OpenAccount(acc1);
            var acc2 = SavingsAccount.Create("To Account", Money.Default(), TypeName.Bank);
            _service.OpenAccount(acc2);

            var result = _service.ExecuteTransfer(acc1.Id, acc2.Id, Money.Create(100, Currency.USD));

            Assert.False(result.IsSuccess);
            Assert.Contains("Insufficient", result.ErrorMessage);
        }

        [Fact]
        public void GetTotalBalance_Should_SumAllAccounts_InSpecificCurrency()
        {
            var acc1 = SavingsAccount.Create("Acc 1", Money.Create(100, Currency.USD), TypeName.Bank);
            _service.OpenAccount(acc1);
            var acc2 = SavingsAccount.Create("Acc 2", Money.Create(100, Currency.USD), TypeName.Bank);
            _service.OpenAccount(acc2);
            var acc3 = SavingsAccount.Create("Acc 3", Money.Create(100, Currency.USD), TypeName.Bank);
            _service.OpenAccount(acc3);

            var result =_service.GetTotalNetWorth(Currency.USD);

            Assert.Equal(300, result.Value?.Amount);

        }
    }
}
