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
            using (IServiceScope scope = _serviceScopeFactory.CreateScope())
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<FinanceDbContext>();

                    var count=dbContext.Transactions.Count();
                    logger.LogInformation("Midnight Janitor: Cheking for reports to generate at: {time}", DateTimeOffset.Now);
                    await Task.Delay(1000, stoppingToken);
                }
            }
        }
    }
}
