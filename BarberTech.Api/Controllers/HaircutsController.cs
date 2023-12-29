using BarberTech.Application.Commands.Haircuts.Create;
using BarberTech.Application.Commands.Haircuts.Delete;
using BarberTech.Application.Commands.Haircuts.Update;
using BarberTech.Application.Queries.Haircuts.GetAll;
using BarberTech.Application.Queries.Haircuts.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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

        [HttpGet]
        public async Task<IActionResult> GetAllHaircutsAsync([FromQuery] GetHaircutsQuery query)
        {
            var haircuts = await _mediator.Send(query);
            return Ok(haircuts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id, [FromQuery] GetHaircutByIdQuery query)
        {
            var haircut = await _mediator.Send(query.WithId(id));
            return Ok(haircut);
        }

        [HttpPost]
        public async Task<IActionResult> CreateHaircutAsync([FromBody] CreateHaircutCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHaircutAsync([FromRoute] Guid id, [FromBody] UpdateHaircutCommand command)
        {
            await _mediator.Send(command.WithId(id));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHaircutAsync([FromRoute] Guid id, [FromBody] DeleteHaircutCommand command)
        {
            await _mediator.Send(command.WithId(id));
            return NoContent();
        }
    }
}
