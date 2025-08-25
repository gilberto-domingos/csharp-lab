using System;

namespace PrintsControl.Application.Dtos.Purchases;

public class PostPurchaseDto
{
    public int StudentId { get; set; }
    public int Quantity { get; set; } 
    public DateTime PurchaseDate { get; set; }
}
