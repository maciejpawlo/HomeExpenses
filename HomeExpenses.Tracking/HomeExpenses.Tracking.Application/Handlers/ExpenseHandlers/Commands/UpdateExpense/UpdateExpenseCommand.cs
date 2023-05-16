using HomeExpenses.Tracking.Domain.Entities.Expense;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeExpenses.Tracking.Application.Handlers.ExpenseHandlers.Commands.UpdateExpense
{
    public class UpdateExpenseCommand : IRequest
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public string? Comment { get; set; }
        public ExpenseType Type { get; set; }
    }
}
