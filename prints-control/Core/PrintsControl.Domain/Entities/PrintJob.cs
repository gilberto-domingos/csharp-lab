using System.ComponentModel.DataAnnotations;

namespace PrintsControl.Domain.Entities;

public class PrintJob
{
    [Key]
    private int _printJobId;

    private int _quantity; 
    
    private DateTime _printDate = DateTime.UtcNow;

    private int _studentId;
    
    public Student? Student { get; set; } = null!;

    public int PrintJobId
    {
        get => _printJobId;
        set => _printJobId = value;
    }

    public int Quantity
    {
        get => _quantity;
        private set => SetQuantity(value);
    }

    public void SetQuantity(int quantity)
    {
        if (quantity < 0)
            throw new ArgumentException("A quantidade impressa deve ser maior que zero.");
        
        _quantity = quantity;
    }

    public override string ToString()
    {
        return $"Código da impressão:{_printJobId}, Quantidade{_quantity}, Data{_printDate}, Codigo do aluno:{_studentId}";
    }
}