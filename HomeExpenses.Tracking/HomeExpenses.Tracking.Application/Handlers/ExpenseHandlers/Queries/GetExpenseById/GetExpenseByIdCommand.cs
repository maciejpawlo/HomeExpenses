using HomeExpenses.Tracking.Application.Shared.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeExpenses.Tracking.Application.Handlers.ExpenseHandlers.Queries.GetExpenseById
{
    public class GetExpenseByIdCommand : IRequest<ExpenseDTO>
    {
        public Guid Id { get; set; }
    }
}
