namespace PrintsControl.Domain.Entities;

public class Student : BaseEntity
{
    public string Name { get; private set;}
    public int Balance { get; private set; } = 0;

    private readonly List<Purchase> _purchases = new();
    public IReadOnlyCollection<Purchase> Purchases => _purchases.AsReadOnly();

    private readonly List<PrintJob> _printJobs = new();
    public IReadOnlyCollection<PrintJob> PrintJobs => _printJobs.AsReadOnly();

    public Student(string name, int balance)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("O nome é obrigatório");

        if (name.Length < 3)
            throw new ArgumentException("O nome deve ter mais do que 3 caracteres");

        if (balance < 0)
            throw new ArgumentException("O saldo não pode ser negativo", nameof(balance));

        Name = name;
        Balance = balance;
    }

    public void BuyPackage(int quantity)
    {
        if (quantity != 25 && quantity != 50)
            throw new ArgumentException("Permitido compras somente pacote de 25 ou 50");

        Balance += quantity;
        _purchases.Add(new Purchase(Id, quantity));
    }

    public override string ToString() =>
        $"Código: {Id} |  Estudante: {Name} | Saldo de impressões: {Balance}";
}