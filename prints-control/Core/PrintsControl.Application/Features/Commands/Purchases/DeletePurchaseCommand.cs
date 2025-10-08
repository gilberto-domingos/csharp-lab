using MediatR;
using PrintsControl.Application.Dtos.Purchases;

namespace PrintsControl.Application.Features.Commands.Purchases;

public sealed record DeletePurchaseCommand(Guid StudentId, DateTimeOffset PrintDate) : IRequest<PurchaseDto>;