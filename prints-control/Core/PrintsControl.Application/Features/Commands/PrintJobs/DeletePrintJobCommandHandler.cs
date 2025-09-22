using AutoMapper;
using MediatR;
using PrintsControl.Application.Dtos.PrintJobs;
using PrintsControl.Domain.Interfaces;

namespace PrintsControl.Application.Features.Commands.PrintJobs;

public class DeletePrintJobCommandHandler : IRequestHandler<DeletePrintJobCommand,PrintJobDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPrintJobRepository _printJobRepository;
    private readonly IMapper _mapper;

    public DeletePrintJobCommandHandler(IUnitOfWork unitOfWork, IPrintJobRepository printJobRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _printJobRepository = printJobRepository;
        _mapper = mapper;
    }
    
    public async Task<PrintJobDto> Handle(DeletePrintJobCommand request, CancellationToken cancellationToken)
    {
        var printJob = await _printJobRepository.GetByIdAsync(request.StudentId, cancellationToken);

        if (printJob is null)
            throw new ArgumentException("Impressão do aluno não encontrada");

        await _printJobRepository.DeleteAsync(printJob, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);

        return _mapper.Map<PrintJobDto>(printJob);
    }
}