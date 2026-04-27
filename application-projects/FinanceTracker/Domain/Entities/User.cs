using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class User:BaseEntity
    {
        public string Username { get; private set; }
        public string Email{ get; private set; }
        public string PasswordHash { get; private set; }
        public ICollection<BaseAccount> BaseAccounts { get; private set; } = new List<BaseAccount>();

        private User(string username, string email, string passwordHash)
        {
            Username = username;
            Email = email;
            PasswordHash = passwordHash;
        }

        private User() { }

        public static User Create(string username, string email, string passwordHash)
            => new User(username, email, passwordHash);
    }
}
