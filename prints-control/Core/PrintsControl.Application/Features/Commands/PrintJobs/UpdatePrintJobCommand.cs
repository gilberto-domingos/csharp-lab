using MediatR;
using PrintsControl.Application.Dtos.PrintJobs;

namespace PrintsControl.Application.Features.Commands.PrintJobs;

public sealed record UpdatePrintJobCommand(Guid Id, int Quantity, DateTimeOffset PrintDate) : IRequest<PrintJobDto>;