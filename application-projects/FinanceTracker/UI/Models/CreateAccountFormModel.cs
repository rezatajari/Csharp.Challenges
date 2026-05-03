using Domain.Entities;
using Domain.ValueObjects;

namespace UI.Models
{
    public class CreateAccountFormModel
    {
        public string Name { get; set; } = string.Empty;

        public decimal InitialBalance { get; set; }
        public Currency Currency { get; set; } = Currency.USD;

        public AccountType Type { get; set; }

        public decimal CreditLimitAmount { get; set; }
    }
}
