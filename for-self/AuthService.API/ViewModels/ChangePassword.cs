namespace AuthService.API.ViewModels
{
    public record ChangePassword(string Email, string OldPassword, string NewPassword);
}
