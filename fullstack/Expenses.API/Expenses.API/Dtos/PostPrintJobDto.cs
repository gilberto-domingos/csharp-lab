namespace Expenses.API.Dtos;

public class PostPrintJobDto
{
    public int StudentId { get; set; }
    public int Quantity { get; set; } // quantidade de páginas
    
    public DateTime PrintDate { get; set; } = DateTime.UtcNow;
}