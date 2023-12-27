using BarberTech.Application.Commands.Haircuts.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BarberTech.Services.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HaircutsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public HaircutsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateHaircutAsync([FromQuery] CreateHaircutCommand query) //, IFormFile file)
        {
            //using var fileStream = file.OpenReadStream();

            await _mediator.Send(query);
            return NoContent();
        }
    }
}
