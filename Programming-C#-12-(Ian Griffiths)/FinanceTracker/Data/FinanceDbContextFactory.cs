using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceTracker.Data
{
    public class FinanceDbContextFactory :
        IDesignTimeDbContextFactory<FinanceDbContext>
    {
        public FinanceDbContext CreateDbContext(string[] args)
        {

            var optionsBuilder=new DbContextOptionsBuilder<FinanceDbContext>();

            var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false)
                    .Build();
            var connectionstring = configuration.GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlServer(connectionstring);

            return new FinanceDbContext(optionsBuilder.Options);
        }
    }
}
