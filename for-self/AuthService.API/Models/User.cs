namespace AuthService.API.Models
{
    public class User
    {
        public User(string username,string email,string password)
        {
            if (string.IsNullOrWhiteSpace(username)) throw new ArgumentNullException("username");
            if (string.IsNullOrWhiteSpace(email))  throw new ArgumentNullException("email");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentNullException("password");
            this.Username = username;
            this.Email = email;
            this.Password = password;

            Id=Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string Username { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        public bool ChangePassword(string oldPassword,string newPassword)
        {
            if (string.IsNullOrWhiteSpace(oldPassword)) throw new ArgumentNullException("oldPassword");
            if (string.IsNullOrWhiteSpace(newPassword)) throw new ArgumentNullException("newPassword");
            if (this.Password != oldPassword) return false;
            this.Password = newPassword;
            return true;
        }
    }
}
