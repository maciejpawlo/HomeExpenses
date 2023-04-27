using HomeExpenses.Tracking.Application.Handlers.ExpenseHandlers.CreateExpense;
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
        public IActionResult Update(Guid id)
        {
            return Ok();
        }

        [HttpGet()]
        public IActionResult GetAll()
        {
            return Ok();
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetById(Guid id)
        {
            return Ok();
        }
    }
}
