namespace PrintsControl.Domain.Entities;

public class Transaction : BaseEntity
{
    private string _type;
    private double _amount = 0;
    private string _category;
    
    public Guid? UserId { get; set; }
    public User User { get; set; } = null!;

    public string Type
    {
        get => _type;
        set => _type = value;
    }

    public double Amount
    {
        get => _amount;
        set => _amount = value;
    }

    public string Category
    {
        get => _category;
        set => _category = value;
    }

    public Transaction(string type, double amount, string category)
    {
        if (string.IsNullOrWhiteSpace(type))
            throw new ArgumentException("O tipo é obrigatório.", nameof(type));
        
        if ( amount == 0)
            throw new ArgumentException("O valor é obrigatório.", nameof(amount));

        if (string.IsNullOrWhiteSpace(category))
            throw new ArgumentException("A categoria é obrigatória.", nameof(category));
        
        _type = type;
        _amount = amount;
        _category = category;
    }
}