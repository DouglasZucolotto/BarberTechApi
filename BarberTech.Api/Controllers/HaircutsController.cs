using BarberTech.Application.Commands.Haircuts.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BarberTech.Services.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HaircutsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public HaircutsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateHaircutAsync([FromBody] CreateHaircutCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
