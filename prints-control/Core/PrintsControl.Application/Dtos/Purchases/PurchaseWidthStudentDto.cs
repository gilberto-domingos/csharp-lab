namespace PrintsControl.Application.Dtos.Purchases;

public sealed record PurchaseWidthStudentDto(Guid Id, int Quantity, string StudentName, DateTimeOffset PurchaseDate);