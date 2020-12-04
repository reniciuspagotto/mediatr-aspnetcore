using MediatR;
using MediatRWithAspNetCore.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace MediatRWithAspNetCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCustomerCommand command)
        {
            var response = await _mediator.Send(command);

            if (response.Errors.Any())
                return BadRequest(response);

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> Get(GetCustomerQuery command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
