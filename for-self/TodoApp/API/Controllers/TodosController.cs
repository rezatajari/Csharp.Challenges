using Application.DTOs;
using Application.UseCases.CreateTodo;
using Application.UseCases.DeleteTodo;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/todos")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly CreateTodoHandler _createTodoHandler;
        private readonly DeleteTodoHandler _deleteTodoHandler;

        public TodosController(
            CreateTodoHandler createTodoHandler,
            DeleteTodoHandler deleteTodoHandler
            )
        {
            _createTodoHandler = createTodoHandler;
            _deleteTodoHandler = deleteTodoHandler;
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
            var result=await _deleteTodoHandler.Handle(id);
            return (result.Success) ? Ok(result) : BadRequest(result);
        }
    }
}
