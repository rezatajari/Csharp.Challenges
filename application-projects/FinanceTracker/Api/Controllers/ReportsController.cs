using Infrastructure.BackgroundJobs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController(IBackgroundTaskQueue taskQueue) : ApiControllerBase
    {
        [HttpPost("request-pdf")]
        public async Task<IActionResult> RequestReport(string reportName)
        {
            await taskQueue.QueueBackgroundWorkItemAsync($"Generating PDF for: {reportName}");
            return Accepted(new { Message = "Report is being processed in the background." });
        }
    }
}
