using AutoMapper;
using PrintsControl.Application.Dtos.PrintJobs;
using PrintsControl.Application.Features.Commands.PrintJobs;
using PrintsControl.Domain.Entities;

namespace PrintsControl.Application.Shared.Mappings.PrintJobs;

public sealed class CreatePrintJobMapper : Profile
{
    public CreatePrintJobMapper()
    {
        CreateMap<PrintJob, PrintJobDto>();
        CreateMap<CreatePrintJobCommand, PrintJob>();
    }
}