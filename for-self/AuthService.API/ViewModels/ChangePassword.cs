namespace AuthService.API.ViewModels
{
    public record ChangePassword
    {
        public ChangePassword(string email, string oldPass, string newPass)
        {
            if (string.IsNullOrWhiteSpace(NewPassword)) throw new ArgumentNullException("password");
            if (NewPassword.Length < 8) throw new ArgumentException("Password must be at least 8 characters long", "password");

            this.Email = email;
            this.OldPassword = oldPass;
            this.NewPassword = NewPassword;
            NewPass = newPass;
        }

        public string Email { get; init; }
        public string OldPassword { get; init; }
        public string NewPassword { get; init; }
        public string NewPass { get; }
    }
}
