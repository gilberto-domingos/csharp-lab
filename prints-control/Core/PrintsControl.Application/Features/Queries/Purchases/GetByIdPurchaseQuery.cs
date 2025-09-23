using MediatR;
using PrintsControl.Application.Dtos.Purchases;

namespace PrintsControl.Application.Features.Queries.Purchases;

public record GetByIdPurchaseQuery(Guid Id) : IRequest<PurchaseDto>;