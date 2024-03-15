using BarberTech.Application.Commands.Users.Delete;
using BarberTech.Application.Commands.Users.Login;
using BarberTech.Application.Commands.Users.Register;
using BarberTech.Application.Commands.Users.Update;
using BarberTech.Application.Queries.Users.GetAll;
using BarberTech.Application.Queries.Users.GetById;
using BarberTech.Application.Queries.Users.UserOptions;
using BarberTech.Infraestructure.Authentication;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BarberTech.Api.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HasPermission(Permissions.Users.View)]
        [HttpGet]
        public async Task<IActionResult> GetUsersAsync([FromQuery] GetUsersQuery query)
        {
            var user = await _mediator.Send(query);
            return Ok(user);
        }

        [HasPermission(Permissions.Users.View)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsersByIdAsync([FromRoute] Guid id)
        {
            var user = await _mediator.Send(new GetUserByIdQuery(id));
            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUserAsync([FromBody] LoginCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HasPermission(Permissions.Users.Edit)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUsersAsync([FromRoute] Guid id, [FromBody] UpdateUserCommand command)
        {
            await _mediator.Send(command.WithId(id));
            return NoContent();
        }

        [HasPermission(Permissions.Users.Edit)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsersAsync([FromRoute] Guid id)
        {
            await _mediator.Send(new DeleteUserCommand(id));
            return NoContent();
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUserAsync([FromBody] RegisterUserCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HasPermission(Permissions.Users.View)]
        [HttpGet("options")]
        public async Task<IActionResult> GetUserOptionsAsync([FromQuery] GetUserOptionsQuery query)
        {
            var users = await _mediator.Send(query);
            return Ok(users);
        }
    }
}
