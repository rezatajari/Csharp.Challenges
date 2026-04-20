using Application.DTOs;

namespace UI.Services
{
    public class TodoService
    {
        private readonly HttpClient _client;
        public TodoService(HttpClient client)
        {
            _client= client;
        }

        public async Task CreateTodo(CreateTodoDto todoModel)
        {

        }
    }
}
