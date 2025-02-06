﻿using DataAccessLayer.Models;

namespace DataAccessLayer.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> GetByEmailAsync(string email);
    }
}