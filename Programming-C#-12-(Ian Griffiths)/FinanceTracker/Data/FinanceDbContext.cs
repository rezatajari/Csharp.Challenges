using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceTracker.Data
{
    public class FinanceDbContext:DbContext
    {
        public FinanceDbContext( DbContextOptions<FinanceDbContext> options)
            :base(options){}
    }
}
