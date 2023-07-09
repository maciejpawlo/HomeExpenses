using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeExpenses.Tracking.Application.Handlers.ExpenseHandlers.Commands.UpdateExpense
{
    public class UpdateExpenseValidator : AbstractValidator<UpdateExpenseCommand>
    {
        public UpdateExpenseValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Amount).NotEqual(0);
            RuleFor(x => x.Comment).MaximumLength(255);
        }
    }
}
