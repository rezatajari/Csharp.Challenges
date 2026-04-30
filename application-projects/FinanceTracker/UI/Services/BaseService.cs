using Microsoft.AspNetCore.Http;
using System.Net.Http.Json;

namespace UI.Services
{
    public class BaseService
    {
        protected async Task<string> GetErrorResponse(HttpResponseMessage response)
        {
            CustomProblemDetails? problemDetails = await response.Content.ReadFromJsonAsync<CustomProblemDetails>();
            return problemDetails?.detail ?? "Unknow error";
        }
    }
}
