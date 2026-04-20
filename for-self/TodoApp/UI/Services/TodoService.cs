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

        public async Task<ApiResponse<ResponseTodoItemDto>> CreateTodoAsync(CreateTodoDto todoModel)
        {
            var result = await _client.PostAsJsonAsync("api/todos/create", todoModel);
            var content = await result.Content.ReadFromJsonAsync<ApiResponse<ResponseTodoItemDto>>();
            if (content == null)
                throw new Exception("Failed to read response content.");

            return content;
        }

        public async Task<ApiResponse<bool>> DeleteTodoAsync(int id)
        {
            var result = await _client.DeleteAsync($"api/todos/{id}");
            var content = await result.Content.ReadFromJsonAsync<ApiResponse<bool>>();
            if (content == null)
                throw new Exception("Failed to read response content.");

            return content;
        }

        public async Task<ApiResponse<ResponseTodoItemDto>> GetTodoByIdAsync(int id)
        {
            var result = await _client.GetFromJsonAsync<ApiResponse<ResponseTodoItemDto>>($"api/todos/{id}");
            if (result == null)
                throw new Exception("Failed to read response content.");

            return result;
        }

        public async Task<ApiResponse<IEnumerable<ResponseTodoItemDto>>> GetAllAsync()
        {
            var result = await _client.GetFromJsonAsync<ApiResponse<IEnumerable<ResponseTodoItemDto>>>("api/todos/get-all");
            if (result == null)
                throw new Exception("Failed to read response content.");

            return result;
        }
    }
}
