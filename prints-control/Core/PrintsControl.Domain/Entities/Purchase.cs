using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PrintsControl.Domain.Entities;

public class Purchase : BaseEntity
{
    public Guid StudentId { get; private set; }
    
    [JsonIgnore]
    public Student? Student { get; set; } = null!;
     
    public int Quantity { get; private set; }
    
    public DateTimeOffset PurchaseDate { get; private set; } = DateTimeOffset.UtcNow;

    
    protected Purchase(){}

    public Purchase(Guid studentId, int quantity, DateTimeOffset purchaseDate)
    {
        StudentId = studentId;
        Quantity = quantity;
        PurchaseDate = purchaseDate;
    }
}