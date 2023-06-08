using System;
using HomeExpenses.Tracking.Application.Shared.DTOs;
using HomeExpenses.Tracking.Domain.Entities.Expense;
using MediatR;

namespace HomeExpenses.Tracking.Application.Handlers.ExpenseHandlers.Queries.GetAllExpenses
{
	public class GetAllExpensesCommand : IRequest<PaginatedList<ExpenseDTO>>
	{
		public ExpenseType? Type { get; set; }
		public decimal? MaxAmount { get; set; }
		public decimal? MinAmount { get; set; }
		public DateTime? MinDate { get; set; }
        public DateTime? MaxDate { get; set; }
        public int PageNumber { get; set; }
		public int PageSize { get; set; }
	}
	
}

