using Application.DTOs;
using Application.UseCases.CreateTodo;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/todos")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly CreateTodoHandler _createTodoHandler;

        public TodosController(CreateTodoHandler createTodoHandler)
        {
            _createTodoHandler = createTodoHandler;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateTodoDto request)
        {
            var result = await _createTodoHandler.Handle(request);
            return (result.Success) ? Ok(result) : BadRequest(result);
        }


    }
}
