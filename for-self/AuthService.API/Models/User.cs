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
        }

        public string Username { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
    }
}
