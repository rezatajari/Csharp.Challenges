using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Infrastructure.BackgroundJobs
{
    public class QueuedWorker(ILogger<QueuedWorker> logger,IBackgroundTaskQueue taskQueue) : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            logger.LogInformation("Queued worker is waiting for jobs...");

            while (!stoppingToken.IsCancellationRequested) { 
                var workItem=await taskQueue.DequeueAsync(stoppingToken);
                logger.LogInformation("Worker grabbed job: {job}. Starting processing...", workItem);
                await Task.Delay(5000, stoppingToken);
                logger.LogInformation("Finished job: {job}", workItem);
            }
        }
    }
}
