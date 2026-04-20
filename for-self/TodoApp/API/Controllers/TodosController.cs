using Application.Common;
using Application.DTOs;
using Application.UseCases.CompleteTodo;
using Application.UseCases.CreateTodo;
using Application.UseCases.DeleteTodo;
using Application.UseCases.GetTodo;
using Application.UseCases.UpdateTodo;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly CreateTodoHandler _createTodoHandler;
        private readonly DeleteTodoHandler _deleteTodoHandler;
        private readonly GetTodoHandler _getTodoHandler;
        private readonly UpdateTodoHandler _updateTodoHandler;
        private readonly CompleteTodoHandler _completeTodoHandler;

        public TodosController(
            CreateTodoHandler createTodoHandler,
            DeleteTodoHandler deleteTodoHandler,
            GetTodoHandler getTodoHandler,
            UpdateTodoHandler updateTodoHandler,
            CompleteTodoHandler completeTodoHandler
            )
        {
            _createTodoHandler = createTodoHandler;
            _deleteTodoHandler = deleteTodoHandler;
            _getTodoHandler = getTodoHandler;
            _updateTodoHandler = updateTodoHandler;
            _completeTodoHandler = completeTodoHandler;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateTodoDto request)
        {
            var result = await _createTodoHandler.Handle(request);
            return (result.Success)
                ? Ok(new ApiResponse<ResponseTodoItemDto>(true, Data: result.Data))
                : BadRequest(new ApiResponse<ResponseTodoItemDto>(false, Message: result.Message));
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _deleteTodoHandler.Handle(id);
            return (result.Success) ? Ok(result.Data) : BadRequest(result.Message);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _getTodoHandler.Handle(id);
            return (result.Success) ? Ok(result.Data) : BadRequest(result.Message);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateTodoDto request)
        {
            var result = await _updateTodoHandler.Handle(request);
            return (result.Success) ? Ok(result.Data) : BadRequest(result.Message);
        }

        [HttpPost("complete/{id}")]
        public async Task<IActionResult> Complete(int id)
        {
            var result = await _completeTodoHandler.Handle(id);
            return (result.Success) ? Ok(result.Data) : BadRequest(result.Message);
        }
    }
}
