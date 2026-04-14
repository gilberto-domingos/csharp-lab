using System;

namespace PrintsControl.Application.Dtos.Purchases;

public sealed record PurchaseDto(Guid Id, int Quantity, DateTimeOffset PurchaseDate);


