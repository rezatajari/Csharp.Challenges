using Application.DTOs;
using Application.UseCases.CreateTodo;
using Application.UseCases.DeleteTodo;
using Application.UseCases.GetTodo;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/todos")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly CreateTodoHandler _createTodoHandler;
        private readonly DeleteTodoHandler _deleteTodoHandler;
        private readonly GetTodosHandler _getTodoHandler;

        public TodosController(
            CreateTodoHandler createTodoHandler,
            DeleteTodoHandler deleteTodoHandler,
            GetTodosHandler getTodoHandler
            )
        {
            _createTodoHandler = createTodoHandler;
            _deleteTodoHandler = deleteTodoHandler;
            _getTodoHandler = getTodoHandler;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateTodoDto request)
        {
            var result = await _createTodoHandler.Handle(request);
            return (result.Success) ? Ok(result) : BadRequest(result);
        }


        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _deleteTodoHandler.Handle(id);
            return (result.Success) ? Ok(result) : BadRequest(result);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _getTodoHandler.Handle(id);
            return (result.Success) ? Ok(result) : BadRequest(result);
        }
    }
}
