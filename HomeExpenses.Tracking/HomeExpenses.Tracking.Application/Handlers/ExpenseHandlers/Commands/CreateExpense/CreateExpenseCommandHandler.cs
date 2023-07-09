using HomeExpenses.Tracking.Application.Handlers.ExpenseHandlers.CreateExpense;
using HomeExpenses.Tracking.Domain.Entities.Expense;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeExpenses.Tracking.Application.Handlers.ExpenseHandlers.Commands.CreateExpense
{
    public class CreateExpenseCommandHandler : IRequestHandler<CreateExpenseCommand, Guid>
    {
        private readonly IExpenseRepository expenseRepository;

        public CreateExpenseCommandHandler(IExpenseRepository expenseRepository)
        {
            this.expenseRepository = expenseRepository;
        }

        public async Task<Guid> Handle(CreateExpenseCommand request, CancellationToken cancellationToken)
        {
            var expense = new Expense
            {
                Amount = request.Amount,
                Comment = request.Comment,
                CreatedOn = DateTime.UtcNow,
                Type = request.Type,
                UserId = request.UserId,
                CreatedBy = "test"
            };

            await expenseRepository.AddAsync(expense);

            return expense.Id;
        }
    }
}
