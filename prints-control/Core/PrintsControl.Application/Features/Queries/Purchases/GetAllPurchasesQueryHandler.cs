using AutoMapper;
using MediatR;
using PrintsControl.Application.Dtos.Purchases;
using PrintsControl.Domain.Interfaces;

namespace PrintsControl.Application.Features.Queries.Purchases;

public class GetAllPurchasesQueryHandler : IRequestHandler<GetAllPurchasesQuery, List<PurchaseDto>>
{
    private readonly IPurchaseRepository _purchaseRepository;
    private readonly IMapper _mapper;

    public GetAllPurchasesQueryHandler(IPurchaseRepository purchaseRepository, IMapper mapper)
    {
        _purchaseRepository = purchaseRepository;
        _mapper = mapper;
    }
    
    public async Task<List<PurchaseDto>> Handle(GetAllPurchasesQuery request, CancellationToken cancellationToken)
    {
        var purchases = await _purchaseRepository.GetAllAsync(cancellationToken);
        return _mapper.Map<List<PurchaseDto>>(purchases);
    }
}