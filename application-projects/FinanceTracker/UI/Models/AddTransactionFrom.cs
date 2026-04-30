using Domain.Entities;
using Domain.ValueObjects;

namespace UI.Models
{
    public class AddTransactionFrom
    {
        public int AccountId { get; set; }
        public int TargetAccountId { get; set; }
        public decimal Amount { get; set; }
        public Currency Currency { get; set; } = Currency.USD;
        public string? CategoryName { get; set; }
        public string? CategoryDescription { get; set; }
        public TransactionType Type { get; set; }
        public string? TransactionDescription { get; set; }
    }
}
