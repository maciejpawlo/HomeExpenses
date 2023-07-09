using FluentValidation;
using System;
namespace HomeExpenses.Tracking.Application.Handlers.ExpenseHandlers.Queries.GetAllExpenses
{
	public class GetAllExpenseValidator : AbstractValidator<GetAllExpensesCommand>
	{
		public GetAllExpenseValidator()
		{
			RuleFor(x => x.PageNumber).GreaterThan(0);
			RuleFor(x => x.PageSize).GreaterThan(0);
			RuleFor(x => x.MinAmount).LessThan(x => x.MaxAmount).When(x => x.MinAmount is not null);
			RuleFor(x => x.MinDate).LessThan(x => x.MaxDate).When(x => x.MinDate is not null);
		}
	}
}

