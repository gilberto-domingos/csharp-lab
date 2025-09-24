using MediatR;
using PrintsControl.Application.Dtos.PrintJobs;

namespace PrintsControl.Application.Features.Commands.PrintJobs;

public record CreatePrintJobCommand(Guid StudentId, int Quantity, DateTimeOffset PrintDate): IRequest<PrintJobDto>;