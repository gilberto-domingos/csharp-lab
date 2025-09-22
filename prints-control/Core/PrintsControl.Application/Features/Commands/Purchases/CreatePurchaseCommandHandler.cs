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
    private readonly IMapper _mapper;

    public CreatePurchaseCommandHandler(IUnitOfWork unitOfWork, IPurchaseRepository purchaseRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _purchaseRepository = purchaseRepository;
        _mapper = mapper;
    }
    
    public async Task<PurchaseDto> Handle(CreatePurchaseCommand request, CancellationToken cancellationToken)
    {
        var purchase = _mapper.Map<Purchase>(request);

        await _purchaseRepository.CreateAsync(purchase, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);

        return _mapper.Map<PurchaseDto>(purchase);
    }
}