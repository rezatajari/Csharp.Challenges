using Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Infrastructure.BackgroundJobs
{
    public class MonthlyReportWorker(IServiceScopeFactory _serviceScopeFactory, ILogger<MonthlyReportWorker> logger) : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (IServiceScope scope = _serviceScopeFactory.CreateScope())
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<FinanceDbContext>();
                    var count = dbContext.Transactions.Count();

                    logger.LogInformation("--- Background Check ---");
                    logger.LogInformation("Database count is: {count}", count);
                    logger.LogInformation("Next check in 10 seconds...");
                }

                await Task.Delay(1000000, stoppingToken);
            }
        }
    }
}
