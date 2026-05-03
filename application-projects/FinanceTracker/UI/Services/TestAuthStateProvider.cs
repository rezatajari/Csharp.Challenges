using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace UI.Services
{
    public class TestAuthStateProvider(ILocalStorageService localStorage) : AuthenticationStateProvider
    {
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await localStorage.GetItemAsync<string>("authToken");
            if (string.IsNullOrEmpty(token))
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));

            var identity = new ClaimsIdentity([new Claim(ClaimTypes.Name, "User")], "jwt");

            var user = new ClaimsPrincipal(identity);

            return new AuthenticationState(user);
        }
    }
}
