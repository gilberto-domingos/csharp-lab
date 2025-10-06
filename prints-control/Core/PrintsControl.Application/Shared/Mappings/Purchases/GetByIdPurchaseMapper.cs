using AutoMapper;
using PrintsControl.Application.Dtos.Purchases;
using PrintsControl.Application.Features.Queries.Purchases;
using PrintsControl.Domain.Entities;

namespace PrintsControl.Application.Shared.Mappings.Purchases;

public class GetByIdPurchaseMapper : Profile
{
    public GetByIdPurchaseMapper()
    {
        CreateMap<Purchase, PurchaseDto>();
        CreateMap<Purchase, PurchaseWidthStudentDto>();
        CreateMap<GetByIdPurchaseQuery, Purchase>();
    }
}