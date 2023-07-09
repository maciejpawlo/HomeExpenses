using HomeExpenses.Tracking.Domain.Entities.Expense;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeExpenses.Tracking.Application.Handlers.ExpenseHandlers.Commands.UpdateExpense
{
    public class UpdateExpenseCommandHandler : IRequestHandler<UpdateExpenseCommand>
    {
        private readonly IExpenseRepository expenseRepository;

        public UpdateExpenseCommandHandler(IExpenseRepository expenseRepository)
        {
            this.expenseRepository = expenseRepository;
        }

        public async Task Handle(UpdateExpenseCommand request, CancellationToken cancellationToken)
        {
            var expense = new Expense
            {
                Id = request.Id,
                Amount = request.Amount,
                Comment = request.Comment,
                Type = request.Type,
            };
            await expenseRepository.UpdateAsync(expense);
        }
    }
}
