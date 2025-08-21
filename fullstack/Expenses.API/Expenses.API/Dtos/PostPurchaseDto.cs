using Expenses.API.Models;

namespace Expenses.API.Dtos;

public class PostPurchaseDto
{
    public int StudentId { get; set; }
    public int Quantity { get; set; } // só pode 25 ou 50
    public DateTime PurchaseDate { get; set; }
}
