using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PrintsControl.Domain.Entities;

public class Purchase
{
    [Key] 
    private int _purchaseId;
   
    private int _quantity;
    
    private DateTime _purchaseDate = DateTime.UtcNow;

    private int _studentId;
    
    [JsonIgnore]
    public Student? Student { get; set; } = null!;

    public int PurchaseId
    {
        get => _purchaseId;
        set => _purchaseId = value;
    }

    public int Quantity
    {
        get => _quantity;
        set => _quantity = value;
    }

    public DateTime PurchaseDate
    {
        get => _purchaseDate;
        set => _purchaseDate = value;
    }

    public int StudentId
    {
        get => _studentId;
        set => _studentId = value;
    }

    public Purchase(int studentId, int quantity)
    {
        if (quantity != 25 && quantity!= 50)
            throw new ArgumentException("Somente pacotes de 25 ou 50 impressões são permitidas", nameof(quantity));

        _studentId = studentId;
        _quantity = quantity;
    }
}