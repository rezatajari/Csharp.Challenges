using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyFoundation
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }

        private User(string firstName, string lastName, string email, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Age = age;
        }


        public User Create(string firstName, string lastName, string email, int age)
        {
            if (string.IsNullOrEmpty(firstName))
            {
                throw new ArgumentException("First name cannot be null or empty.", nameof(firstName));
            }
            if (string.IsNullOrEmpty(lastName))
            {
                throw new ArgumentException("Last name cannot be null or empty.", nameof(lastName));
            }
            if (string.IsNullOrEmpty(email) || !email.Contains("@"))
            {
                throw new ArgumentException("Invalid email address.", nameof(email));
            }
            if (age < 0 || age > 120)
            {
                throw new ArgumentOutOfRangeException(nameof(age), "Age must be between 0 and 120.");
            }
            return new User(firstName, lastName, email, age);
        }
    }
}
