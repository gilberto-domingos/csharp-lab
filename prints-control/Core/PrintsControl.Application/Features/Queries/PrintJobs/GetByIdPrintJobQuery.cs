using MediatR;
using PrintsControl.Application.Dtos.PrintJobs;

namespace PrintsControl.Application.Features.Queries.PrintJobs;

public sealed record GetByIdPrintJobQuery(Guid Id): IRequest<PrintJobWidthStudentDto>;