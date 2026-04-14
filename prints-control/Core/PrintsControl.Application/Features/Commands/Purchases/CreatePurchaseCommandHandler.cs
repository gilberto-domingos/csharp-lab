using AutoMapper;
using MediatR;
using PrintsControl.Application.Dtos.Purchases;
using PrintsControl.Domain.Entities;
using PrintsControl.Domain.Interfaces;

namespace PrintsControl.Application.Features.Commands.Purchases;

public class CreatePurchaseCommandHandler : IRequestHandler<CreatePurchaseCommand, PurchaseDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPurchaseRepository _purchaseRepository;
    private readonly IStudentRepository _studentRepository;
    private readonly IMapper _mapper;

    public CreatePurchaseCommandHandler(IUnitOfWork unitOfWork, IPurchaseRepository purchaseRepository, IStudentRepository studentRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _purchaseRepository = purchaseRepository;
        _studentRepository = studentRepository;
        _mapper = mapper;
    }
    
    public async Task<PurchaseDto> Handle(CreatePurchaseCommand request, CancellationToken cancellationToken)
    {
        var student = await _studentRepository.GetByIdAsync(request.StudentId, cancellationToken);
        if (student == null)
            throw new Exception($"Estudante com ID {request.StudentId} não encontrado.");

        var purchase = student.BuyPackage(request.Quantity, request.PurchaseDate);

        await _purchaseRepository.CreateAsync(purchase, cancellationToken);

        await _unitOfWork.CommitAsync(cancellationToken);

        return _mapper.Map<PurchaseDto>(purchase);
    }


}