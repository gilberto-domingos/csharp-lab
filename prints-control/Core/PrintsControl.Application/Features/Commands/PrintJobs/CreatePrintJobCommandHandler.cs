using AutoMapper;
using MediatR;
using PrintsControl.Application.Dtos.PrintJobs;
using PrintsControl.Domain.Entities;
using PrintsControl.Domain.Interfaces;

namespace PrintsControl.Application.Features.Commands.PrintJobs;

public class CreatePrintJobCommandHandler : IRequestHandler<CreatePrintJobCommand,PrintJobDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPrintJobRepository _printJobRepository;
    private readonly IMapper _mapper;

    public CreatePrintJobCommandHandler(IUnitOfWork unitOfWork, IPrintJobRepository prinJobRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _printJobRepository = prinJobRepository;
        _mapper = mapper;
    }
    
    public async Task<PrintJobDto> Handle(CreatePrintJobCommand request, CancellationToken cancellationToken)
    {
        var printJob = _mapper.Map<PrintJob>(request);

        await _printJobRepository.CreateAsync(printJob, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);

        return _mapper.Map<PrintJobDto>(printJob);
    }
}