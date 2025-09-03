using Application.Interfaces;
using Domain.Entities;
using Domain.Services;

namespace Application.Services;

public class DocumentoService : IDocumentoService
{
    public Documento Validar(string numero)
    {
        var valido = CpfCnpjUtils.IsValid(numero);

        return new Documento
        {
            Numero = numero,
            Valido = valido
        };
    }
}