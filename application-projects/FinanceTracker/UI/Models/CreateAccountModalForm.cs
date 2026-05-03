using Domain.Entities;
using Domain.ValueObjects;

namespace UI.Models
{
    public class CreateAccountModalForm
    {
        public string Name { get; set; } = "";
        public decimal Amount { get; set; }
        public Currency Currency { get; set; } = Currency.USD;
        public AccountType Type { get; set; }
        public decimal CreditLimitAmount { get; set; }
    }
}
