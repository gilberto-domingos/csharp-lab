using AutoMapper;
using MediatR;
using PrintsControl.Application.Dtos.PrintJobs;
using PrintsControl.Domain.Interfaces;

namespace PrintsControl.Application.Features.Queries.PrintJobs;

public class GetAllPrintJobsQueryHandler : IRequestHandler<GetAllPrintJobsQuery,List<PrintJobDto>>
{
    private readonly IPrintJobRepository _repository;
    private readonly IMapper _mapper;    
    
    public async Task<List<PrintJobDto>> Handle(GetAllPrintJobsQuery request, CancellationToken cancellationToken)
    {
        var printJobs = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<List<PrintJobDto>>(printJobs);
    }
}