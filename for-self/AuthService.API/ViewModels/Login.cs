namespace AuthService.API.ViewModels
{
    public record Login(string? Username, string? Email, string? Password)
    {
        public bool IsValid()
            => (!string.IsNullOrWhiteSpace(Username) || !string.IsNullOrWhiteSpace(Email))
           && !string.IsNullOrWhiteSpace(Password);
}
}
