using HomeExpenses.Tracking.Application.Handlers.ExpenseHandlers.Commands.UpdateExpense;
using HomeExpenses.Tracking.Application.Handlers.ExpenseHandlers.CreateExpense;
using HomeExpenses.Tracking.Application.Handlers.ExpenseHandlers.Queries.GetAllExpenses;
using HomeExpenses.Tracking.Application.Handlers.ExpenseHandlers.Queries.GetExpenseById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeExpenses.Tracking.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private ISender mediator = null!;
        protected ISender Mediator => mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();

        public ExpenseController(ISender mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost()]
        public async Task<IActionResult> Create(CreateExpenseCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateExpenseCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);
            return NoContent();
        }

        [HttpGet()]
        public async Task<IActionResult> GetAll([FromBody] GetAllExpensesCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await Mediator.Send(new GetExpenseByIdCommand { Id = id}));
        }
    }
}
