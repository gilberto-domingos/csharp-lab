namespace PrintsControl.Domain.Entities;

public sealed class Student : BaseEntity
{
    private string _name;
    private int _printBalance;

    public string Name
    {
        get => _name;
        private set => SetName(value);
    }

    public int PrintBalance
    {
        get => _printBalance;
        private set => SetPrintBalance(value);
    }

    public ICollection<Purchase> Purchases { get; private set; }
    public ICollection<Printing> Printings { get; private set; }
    public ICollection<TransactionHistory> Transactions { get; private set; }

    private Student() { }

    public Student(string name, int initialBalance)
    {
        SetName(name);
        SetPrintBalance(initialBalance);
        
        Purchases = new List<Purchase>();
        Printings = new List<Printing>();
        Transactions = new List<TransactionHistory>();
    }

    public void SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("O nome do estudante é obrigatório.", nameof(name));

        if (name.Length < 3)
            throw new ArgumentException("O nome deve ter pelo menos 3 caracteres.", nameof(name));

        _name = name;
        MarkAsUpdated();
    }

    public void SetPrintBalance(int balance)
    {
        if (balance < 0)
            throw new ArgumentException("O saldo de impressões não pode ser negativo.", nameof(balance));

        _printBalance = balance;
        MarkAsUpdated();
    }

    public void AddPrints(int quantity)
    {
        if (quantity <= 0)
            throw new ArgumentException("A quantidade deve ser maior que zero.", nameof(quantity));

        _printBalance += quantity;
        MarkAsUpdated();
    }

    public override string ToString()
    {
        return $"Estudante: {_name} | Saldo de Impressões: {_printBalance}";
    }
}
