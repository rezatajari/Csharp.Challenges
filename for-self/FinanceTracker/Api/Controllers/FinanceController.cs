using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinanceController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetTransactions()
        {
            var transactions = new[] { "Salary:$5000", "Rent:$1500", "Groceries:$300"};
            return Ok(transactions);
        }
    }
}
