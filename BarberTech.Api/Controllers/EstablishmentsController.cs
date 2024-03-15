using BarberTech.Application.Commands.Establishments.Create;
using BarberTech.Application.Commands.Establishments.Delete;
using BarberTech.Application.Commands.Establishments.Update;
using BarberTech.Application.Queries.Establishments.EstablishmentOptions;
using BarberTech.Application.Queries.Establishments.GetAll;
using BarberTech.Application.Queries.Establishments.GetBarbers;
using BarberTech.Application.Queries.Establishments.GetById;
using BarberTech.Infraestructure.Authentication;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BarberTech.Api.Controllers
{
    [ApiController]
    [Route("api/establishments")]
    public class EstablishmentsController : Controller
    {
        private readonly IMediator _mediator;

        public EstablishmentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HasPermission(Permissions.Establishments.View)]
        [HttpGet("options")]
        public async Task<IActionResult> GetEstablishmentOptionsAsync([FromQuery] GetEstablishmentOptionsQuery query)
        {
            var options = await _mediator.Send(query);
            return Ok(options);
        }

        [HttpGet()]
        public async Task<IActionResult> GetEstablishmentsAsync([FromQuery] GetEstablishmentsQuery query)
        {
            var establishments = await _mediator.Send(query);
            return Ok(establishments);
        }

        [HasPermission(Permissions.Establishments.View)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEstablishmentByIdAsync([FromRoute] Guid id)
        {
            var establishment = await _mediator.Send(new GetEstablishmentByIdQuery(id));
            return Ok(establishment);
        }

        [HasPermission(Permissions.Establishments.Edit)]
        [HttpPost]
        public async Task<IActionResult> CreateEstablishmentAsync([FromBody] CreateEstablishmentCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HasPermission(Permissions.Establishments.Edit)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEstablishmentAsync([FromRoute] Guid id, [FromBody] UpdateEstablishmentCommand command)
        {
            await _mediator.Send(command.WithId(id));
            return NoContent();
        }

        [HasPermission(Permissions.Establishments.Edit)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstablishmentAsync([FromRoute] Guid id)
        {
            await _mediator.Send(new DeleteEstablishmentCommand(id));
            return NoContent();
        }

        [HasPermission(Permissions.Establishments.View)]
        [HttpGet("{id}/barbers")]
        public async Task<IActionResult> GetBarbersAsync([FromRoute] Guid id, [FromQuery] string searchTerm)
        {
            var barbers = await _mediator.Send(new GetBarbersQuery(id, searchTerm));
            return Ok(barbers);
        }
    }
}
