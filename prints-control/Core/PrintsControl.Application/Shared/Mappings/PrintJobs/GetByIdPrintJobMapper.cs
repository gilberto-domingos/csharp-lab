using AutoMapper;
using PrintsControl.Application.Dtos.PrintJobs;
using PrintsControl.Application.Features.Queries.PrintJobs;
using PrintsControl.Domain.Entities;

namespace PrintsControl.Application.Shared.Mappings.PrintJobs;

public sealed class GetByIdPrintJobMapper : Profile
{
    public GetByIdPrintJobMapper()
    {
        CreateMap<PrintJob, PrintJobDto>();
        CreateMap<PrintJob, PrintJobWidthStudentDto>();
        CreateMap<GetByIdPrintJobQuery, PrintJob>();
        CreateMap<GetByIdPrintJobQuery, PrintJob>();
    }
}