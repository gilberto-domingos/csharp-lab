using AutoMapper;
using MediatR;
using PrintsControl.Application.Dtos.PrintJobs;
using PrintsControl.Domain.Interfaces;

namespace PrintsControl.Application.Features.Queries.PrintJobs;

public class GetByIdPrintJobQueryHandler:IRequestHandler<GetByIdPrintJobQuery,PrintJobWidthStudentDto>
{
    private readonly IPrintJobRepository _printJobRepository;
    private readonly IMapper _mapper;

    public GetByIdPrintJobQueryHandler(IPrintJobRepository printJobRepository, IMapper mapper)
    {
        _printJobRepository = printJobRepository;
        _mapper = mapper;
    }
    
    public async Task<PrintJobWidthStudentDto> Handle(GetByIdPrintJobQuery request, CancellationToken cancellationToken)
    {
        var printJob = await _printJobRepository.GetByIdWidthStudent(request.Id, cancellationToken);
        
        if (printJob == null)
            throw new ArgumentException($"A impressão com o código {request.Id} não foi encontrada"); 
        
        return _mapper.Map<PrintJobWidthStudentDto>(printJob);
    }
}