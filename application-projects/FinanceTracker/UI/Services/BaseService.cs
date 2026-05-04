using Application.Shared;
using Blazored.LocalStorage;
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

        protected async Task<Result<T>> ToResult<T>(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadFromJsonAsync<T>();
                return Result<T>.Success(data!);
            }

            var error = await GetErrorResponse(response);
            return Result<T>.Failure(error);
        }
    }
}
