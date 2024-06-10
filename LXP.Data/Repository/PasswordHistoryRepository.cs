﻿using LXP.Common.Entities;
using LXP.Data.IRepository;
using Microsoft.EntityFrameworkCore; // Use this
// using System.Data.Entity; // Remove this

namespace LXP.Data.Repository
{
    public class PasswordHistoryRepository : IPasswordHistoryRepository
    {
        // Assume _context is your DbContext
        private readonly LXPDbContext _LXPDbContext;

        public PasswordHistoryRepository(LXPDbContext context)
        {
            _LXPDbContext = context;
        }

        public async Task<PasswordHistory> GetPasswordHistory(Guid learnerId)
        {
            return await _LXPDbContext.PasswordHistories.FirstOrDefaultAsync(x => x.LearnerId == learnerId);
        }

        public async Task UpdatePasswordHistory(PasswordHistory passwordHistory)
        {
            _LXPDbContext.PasswordHistories.Update(passwordHistory);
            await _LXPDbContext.SaveChangesAsync();
        }
    }
}
