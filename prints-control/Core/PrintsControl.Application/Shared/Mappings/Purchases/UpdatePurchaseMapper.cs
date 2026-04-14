using AutoMapper;
using PrintsControl.Application.Dtos.Purchases;
using PrintsControl.Application.Features.Commands.Purchases;
using PrintsControl.Domain.Entities;

namespace PrintsControl.Application.Shared.Mappings.Purchases;

public sealed class UpdatePurchaseMapper : Profile
{
    public UpdatePurchaseMapper()
    {
        CreateMap<Purchase, PurchaseDto>();
        CreateMap<UpdatePurchaseCommand, Purchase>();
    }
}