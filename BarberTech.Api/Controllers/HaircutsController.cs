using BarberTech.Application.Commands.Haircuts.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BarberTech.Services.Controllers
{
    [ApiController]
    [Route("api/haircuts")]
    public class HaircutsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public HaircutsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> CreateHaircutAsync([FromQuery] CreateHaircutCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
