using AutoMapper;
using MediatR;
using PrintsControl.Application.Dtos.Purchases;
using PrintsControl.Domain.Interfaces;

namespace PrintsControl.Application.Features.Queries.Purchases;

public class GetByIdPurchaseQueryHandler : IRequestHandler<GetByIdPurchaseQuery,PurchaseWidthStudentDto>
{
    private readonly IPurchaseRepository _purchaseRepository;
    private readonly IMapper _mapper;

    public GetByIdPurchaseQueryHandler(IPurchaseRepository purchaseRepository, IMapper mapper)
    {
        _purchaseRepository = purchaseRepository;
        _mapper = mapper;
    }
    
    public async Task<PurchaseWidthStudentDto> Handle(GetByIdPurchaseQuery request, CancellationToken cancellationToken)
    {
        var purchase = await _purchaseRepository.GetByIdWidthStudent(request.Id, cancellationToken);
        
        if(purchase == null)
            throw new ArgumentException($"A impressão com o código {request.Id} não foi encontrada"); 
        
        return _mapper.Map<PurchaseWidthStudentDto>(purchase);
    }
}