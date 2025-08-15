namespace PrintsControl.Domain.Entities;

public class TransactionHistory : BaseEntity
{
    public Guid StudentId { get; private set; }
    public string TransactionType { get; private set; }
    public int Quantity { get; private set; }
    public int BalanceBefore { get; private set; }
    public int BalanceAfter { get; private set; }

    public Student Student { get; private set; }
    
    private TransactionHistory() { }

    public TransactionHistory(Guid studentId, string transactionType, int quantity, int balanceBefore, int balanceAfter)
    {
        if (string.IsNullOrWhiteSpace(transactionType))
            throw new ArgumentNullException(nameof(transactionType));

        if (quantity <= 0)
            throw new ArgumentException("A quantidade deve ser maior que zero.", nameof(quantity));

        StudentId = studentId;
        TransactionType = transactionType;
        Quantity = quantity;
        BalanceBefore = balanceBefore;
        BalanceAfter = balanceAfter;
    }
}