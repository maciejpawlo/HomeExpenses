using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeExpenses.Tracking.Domain.Entities.Expense;

namespace HomeExpenses.Tracking.Domain.Entities.User
{
    public class User
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public ICollection<Expense.Expense> Expenses { get; set; }

        public User()
        {
            this.Expenses = new HashSet<Expense.Expense>();
        }
    }
}
