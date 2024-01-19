﻿using BarberTech.Application.Commands.Users.Delete;
using BarberTech.Application.Commands.Users.Login;
using BarberTech.Application.Commands.Users.Register;
using BarberTech.Application.Commands.Users.Update;
using BarberTech.Application.Queries.Users.GetAll;
using BarberTech.Application.Queries.Users.GetById;
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
        public async Task<IActionResult> GetUsersAsync()
        {
            var user = await _mediator.Send(new GetUsersQuery());
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
            var token = await _mediator.Send(command);
            return Ok(token);
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

        [HasPermission(Permissions.Users.Edit)]
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUserAsync([FromBody] CreateCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
