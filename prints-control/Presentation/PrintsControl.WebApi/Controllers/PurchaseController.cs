using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrintsControl.Application.Dtos.PrintJobs;
using PrintsControl.Application.Dtos.Purchases;
using PrintsControl.Application.Features.Commands.Purchases;
using PrintsControl.Application.Features.Queries.Purchases;
using PrintsControl.Persistence.Context;

namespace PrintsControl.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PurchaseController : ControllerBase
{
    private IMediator _mediator;

    public PurchaseController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    /*[HttpGet("debug")]
    public async Task<IActionResult> DebugAsync([FromServices] AppDbContext db)
    {
        var purchases = await db.Purchases.ToListAsync();
        return Ok(purchases);
    }*/
    
    [HttpGet]
    public async Task<ActionResult<List<PurchaseDto>>> GetAllAsync(CancellationToken cancellationToken)
    {
        var request = new GetAllPurchasesQuery();
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<PurchaseDto>> GetById(Guid id,
        CancellationToken cancellationToken)
    {
        var request = new GetByIdPurchaseQuery(id);
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<PurchaseDto>> CreateAsync(CreatePurchaseCommand request,
        CancellationToken cancellationToken)
    {
        var purchase = await _mediator.Send(request, cancellationToken);
        return Ok(purchase);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<PurchaseDto>> UpdateAsync(Guid id, UpdatePurchaseCommand request,
        CancellationToken cancellationToken)
    {
        
        if (id != request.Id)
            return BadRequest();

        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<PurchaseDto>> Delete(Guid id, CancellationToken cancellationToken)
    {
        var command = new DeletePurchaseCommand(id);
        var response = await _mediator.Send(command, cancellationToken);
        return Ok(response);
    }
}
