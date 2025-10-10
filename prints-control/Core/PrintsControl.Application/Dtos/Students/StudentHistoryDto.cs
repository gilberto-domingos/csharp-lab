namespace PrintsControl.Application.Dtos;

public sealed record StudentHistoryDto(
    Guid StudentId,
    DateTimeOffset CreatedAt,
    string Name,
    int Balance,
    int TotalPurchase,
    int TotalPrints,
    ICollection<DateTimeOffset> PurchaseDates,
    ICollection<DateTimeOffset> PurchaseCreatedAt,
    ICollection<DateTimeOffset> PurchaseUpdatedAt,
    ICollection<DateTimeOffset> PurchaseDeletedAt,
    ICollection<DateTimeOffset> PrintDates,
    ICollection<DateTimeOffset> PrintCreatedAt,
    ICollection<DateTimeOffset> PrintUpdatedAt,
    ICollection<DateTimeOffset> PrintDeletedAt
);

