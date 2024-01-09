using BarberTech.Application.Commands.Establishments.Create;
using BarberTech.Application.Commands.Establishments.Delete;
using BarberTech.Application.Commands.Establishments.Update;
using BarberTech.Application.Queries.Establishments.GetAll;
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
        [HttpGet]
        public async Task<IActionResult> GetEstablishmentsAsync()
        {
            var establishments = await _mediator.Send(new GetEstablishmentsQuery());
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
    }
}
