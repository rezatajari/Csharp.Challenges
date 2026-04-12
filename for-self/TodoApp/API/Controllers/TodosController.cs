using Application.DTOs;
using Application.UseCases.CreateTodo;
using Microsoft.AspNetCore.Http;
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
            _createTodoHandler=createTodoHandler;
        }

        [HttpPost]
        public IActionResult Create(CreateTodoDto request)
        {
            var result= _createTodoHandler.Handle(request);
            return Ok(result);
        }
    }
}
