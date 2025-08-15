namespace PrintsControl.Domain.Entities;

public class Printing : BaseEntity
{
    public Guid StudentId { get; private set; }
    public int QuantityPrinted { get; private set; }

    public Student Student { get; private set; }
    
    private Printing() { }

    public Printing(Guid studentId, int quantityPrinted, int currentBalance)
    {
        if (quantityPrinted <= 0)
            throw new ArgumentException("A quantidade impressa deve ser maior que zero.", nameof(quantityPrinted));

        if (currentBalance < quantityPrinted)
            throw new InvalidOperationException("Saldo insuficiente para impressão.");

        StudentId = studentId;
        QuantityPrinted = quantityPrinted;
    }
}