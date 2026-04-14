using AutoMapper;
using PrintsControl.Application.Dtos.PrintJobs;
using PrintsControl.Application.Features.Commands.PrintJobs;
using PrintsControl.Domain.Entities;

namespace PrintsControl.Application.Shared.Mappings.PrintJobs;

public sealed class UpdatePrintJobMapper : Profile
{
    public UpdatePrintJobMapper()
    {
        CreateMap<PrintJob, PrintJobDto>();
        CreateMap<UpdatePrintJobCommand, PrintJob>();
    }
}