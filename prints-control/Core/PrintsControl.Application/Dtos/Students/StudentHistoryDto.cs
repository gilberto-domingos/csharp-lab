namespace PrintsControl.Application.Dtos;

public class StudentHistoryDto
{
    public Guid StudentId { get; set; }
    public string Name { get; set; }
    public int Balance { get; set; }
    public int TotalPurchase { get; set; }
    public int TotalPrints { get; set; }
    public List<DateTimeOffset> PurchaseDate { get; set; } = new List<DateTimeOffset>();
    public List<DateTimeOffset> PrintsDates { get; set; } = new List<DateTimeOffset>();
}