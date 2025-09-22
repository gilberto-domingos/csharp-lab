using AutoMapper;
using MediatR;
using PrintsControl.Application.Dtos.PrintJobs;
using PrintsControl.Domain.Interfaces;

namespace PrintsControl.Application.Features.Commands.PrintJobs;

public class UpdatePrintJobCommandHandler : IRequestHandler<UpdatePrintJobCommand, PrintJobDto>
{
    private IUnitOfWork _unitOfWork;
    private IPrintJobRepository _printJobRepository;
    private IMapper _mapper;

    public UpdatePrintJobCommandHandler(IUnitOfWork unitOfWork, IPrintJobRepository printJobRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _printJobRepository = printJobRepository;
        _mapper = mapper;
    }
    
    public async Task<PrintJobDto> Handle(UpdatePrintJobCommand request, CancellationToken cancellationToken)
    {
        var printJob = await _printJobRepository.GetByIdAsync(request.StudentId, cancellationToken);
        
        await _printJobRepository.UpdateAsync(printJob, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);
        
        return _mapper.Map<PrintJobDto>(printJob);
        
    }
}

