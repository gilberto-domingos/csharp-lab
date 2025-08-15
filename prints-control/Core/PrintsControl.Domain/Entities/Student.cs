namespace PrintsControl.Domain.Entities;

public class Student : BaseEntity
{
    public string Name { get; private set; }
    public int PrintBalance { get; private set; }

    public ICollection<Purchase> Purchases { get; private set; }
    public ICollection<Printing> Printings { get; private set; }
    public ICollection<TransactionHistory> Transactions { get; private set; }
    
    private Student() { }

    public Student(string name)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        PrintBalance = 0;
        Purchases = new List<Purchase>();
        Printings = new List<Printing>();
        Transactions = new List<TransactionHistory>();
    }
    
    public void AddPrints(int quantity)
    {
        if (quantity <= 0)
            throw new ArgumentException("Quantity must be greater than zero.", nameof(quantity));

        PrintBalance += quantity;
        MarkAsUpdated();
    }

    public void RemovePrints(int quantity)
    {
        if (quantity <= 0)
            throw new ArgumentException("Quantity must be greater than zero.", nameof(quantity));

        if (PrintBalance < quantity)
            throw new InvalidOperationException("Insufficient balance.");

        PrintBalance -= quantity;
        MarkAsUpdated();
    }
}
