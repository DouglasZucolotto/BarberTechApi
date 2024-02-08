using BarberTech.Application.Commands.Barbers.Create;
using BarberTech.Application.Commands.Barbers.Delete;
using BarberTech.Application.Commands.Barbers.ScheduleHaircut;
using BarberTech.Application.Commands.Barbers.Update;
using BarberTech.Application.Queries.Barbers.AvailableDates;
using BarberTech.Application.Queries.Barbers.AvailableTimes;
using BarberTech.Application.Queries.Barbers.GetAll;
using BarberTech.Application.Queries.Barbers.GetById;
using BarberTech.Infraestructure.Authentication;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BarberTech.Api.Controllers
{
    [ApiController]
    [Route("api/barbers")]
    public class BarbersController : Controller
    {
        private readonly IMediator _mediator;

        public BarbersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> GetBarbersAsync()
        {
            var barbers = await _mediator.Send(new GetBarbersQuery());
            return Ok(barbers);
        }

        [HasPermission(Permissions.Barbers.View)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBarberByIdAsync([FromRoute] Guid id)
        {
            var barber = await _mediator.Send(new GetBarberByIdQuery(id));
            return Ok(barber);
        }

        [HasPermission(Permissions.Barbers.View)]
        [HttpGet("{id}/avaliable-dates")]
        public async Task<IActionResult> GetAvailableDatesAsync([FromRoute] Guid id)
        {
            var dates = await _mediator.Send(new GetAvailableDatesQuery(id));
            return Ok(dates);
        }

        [HasPermission(Permissions.Barbers.View)]
        [HttpGet("{id}/avaliable-times")]
        public async Task<IActionResult> GetAvailableTimesAsync([FromRoute] Guid id, [FromQuery] GetAvailableTimesQuery query)
        {
            var times = await _mediator.Send(query.WithId(id));
            return Ok(times);
        }

        [HasPermission(Permissions.Barbers.Edit)]
        [HttpPost]
        public async Task<IActionResult> CreateBarberAsync([FromBody] CreateBarberCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HasPermission(Permissions.Barbers.Edit)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBarberAsync([FromRoute] Guid id, [FromBody] UpdateBarberCommand command)
        {
            await _mediator.Send(command.WithId(id));
            return NoContent();
        }

        [HasPermission(Permissions.Barbers.Edit)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBarberAsync([FromRoute] Guid id)
        {
            await _mediator.Send(new DeleteBarberCommand(id));
            return NoContent();
        }

        [HasPermission(Permissions.Barbers.Edit)]
        [HttpPost("{id}/schedule-haircut")]
        public async Task<IActionResult> ScheduleHaircutAsync([FromRoute] Guid id, [FromBody] ScheduleHaircutCommand command)
        {
            await _mediator.Send(command.WithId(id));
            return NoContent();
        }
    }
}
