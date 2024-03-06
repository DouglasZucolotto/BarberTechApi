using BarberTech.Application.Commands.Barbers.Create;
using BarberTech.Application.Commands.Barbers.Update;
using BarberTech.Application.Queries.Barbers.AvailableDates;
using BarberTech.Application.Queries.Barbers.AvailableTimes;
using BarberTech.Application.Queries.Barbers.BarberOptions;
using BarberTech.Application.Queries.Barbers.Calendar;
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

        [HttpGet()]
        public async Task<IActionResult> GetBarbersAsync([FromQuery] GetBarbersQuery query)
        {
            var barbers = await _mediator.Send(query);
            return Ok(barbers);
        }

        [HasPermission(Permissions.Barbers.View)]
        [HttpGet("options")]
        public async Task<IActionResult> GetBarberOptionsAsync()
        {
            var options = await _mediator.Send(new GetBarberOptionsQuery());
            return Ok(options);
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
        public async Task<IActionResult> GetAvailableTimesAsync([FromRoute] Guid id, [FromQuery] string date)
        {
            var times = await _mediator.Send(new GetAvailableTimesQuery(id, date));
            return Ok(times);
        }

        [HasPermission(Permissions.Barbers.View)]
        [HttpGet("{id}/calendar")]
        public async Task<IActionResult> GetCalendarAsync([FromRoute] Guid id)
        {
            var calendar = await _mediator.Send(new GetCalendarQuery(id));
            return Ok(calendar);
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
    }
}
