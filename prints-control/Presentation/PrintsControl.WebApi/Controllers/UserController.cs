using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PrintsControl.Application.Features.Users;
using PrintsControl.Application.Features.Users.Commands;
using PrintsControl.Application.Features.Users.Queries;

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

    [HttpGet]
    public async Task<ActionResult<List<GetAllUserResponse>>> GetAllAsync(CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetAllUserQuery(), cancellationToken);
        return Ok(response);
    }
    
    [HttpPost]
    public async Task<ActionResult<CreateUserResponse>> CreateAsync(CreateUserCommand request)
    {
       var userId = await _mediator.Send(request);
        return Ok(userId);
    }
    
}