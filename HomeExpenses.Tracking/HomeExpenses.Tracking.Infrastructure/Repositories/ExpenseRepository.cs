using HomeExpenses.Tracking.Domain.Entities.Expense;
using HomeExpenses.Tracking.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeExpenses.Tracking.Infrastructure.Repositories
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly TrackingDbContext dbContext;

        public ExpenseRepository(TrackingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddAsync(Expense expense)
        {
            await dbContext.AddAsync(expense);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IQueryable<Expense>> GetAllAsync()
        {
            return dbContext.Expenses.AsQueryable();
        }

        public async Task<Expense?> GetByIdAsync(Guid id)
        {
            return await dbContext.Expenses.FindAsync(id);
        }

        public async Task UpdateAsync(Expense expense)
        {
            dbContext.Expenses.Update(expense);
            await dbContext.SaveChangesAsync();
        }
    }
}
