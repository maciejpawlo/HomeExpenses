using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeExpenses.Tracking.Application.Handlers.ExpenseHandlers.CreateExpense
{
    public class CreateExpenseCommandValidator : AbstractValidator<CreateExpenseCommand>
    {
        public CreateExpenseCommandValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.Amount).NotEqual(0);
            RuleFor(x => x.Comment).MaximumLength(255);
        }
    }
}
