namespace PrintsControl.Domain.Entities;

public class Student : BaseEntity
{
    private string _name;
    private int _balance = 0; 
    public ICollection<Purchase> Purchases { get; private set; } = new List<Purchase>();
    public ICollection<PrintJob> PrintJobs { get; private set; } = new List<PrintJob>();

    public String Name
    {
        get => _name;
        private set => SetName(value);
    }
    public int Balance
    {
        get => _balance;
        private set => SetBalance(value);
    }

    public void SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("O nome é obrigatório", nameof(name));

        if (name.Length < 3)
            throw new ArgumentException("O nome deve ter mais do que 3 caracteres");

        _name = name;
    }

    public void SetBalance(int balance)
    {
        if (balance < 0)
            throw new ArgumentException("O saldo não pode ser negativo", nameof(balance));
        
        _balance = balance;
    }

    public override string ToString()
    {
        return $"Estudante: {_name} | Saldo de impressões: {_balance}";
    }
}