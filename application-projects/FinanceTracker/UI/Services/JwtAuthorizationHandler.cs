using Blazored.LocalStorage;
using Microsoft.JSInterop;
using System.Runtime.InteropServices;

namespace UI.Services
{
    public class JwtAuthorizationHandler(ILocalStorageService localStorage):DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token= await localStorage.GetItemAsync<string>("authToken");
            if (!string.IsNullOrEmpty(token))
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
