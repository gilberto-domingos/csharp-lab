using MediatR;
using PrintsControl.Application.Dtos.PrintJobs;

namespace PrintsControl.Application.Features.Commands.PrintJobs;

public record DeletePrintJobCommand(Guid Id, DateTimeOffset PrintDate):IRequest<PrintJobDto>;