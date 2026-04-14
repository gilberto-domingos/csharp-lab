using MediatR;
using PrintsControl.Application.Dtos.PrintJobs;

namespace PrintsControl.Application.Features.Queries.PrintJobs;

public sealed record GetAllPrintJobsQuery():IRequest<List<PrintJobDto>>;