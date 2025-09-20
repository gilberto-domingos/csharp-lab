namespace PrintsControl.Application.Dtos;
public sealed record StudentHistoryDto(
    Guid StudentId,
    string Name,
    int Balance,
    int TotalPurchase,
    int TotalPrints,
    IReadOnlyList<DateTimeOffset> PurchaseDates,
    IReadOnlyList<DateTimeOffset> PrintsDates
);
