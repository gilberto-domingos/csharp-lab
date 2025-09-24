using System;

namespace PrintsControl.Application.Dtos.Purchases;

public sealed record PurchaseDto(Guid StudentId, int Quantity, DateTimeOffset PurchaseDate);


