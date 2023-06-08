using System;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using HomeExpenses.Tracking.Application.Shared.DTOs;
using HomeExpenses.Tracking.Application.Shared.Extensions;
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
            var expensesQuery = repository.GetAll()
                .ConditionalWhere(request.MaxAmount is not null, e => e.Amount < request.MaxAmount)
                .ConditionalWhere(request.MinAmount is not null, e => e.Amount > request.MinAmount)
                .ConditionalWhere(request.Type is not null, e => e.Type == request.Type)
                .ConditionalWhere(request.MinDate is not null, e => e.CreatedOn > request.MinDate)
                .ConditionalWhere(request.MaxDate is not null, e => e.CreatedOn < request.MaxDate)
                .ProjectTo<ExpenseDTO>(mapper.ConfigurationProvider);

            return await PaginatedList<ExpenseDTO>.CreateAsync(expensesQuery, request.PageNumber, request.PageSize);
        }
    }
}

