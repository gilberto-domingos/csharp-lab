using RabbitMQ.Bus;
using RabbitMQ.Relatorios;
using Microsoft.AspNetCore.Mvc;

namespace RabbitMQ.Controllers;

[ApiController]
[Route("api/[Controller]")]
internal static class ApiEndpoints
{
    public static void AddApiEndPoints(this WebApplication app)
    {
        app.MapPost("solicitar-relatorio/{name}", async (string name, IBusPublish bus, CancellationToken ct = default) =>
        {
            var solicitacao = new SolicitacaoRelatorios()
            {
                Id = Guid.NewGuid(),
                Nome = name,
                Status = "Pendente",
                ProcessedTime = null
            };
            
            Lista.Relatorios.Add(solicitacao);

            var eventRequest = new RelatorioSolicitadoEvent(solicitacao.Id, solicitacao.Nome);

            await bus.publishAsync(eventRequest, ct);

            return Results.Ok(solicitacao);
        });

        app.MapGet("relatorios", () => Lista.Relatorios);
    }
}