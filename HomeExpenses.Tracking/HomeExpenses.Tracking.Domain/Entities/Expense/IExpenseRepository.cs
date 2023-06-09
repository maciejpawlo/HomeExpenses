﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeExpenses.Tracking.Domain.Entities.Expense
{
    public interface IExpenseRepository
    {
        IQueryable<Expense> GetAll();
        Task<Expense?> GetByIdAsync(Guid id);
        Task AddAsync(Expense expense);
        Task UpdateAsync(Expense expense);
    }
}
