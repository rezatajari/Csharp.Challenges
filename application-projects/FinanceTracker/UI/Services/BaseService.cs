using Blazored.LocalStorage;
using Microsoft.JSInterop;
using System.Net.Http.Json;

namespace UI.Services
{
    public class BaseService
    {
        protected readonly HttpClient _client;
        protected readonly ILocalStorageService _localStorage;
        protected BaseService(HttpClient client,ILocalStorageService localStorage)
        {
            _client = client;
            _localStorage = localStorage;
        }
        protected async Task<string> GetErrorResponse(HttpResponseMessage response)
        {
            CustomProblemDetails? problemDetails = await response.Content.ReadFromJsonAsync<CustomProblemDetails>();
            return problemDetails?.detail ?? "Unknow error";
        }
    }
}
