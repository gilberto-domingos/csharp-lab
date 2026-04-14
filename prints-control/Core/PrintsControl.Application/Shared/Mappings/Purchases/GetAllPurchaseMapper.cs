using AutoMapper;
using PrintsControl.Application.Dtos.Purchases;
using PrintsControl.Application.Features.Queries.Purchases;
using PrintsControl.Domain.Entities;

namespace PrintsControl.Application.Shared.Mappings.Purchases;

public class GetAllPurchaseMapper : Profile
{
    public GetAllPurchaseMapper()
    {
        CreateMap<Purchase, PurchaseDto>();
        CreateMap<GetAllPurchasesQuery, Purchase>(); 
    }
}