using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;

namespace UI.Services
{
    public class BaseService
    {
        protected async Task<string> GetErrorResponse(HttpResponseMessage response)
        {
            ProblemDetails? problemDetails = await response.Content.ReadFromJsonAsync<ProblemDetails>();
            return problemDetails?.Detail ?? "Unknow error";
        }
    }
}
