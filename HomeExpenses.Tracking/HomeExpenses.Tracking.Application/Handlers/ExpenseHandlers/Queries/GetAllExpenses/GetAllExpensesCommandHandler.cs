using System;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using HomeExpenses.Tracking.Application.Shared.DTOs;
using HomeExpenses.Tracking.Domain.Entities.Expense;
using MediatR;

namespace HomeExpenses.Tracking.Application.Handlers.ExpenseHandlers.Queries.GetAllExpenses
{
	public class GetAllExpensesCommandHandler : IRequestHandler<GetAllExpensesCommand, PaginatedList<ExpenseDTO>>
	{
        private readonly IExpenseRepository repository;
        private readonly IMapper mapper;

        public GetAllExpensesCommandHandler(IExpenseRepository repository,
            IMapper mapper)
		{
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<PaginatedList<ExpenseDTO>> Handle(GetAllExpensesCommand request, CancellationToken cancellationToken)
        {
            //TODO: add optional filtering
            var expensesQuery = repository.GetAll().ProjectTo<ExpenseDTO>(mapper.ConfigurationProvider);

            return await PaginatedList<ExpenseDTO>.CreateAsync(expensesQuery, request.PageNumber, request.PageSize);
        }
    }
}

