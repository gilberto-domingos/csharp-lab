using MediatR;
using PrintsControl.Application.Dtos.Purchases;

namespace PrintsControl.Application.Features.Queries.Purchases;

public sealed record GetByIdPurchaseQuery(Guid Id): IRequest<PurchaseWidthStudentDto>;