using Application.Interfaces.IRepositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        public Task<User?> GetByEmailAsync(string email, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}
