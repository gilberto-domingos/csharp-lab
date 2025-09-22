using AutoMapper;
using MediatR;
using PrintsControl.Application.Dtos.Purchases;
using PrintsControl.Domain.Interfaces;

namespace PrintsControl.Application.Features.Commands.Purchases;

public class UpdatePurchaseCommandHandler : IRequestHandler<UpdatePurchaseCommand, PurchaseDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPurchaseRepository _purchaseRepository;
    private readonly IMapper _mapper;

    public UpdatePurchaseCommandHandler(IUnitOfWork unitOfWork, IPurchaseRepository purchaseRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _purchaseRepository = purchaseRepository;
        _mapper = mapper;
    }
    
    public async Task<PurchaseDto> Handle(UpdatePurchaseCommand request, CancellationToken cancellationToken)
    {
        var purchase = await _purchaseRepository.GetByIdAsync(request.StudentId, cancellationToken);

        if (purchase is null)
            throw new ArgumentException("Compra do estudante não encontrada");

        await _purchaseRepository.UpdateAsync(purchase, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);

        return _mapper.Map<PurchaseDto>(purchase);
    }
}