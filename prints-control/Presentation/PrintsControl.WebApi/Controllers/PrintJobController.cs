using MediatR;
using Microsoft.AspNetCore.Mvc;
using PrintsControl.Application.Dtos.PrintJobs;
using PrintsControl.Application.Features.Commands.PrintJobs;
using PrintsControl.Application.Features.Queries.PrintJobs;

namespace PrintsControl.WebApi.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class PrintJobController : ControllerBase
{
    private readonly IMediator _mediator;

    public PrintJobController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<PrintJobDto>>> GetAllAsync(GetAllPrintJobsQuery request,
        CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<PrintJobDto>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var request = new GetByIdPrintJobQuery(id);
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<PrintJobDto>> CreateAsync(CreatePrintJobCommand request,
        CancellationToken cancellationToken)
    {
        var printJob = await _mediator.Send(request, cancellationToken);
        return Ok(printJob);
    }

    [HttpPut]
    public async Task<ActionResult<PrintJobDto>> UpdateAsync(Guid id, UpdatePrintJobCommand request,
        CancellationToken cancellationToken)
    {
        if (id != request.Id)
            return BadRequest();

        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<PrintJobDto>> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var command = new DeletePrintJobCommand(id);
        var response = await _mediator.Send(command, cancellationToken);
        return Ok(response);
    }
}




















