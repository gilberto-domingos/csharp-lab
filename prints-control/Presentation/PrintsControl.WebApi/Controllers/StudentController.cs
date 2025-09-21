using MediatR;
using Microsoft.AspNetCore.Mvc;
using PrintsControl.Application.Dtos.Students;
using PrintsControl.Application.Features.Commands.Students;
using PrintsControl.Application.Features.Queries.Student;
using PrintsControl.Application.Features.Students.Queries.GetAllStudents;
using PrintsControl.Application.Features.Students.Queries.GetByIdStudent;

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
    public async Task<ActionResult<List<StudentDto>>> GetAllAsync(GetAllStudentsQuery request ,CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
    
    [HttpGet("{name}")]
    public async Task<ActionResult<StudentDto>> GetByNameAsync(string name, CancellationToken cancellationToken)
    {
        var request = new GetByNameStudentQuery(name);
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<StudentDto>> GetIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var request = new GetByIdStudentQuery(id);

        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
    
    
    [HttpPost]
    public async Task<ActionResult<StudentDto>> CreateAsync(CreateStudentCommand request)
    {
        var studentId = await _mediator.Send(request);
        return Ok(studentId);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<StudentDto>> UpdateAsync(Guid id, UpdateStudentCommand request, CancellationToken cancellationToken)
    {
        if (id != request.Id)
            return BadRequest();

        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        var command = new DeleteStudentCommand(id);

        var response = await _mediator.Send(command, cancellationToken);
        
        return Ok(response);
    }
}