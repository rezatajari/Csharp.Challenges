namespace AuthService.API.Models
{
    public class User
    {
        private User(string username,string password)
        {
            Username=username;
            Password=password;
        }

        public string Username { get; private set; }
        public string Password { get; private set; }


        public static User Create(string username,string password)
        {
            return new User(username,password);
        }
    }
}
