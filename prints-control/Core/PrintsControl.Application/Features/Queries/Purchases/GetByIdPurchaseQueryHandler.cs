using AutoMapper;
using MediatR;
using PrintsControl.Application.Dtos.Purchases;
using PrintsControl.Domain.Interfaces;

namespace PrintsControl.Application.Features.Queries.Purchases;

public class GetByIdPurchaseQueryHandler : IRequestHandler<GetByIdPurchaseQuery,PurchaseDto>
{
    private readonly IPurchaseRepository _repositoty;
    private readonly IMapper _mapper;

    public GetByIdPurchaseQueryHandler(IPurchaseRepository repository, IMapper mapper)
    {
        _repositoty = repository;
        _mapper = mapper;
    }
    
    public async Task<PurchaseDto> Handle(GetByIdPurchaseQuery request, CancellationToken cancellationToken)
    {
        var purchaseId = await _repositoty.GetByIdAsync(request.StudentId, cancellationToken);
        return _mapper.Map<PurchaseDto>(purchaseId);
    }
}