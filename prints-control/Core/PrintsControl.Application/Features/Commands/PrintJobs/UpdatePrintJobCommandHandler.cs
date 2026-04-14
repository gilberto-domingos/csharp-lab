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
        var printJob = await _printJobRepository.GetByIdAsync(request.Id, cancellationToken);
        
        if (printJob is null)
            throw new ArgumentException($"Impressão com o código {request.Id} não encontrado");

        printJob.UpdateQuantity(request.Quantity);
        printJob.UpdatePrintDate();
        
        await _printJobRepository.UpdateAsync(printJob, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);
        
        return _mapper.Map<PrintJobDto>(printJob);
    }
}

