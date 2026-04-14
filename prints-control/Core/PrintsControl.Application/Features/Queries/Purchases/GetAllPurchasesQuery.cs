using MediatR;
using PrintsControl.Application.Dtos.Purchases;

namespace PrintsControl.Application.Features.Queries.Purchases;

public sealed record GetAllPurchasesQuery(): IRequest<List<PurchaseDto>>;