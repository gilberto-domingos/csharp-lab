using AutoMapper;
using MediatR;
using PrintsControl.Application.Dtos.Purchases;
using PrintsControl.Domain.Interfaces;

namespace PrintsControl.Application.Features.Commands.Purchases;

public class DeletePurchaseCommandHandler : IRequestHandler<DeletePurchaseCommand, PurchaseDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPurchaseRepository _purchaseRepository;
    private readonly IMapper _mapper;

    public DeletePurchaseCommandHandler(IUnitOfWork unitOfWork, IPurchaseRepository purchaseRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _purchaseRepository = purchaseRepository;
        _mapper = mapper;
    }
    
    public async Task<PurchaseDto> Handle(DeletePurchaseCommand request, CancellationToken cancellationToken)
    {
        var purchase = await _purchaseRepository.GetByIdAsync(request.StudentId, cancellationToken);

        if (purchase is null)
            throw new ArgumentException("Compra do estudante não existe");
        
        purchase.DeletePrintDate(request.PrintDate);

        await _purchaseRepository.DeleteAsync(purchase, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);

        return _mapper.Map<PurchaseDto>(purchase);
    }
}

