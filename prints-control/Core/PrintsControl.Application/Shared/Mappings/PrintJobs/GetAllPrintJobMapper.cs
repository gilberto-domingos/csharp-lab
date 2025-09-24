using AutoMapper;
using PrintsControl.Application.Dtos.PrintJobs;
using PrintsControl.Application.Features.Queries.PrintJobs;
using PrintsControl.Domain.Entities;

namespace PrintsControl.Application.Shared.Mappings.PrintJobs;

public sealed class GetAllPrintJobMapper : Profile
{
    public GetAllPrintJobMapper()
    {
        CreateMap<PrintJob, PrintJobDto>();
        CreateMap<GetAllPrintJobsQuery, PrintJob>();
    }
}