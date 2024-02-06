using BarberTech.Application.Commands.Feedbacks.Create;
using BarberTech.Application.Commands.Feedbacks.Delete;
using BarberTech.Application.Commands.Feedbacks.Update;
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

        [HasPermission(Permissions.Feedbacks.Edit)]
        [HttpPost]
        public async Task<IActionResult> CreateFeedbackAsync([FromBody] CreateFeedbackCommand command)
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
