using AutoMapper;
using MediatR;
using PrintsControl.Application.Dtos.PrintJobs;
using PrintsControl.Domain.Interfaces;

namespace PrintsControl.Application.Features.Queries.PrintJobs;

public class GetAllPrintJobsQueryHandler : IRequestHandler<GetAllPrintJobsQuery,List<PrintJobDto>>
{
    private readonly IPrintJobRepository _printJobRepository;
    private readonly IMapper _mapper;

    public GetAllPrintJobsQueryHandler(IPrintJobRepository printJobRepository, IMapper mapper)
    {
        _printJobRepository = printJobRepository;
        _mapper = mapper;
    }
    
    public async Task<List<PrintJobDto>> Handle(GetAllPrintJobsQuery request, CancellationToken cancellationToken)
    {
        var printJobs = await _printJobRepository.GetAllAsync(cancellationToken);
        return _mapper.Map<List<PrintJobDto>>(printJobs);
    }
}