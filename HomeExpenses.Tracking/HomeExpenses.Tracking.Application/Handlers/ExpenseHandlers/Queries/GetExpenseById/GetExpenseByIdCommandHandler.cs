using AutoMapper;
using HomeExpenses.Tracking.Application.Shared.DTOs;
using HomeExpenses.Tracking.Domain.Entities.Expense;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeExpenses.Tracking.Application.Handlers.ExpenseHandlers.Queries.GetExpenseById
{
    public class GetExpenseByIdCommandHandler : IRequestHandler<GetExpenseByIdCommand, ExpenseDTO>
    {
        private readonly IExpenseRepository expenseRepository;
        private readonly IMapper mapper;

        public GetExpenseByIdCommandHandler(IExpenseRepository expenseRepository,
            IMapper mapper)
        {
            this.expenseRepository = expenseRepository;
            this.mapper = mapper;
        }

        public async Task<ExpenseDTO> Handle(GetExpenseByIdCommand request, CancellationToken cancellationToken)
        {
            var expense = await expenseRepository.GetByIdAsync(request.Id);

            return mapper.Map<ExpenseDTO>(expense);
        }
    }
}
