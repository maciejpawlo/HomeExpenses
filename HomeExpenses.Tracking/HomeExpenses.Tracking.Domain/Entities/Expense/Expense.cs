using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeExpenses.Tracking.Domain.Entities.Expense
{
    public class Expense
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string? Comment { get; set; }
        public ExpenseType Type { get; set; }
        public Guid UserId { get; set; }
    }
}
