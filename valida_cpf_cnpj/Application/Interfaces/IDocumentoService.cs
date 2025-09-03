using Domain.Entities;

namespace Application.Interfaces;

public interface IDocumentoService
{
    Documento Validar(string numero);
}