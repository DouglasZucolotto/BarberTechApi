using BarberTech.Application.Commands.EventSchedules.Cancel;
using BarberTech.Application.Commands.EventSchedules.Complete;
using BarberTech.Application.Commands.EventSchedules.Create;
using BarberTech.Application.Queries.EventSchedules.GetAll;
using BarberTech.Infraestructure.Authentication;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BarberTech.Api.Controllers
{
    [ApiController]
    [Route("api/event-schedules")]
    public class EventSchedulesController : Controller
    {
        private readonly IMediator _mediator;

        public EventSchedulesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HasPermission(Permissions.EventSchedules.View)]
        [HttpGet()]
        public async Task<IActionResult> GetSchedulesAsync([FromQuery] GetSchedulesQuery query)
        {
            var schedules = await _mediator.Send(query);
            return Ok(schedules);
        }

        [HasPermission(Permissions.EventSchedules.Edit)]
        [HttpPut("{id}/cancel")]
        public async Task<IActionResult> CancelScheduleAsync([FromRoute] Guid id)
        {
            await _mediator.Send(new CancelScheduleCommand(id));
            return NoContent();
        }

        [HasPermission(Permissions.EventSchedules.Edit)]
        [HttpPut("{id}/complete")]
        public async Task<IActionResult> CompleteScheduleAsync([FromRoute] Guid id)
        {
            await _mediator.Send(new CompleteScheduleCommand(id));
            return NoContent();
        }

        [HasPermission(Permissions.EventSchedules.Edit)]
        [HttpPost()]
        public async Task<IActionResult> CreateEventScheduleAsync([FromBody] CreateEventScheduleCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
