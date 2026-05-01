using Microsoft.AspNetCore.Http;
using Microsoft.JSInterop;
using System.Net.Http.Json;

namespace UI.Services
{
    public class BaseService
    {
        protected readonly HttpClient _client;
        private readonly IJSRuntime _jsRuntime;
        protected BaseService(HttpClient client,IJSRuntime jsRuntime)
        {
            _client = client;
            _jsRuntime = jsRuntime;
        }
        protected async Task<string> GetErrorResponse(HttpResponseMessage response)
        {
            CustomProblemDetails? problemDetails = await response.Content.ReadFromJsonAsync<CustomProblemDetails>();
            return problemDetails?.detail ?? "Unknow error";
        }
    }
}
