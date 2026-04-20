using Application.Common;
using Application.DTOs;
using System.Net.Http.Json;

namespace UI.Services
{
    public class TodoService
    {
        private readonly HttpClient _client;
        public TodoService(HttpClient client)
        {
            _client = client;
        }

        public async Task<ReturnResponse<ResponseTodoItemDto>> CreateTodoAsync(CreateTodoDto todoModel)
        {
            var result = await _client.PostAsJsonAsync("api/todos/create", todoModel);
            var content = await result.Content.ReadFromJsonAsync<ReturnResponse<ResponseTodoItemDto>>();
            if (content == null)
                throw new Exception("Failed to read response content.");

            return content;
        }
    }
}
