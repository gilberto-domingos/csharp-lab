using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PrintsControl.Application.Dtos.Students;
using PrintsControl.Application.Features.Students.Commands.CreateStudent;
using PrintsControl.Application.Features.Students.Commands.UpdateStudent;
using PrintsControl.Application.Features.Students.Queries.GetAllStudents;
using PrintsControl.Application.Features.Students.Queries.GetByIdStudent;
using PrintsControl.Application.Features.Users.Commands.DeleteUser;

namespace PrintsControl.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase
{
    private readonly IMediator _mediator;

    public StudentController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<GetAllStudentResponse>>> GetAllAsync(CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetAllStudentsQuery(), cancellationToken);
        return Ok(response);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdStudentResponse>> GetIdAsync(Guid? id, CancellationToken cancellationToken)
    {
        var request = new GetByIdStudentQuery(id.Value);

        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
    
    [HttpPost]
    public async Task<ActionResult<CreateStudentResponse>> CreateAsync(CreateStudentCommand request)
    {
        var studentId = await _mediator.Send(request);
        return Ok(studentId);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UpdateStudentResponse>> UpdateAsync(Guid id, UpdateStudentCommand request, CancellationToken cancellationToken)
    {
        if (id != request.Id)
            return BadRequest();

        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid? id, CancellationToken cancellationToken)
    {
        var deleteUserRequest = new DeleteUserCommand(id.Value);

        var response = await _mediator.Send(deleteUserRequest, cancellationToken);
        return Ok(response);
    }
}