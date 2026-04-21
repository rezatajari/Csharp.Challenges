namespace UI.Services
{
    public class AccountService
    {
        private readonly HttpClient _client;
        public AccountService(HttpClient client)
        {
            _client = client;
        }
    }
}
