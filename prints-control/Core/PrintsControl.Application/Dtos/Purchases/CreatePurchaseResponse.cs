using System;

namespace PrintsControl.Application.Dtos.Purchases
{
    public sealed record CreatePurchaseResponse(Guid Id, Guid StudentId, int QuantityPurchased, DateTimeOffset CreatedAt);
}