namespace PrintsControl.Domain.Entities;

public class Purchase : BaseEntity
{
    public Guid StudentId { get; private set; }
    public int QuantityPurchased { get; private set; }

    public Student Student { get; private set; }
    
    private Purchase() { }

    public Purchase(Guid studentId, int quantityPurchased)
    {
        if (quantityPurchased != 25 && quantityPurchased != 50)
            throw new ArgumentException("Somente pacotes de 25 ou 50 impressões são permitidas", nameof(quantityPurchased));

        StudentId = studentId;
        QuantityPurchased = quantityPurchased;
    }
    
    
}