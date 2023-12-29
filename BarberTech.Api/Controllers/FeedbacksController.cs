using BarberTech.Application.Commands.Feedbacks.Create;
using BarberTech.Application.Commands.Feedbacks.Update;
using BarberTech.Application.Queries.Feedbacks.GetAll;
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

        [HttpGet]
        public async Task<IActionResult> GetAllHaircutsAsync([FromQuery] GetFeedbacksQuery query)
        {
            var feedbacks = await _mediator.Send(query);
            return Ok(feedbacks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id, [FromQuery] GetFeedbackByIdQuery query)
        {
            var feedback = await _mediator.Send(query.WithId(id));
            return Ok(feedback);
        }

        [HttpPost]
        public async Task<IActionResult> CreateHaircutAsync([FromBody] CreateFeedbackCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHaircutAsync([FromRoute] Guid id, [FromBody] UpdateFeedbackCommand command)
        {
            await _mediator.Send(command.WithId(id));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHaircutAsync([FromRoute] Guid id, [FromBody] UpdateFeedbackCommand command)
        {
            await _mediator.Send(command.WithId(id));
            return NoContent();
        }
    }
}
