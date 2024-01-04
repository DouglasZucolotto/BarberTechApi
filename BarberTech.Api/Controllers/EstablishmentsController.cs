using BarberTech.Application.Commands.Establishments.Create;
using BarberTech.Application.Commands.Establishments.Delete;
using BarberTech.Application.Commands.Establishments.Update;
using BarberTech.Application.Queries.Establishments.GetAll;
using BarberTech.Application.Queries.Establishments.GetById;
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

        [HttpGet]
        public async Task<IActionResult> GetAllEstablishmentsAsync([FromQuery] GetEstablishmentsQuery query)
        {
            var establishments = await _mediator.Send(query);
            return Ok(establishments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id, [FromQuery] GetEstablishmentByIdQuery query)
        {
            var establishment = await _mediator.Send(query.WithId(id));
            return Ok(establishment);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEstablishmentAsync([FromBody] CreateEstablishmentCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEstablishmentAsync([FromRoute] Guid id, [FromBody] UpdateEstablishmentCommand command)
        {
            await _mediator.Send(command.WithId(id));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstablishmentAsync([FromRoute] Guid id, [FromBody] DeleteEstablishmentCommand command)
        {
            await _mediator.Send(command.WithId(id));
            return NoContent();
        }
    }
}
