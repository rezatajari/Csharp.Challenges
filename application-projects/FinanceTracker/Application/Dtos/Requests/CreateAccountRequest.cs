using Domain.Entities;
using Domain.ValueObjects;

namespace Application.Dtos.Requests
{
    public class CreateAccountRequest
    {
        public string Name { get; set; }
        public Money Balance { get; set; }
        public AccountType Type { get; set; }
        public Money CreditLimit { get; set; }
    }
}
