using FluentValidation;
using System;
namespace HomeExpenses.Tracking.Application.Handlers.ExpenseHandlers.Queries.GetAllExpenses
{
	public class GetAllExpenseValidator : AbstractValidator<GetAllExpensesCommand>
	{
		public GetAllExpenseValidator()
		{
			RuleFor(x => x.PageNumber).GreaterThan(0);
		}
	}
}

