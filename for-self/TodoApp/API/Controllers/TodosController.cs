using Application.DTOs;
using Application.UseCases.CreateTodo;
using Application.UseCases.DeleteTodo;
using Application.UseCases.GetTodo;
using Application.UseCases.UpdateTodo;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/todos")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly CreateTodoHandler _createTodoHandler;
        private readonly DeleteTodoHandler _deleteTodoHandler;
        private readonly GetTodoHandler _getTodoHandler;
        private readonly UpdateTodoHandler _updateTodoHandler;

        public TodosController(
            CreateTodoHandler createTodoHandler,
            DeleteTodoHandler deleteTodoHandler,
            GetTodoHandler getTodoHandler,
            UpdateTodoHandler updateTodoHandler
            )
        {
            _createTodoHandler = createTodoHandler;
            _deleteTodoHandler = deleteTodoHandler;
            _getTodoHandler = getTodoHandler;
            _updateTodoHandler = updateTodoHandler;
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

        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdateTodoDto request)
        {
            var result= await _updateTodoHandler.Handle(request);
            return (result.Success) ? Ok(result) : BadRequest(result);
        }
    }
}
