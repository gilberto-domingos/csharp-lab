using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PrintsControl.Domain.Entities;

public class Purchase : BaseEntity
{

    public Guid Id { get; private set; } = Guid.NewGuid();
    public Guid StudentId { get; private set; }
     
   public int Quantity { get; private set; }
    
    public DateTime PurchaseDate { get; private set; } = DateTime.UtcNow;

    
    [JsonIgnore]
    public Student? Student { get; set; } = null!;
    
    public Purchase(){}

    public Purchase(Guid studentId, int quantity)
    {
        StudentId = studentId;
        Quantity = quantity;
    }
    
}