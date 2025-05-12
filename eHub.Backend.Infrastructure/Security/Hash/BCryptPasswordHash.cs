﻿using eHub.Backend.Domain.Contracts.Services;

namespace eHub.Backend.Infrastructure.Security.Hash
{
    public class BCryptPasswordHasher : IPasswordHasherService
    {
        public string Hash(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool Verify(string password, string passwordHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, passwordHash);
        }
    }
}
