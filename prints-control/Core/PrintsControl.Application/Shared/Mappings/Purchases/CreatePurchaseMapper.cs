using AutoMapper;
using PrintsControl.Application.Dtos.Purchases;
using PrintsControl.Application.Features.Commands.Purchases;
using PrintsControl.Domain.Entities;

namespace PrintsControl.Application.Shared.Mappings.Purchases;

public sealed class CreatePurchaseMapper : Profile
{
    public CreatePurchaseMapper()
    {
        CreateMap<Purchase, PurchaseDto>();
        CreateMap<CreatePurchaseCommand, Purchase>();
    }
}