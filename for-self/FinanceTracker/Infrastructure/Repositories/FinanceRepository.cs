using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class FinanceRepository : BaseRepository<BaseAccount>, IFinanceRepository
    {
        public FinanceRepository(FinanceDbContext context):base(context){}

    }
}
