using HomeExpenses.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeExpenses.Tracking.Domain.Entities.Expense
{
    public class Expense : Entity
    {
        public decimal Amount { get; set; }
        public string? Comment { get; set; }
        public ExpenseType Type { get; set; }

        public Guid UserId { get; set; }
        public User.User User { get; set; }
    }
}
