using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DocumentoController : ControllerBase
{
    private readonly IDocumentoService _service;

    public DocumentoController(IDocumentoService service)
    {
        _service = service;
    }

    [HttpGet("validar/{numero}")]
    public ActionResult<Documento> ValidarDocumento(string numero)
    {
        var result = _service.Validar(numero);
        return Ok(result);
    }
}