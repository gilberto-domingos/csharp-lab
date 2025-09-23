using AutoMapper;
using MediatR;
using PrintsControl.Application.Dtos.PrintJobs;
using PrintsControl.Domain.Interfaces;

namespace PrintsControl.Application.Features.Queries.PrintJobs;

public class GetByIdPrintJobQueryHandler:IRequestHandler<GetByIdPrintJobQuery,PrintJobDto>
{
    private readonly IPrintJobRepository _repository;
    private readonly IMapper _mapper;

    public GetByIdPrintJobQueryHandler(IPrintJobRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    public async Task<PrintJobDto> Handle(GetByIdPrintJobQuery request, CancellationToken cancellationToken)
    {
        var printJobId = await _repository.GetByIdAsync(request.Id, cancellationToken);
        return _mapper.Map<PrintJobDto>(printJobId);
    }
}