using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PrintsControl.Application.Features.Users;
using PrintsControl.Application.Features.Users.Commands;

namespace PrintsControl.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[EnableCors("AllowAll")]
// [Authorize]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<CreateUserResponse>> Create(CreateUserCommand request,CancellationToken cancellationToken)
    {
       var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}