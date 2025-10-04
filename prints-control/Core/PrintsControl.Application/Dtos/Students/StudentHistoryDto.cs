namespace PrintsControl.Application.Dtos;
public sealed record StudentHistoryDto(
    Guid StudentId,
    string Name,
    int Balance,
    int TotalPurchase,
    int TotalPrints,
    ICollection<DateTimeOffset> PurchaseDates,
    ICollection<DateTimeOffset> PrintsDates
);
