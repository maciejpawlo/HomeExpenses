using HomeExpenses.Tracking.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeExpenses.Tracking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        public ExpenseController()
        {
            
        }

        [HttpPost()]
        public IActionResult Add()
        {
            return Ok();
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
