using BarberTech.Application.Commands.Haircuts.Create;
using BarberTech.Application.Commands.Haircuts.Delete;
using BarberTech.Application.Commands.Haircuts.Update;
using BarberTech.Application.Queries.Haircuts.GetAll;
using BarberTech.Application.Queries.Haircuts.GetById;
using BarberTech.Infraestructure.Authentication;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BarberTech.Api.Controllers
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

        [HttpGet()]
        public async Task<IActionResult> GetHaircutsAsync([FromQuery] GetHaircutsQuery query)
        {
            var haircuts = await _mediator.Send(query);
            return Ok(haircuts);
        }

        [HasPermission(Permissions.Haircuts.View)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHaircutByIdAsync([FromRoute] Guid id)
        {
            var haircut = await _mediator.Send(new GetHaircutByIdQuery(id));
            return Ok(haircut);
        }

        [HasPermission(Permissions.Haircuts.Edit)]
        [HttpPost]
        public async Task<IActionResult> CreateHaircutAsync([FromBody] CreateHaircutCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HasPermission(Permissions.Haircuts.Edit)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHaircutAsync([FromRoute] Guid id, [FromBody] UpdateHaircutCommand command)
        {
            await _mediator.Send(command.WithId(id));
            return NoContent();
        }

        [HasPermission(Permissions.Haircuts.Edit)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHaircutAsync([FromRoute] Guid id)
        {
            await _mediator.Send(new DeleteHaircutCommand(id));
            return NoContent();
        }
    }
}
