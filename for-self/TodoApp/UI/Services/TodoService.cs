using Application.DTOs;
using System.Net.Http.Json;

namespace UI.Services
{
    public class TodoService
    {
        private readonly HttpClient _client;
        public TodoService(HttpClient client)
        {
            _client= client;
        }

        public async Task CreateTodoAsync(CreateTodoDto todoModel)
        {
            await _client.PostAsJsonAsync("api/todos/create", todoModel);
        }
    }
}
