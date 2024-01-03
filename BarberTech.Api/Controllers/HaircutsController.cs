using BarberTech.Application.Commands.Haircuts.Create;
using BarberTech.Application.Commands.Haircuts.Delete;
using BarberTech.Application.Commands.Haircuts.Update;
using BarberTech.Application.Queries.Haircuts.GetAll;
using BarberTech.Application.Queries.Haircuts.GetById;
using BarberTech.Infraestructure.Authentication;
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

        [HasPermission("haircuts:view")]
        [HttpGet]
        public async Task<IActionResult> GetHaircutsAsync([FromQuery] GetHaircutsQuery query)
        {
            var haircuts = await _mediator.Send(query);
            return Ok(haircuts);
        }

        [HasPermission("haircuts:view")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHaircutByIdAsync([FromRoute] Guid id, [FromQuery] GetHaircutByIdQuery query)
        {
            var haircut = await _mediator.Send(query.WithId(id));
            return Ok(haircut);
        }

        [HasPermission("haircuts:edit")]
        [HttpPost]
        public async Task<IActionResult> CreateHaircutAsync([FromBody] CreateHaircutCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HasPermission("haircuts:edit")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHaircutAsync([FromRoute] Guid id, [FromBody] UpdateHaircutCommand command)
        {
            await _mediator.Send(command.WithId(id));
            return NoContent();
        }

        [HasPermission("haircuts:edit")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHaircutAsync([FromRoute] Guid id, [FromBody] DeleteHaircutCommand command)
        {
            await _mediator.Send(command.WithId(id));
            return NoContent();
        }
    }
}
