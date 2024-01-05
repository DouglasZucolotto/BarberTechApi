using BarberTech.Application.Commands.Feedbacks.Delete;
using BarberTech.Application.Commands.Feedbacks.EvaluateBarber;
using BarberTech.Application.Commands.Feedbacks.EvaluateHaircut;
using BarberTech.Application.Commands.Feedbacks.Update;
using BarberTech.Application.Queries.Feedbacks.GetAll;
using BarberTech.Application.Queries.Feedbacks.GetById;
using BarberTech.Domain.Entities;
using BarberTech.Infraestructure.Authentication;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BarberTech.Services.Controllers
{
    [ApiController]
    [Route("api/feedbacks")]
    public class FeedbacksController : Controller
    {
        private readonly IMediator _mediator;

        public FeedbacksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HasPermission(Permissions.Feedbacks.View)]
        [HttpGet]
        public async Task<IActionResult> GetFeedbacksAsync()
        {
            var feedbacks = await _mediator.Send(new GetFeedbacksQuery());
            return Ok(feedbacks);
        }

        [HasPermission(Permissions.Feedbacks.View)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeedbackByIdAsync([FromRoute] Guid id)
        {
            var feedback = await _mediator.Send(new GetFeedbackByIdQuery(id));
            return Ok(feedback);
        }

        [HasPermission(Permissions.Feedbacks.Edit)]
        [HttpPost("haircut")]
        public async Task<IActionResult> EvaluateHaircutAsync([FromBody] EvaluateHaircutCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HasPermission(Permissions.Feedbacks.Edit)]
        [HttpPost("barber")]
        public async Task<IActionResult> EvaluateBarberAsync([FromBody] EvaluateBarberCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HasPermission(Permissions.Feedbacks.Edit)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFeedbackAsync([FromRoute] Guid id, [FromBody] UpdateFeedbackCommand command)
        {
            await _mediator.Send(command.WithId(id));
            return NoContent();
        }

        [HasPermission(Permissions.Feedbacks.Edit)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeedbackAsync([FromRoute] Guid id)
        {
            await _mediator.Send(new DeleteFeedbackCommand(id));
            return NoContent();
        }
    }
}
