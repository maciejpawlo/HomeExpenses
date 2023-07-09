﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeExpenses.Tracking.Application.Handlers.ExpenseHandlers.Queries.GetExpenseById
{
    public class GetExpenseByIdCommandValidator : AbstractValidator<GetExpenseByIdCommand>
    {
        public GetExpenseByIdCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
