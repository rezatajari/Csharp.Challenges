using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.IRepositories
{
    public interface IAuthRepository : IBaseRepository<User>
    {
        Task<User?> GetByEmailAsync(string email, CancellationToken ct);
    }
}
