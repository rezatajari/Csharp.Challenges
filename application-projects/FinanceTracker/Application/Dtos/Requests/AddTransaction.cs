using Domain.Entities;
using Domain.ValueObjects;
using System.Reflection.Metadata.Ecma335;

namespace Application.Dtos.Requests
{
   public class AddTransaction
    {
        public AddTransaction(int accountId,int targetAccountId,
            Money amount,Category category,
            TransactionType type,string? des)
        {
            AccountId= accountId;
            TargetAccountId= targetAccountId;
            Amount= amount;
            Category= category;
            TransactionType= type;
            Description= des;
        }
        public int AccountId{ get; set; }
        public int TargetAccountId{ get; set; }
        public Money Amount{ get; set; }
        public Category Category { get; set; }
        public TransactionType TransactionType { get; set; }
        public string? Description { get; set; }
    }
}
