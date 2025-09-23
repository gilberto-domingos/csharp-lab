using MediatR;
using PrintsControl.Application.Dtos.Purchases;

namespace PrintsControl.Application.Features.Commands.Purchases;

public sealed record UpdatePurchaseCommand(Guid Id, int Quantity, DateTimeOffset PurchaseDate) : IRequest<PurchaseDto>;