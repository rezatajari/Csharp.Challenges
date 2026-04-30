using Microsoft.AspNetCore.Http;
using System.Net.Http.Json;

namespace UI.Services
{
    public class BaseService
    {
        protected readonly HttpClient _client;
        protected BaseService(HttpClient client)
        {
            _client = client;
        }
        protected async Task<string> GetErrorResponse(HttpResponseMessage response)
        {
            CustomProblemDetails? problemDetails = await response.Content.ReadFromJsonAsync<CustomProblemDetails>();
            return problemDetails?.detail ?? "Unknow error";
        }
    }
}
