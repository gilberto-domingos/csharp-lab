namespace PrintsControl.Domain.Entities;

public class Student : BaseEntity
{
    public string Name { get; private set;}
    public int Balance { get; private set; } = 0;
    public ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
    public ICollection<PrintJob> PrintJobs { get; set; } = new List<PrintJob>();
    
    protected Student(){}

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

    public void UpdateName(string name)
    {
        if (name.Length < 3)
            throw new ArgumentException("O nome deve ter mais do que 3 caracteres");
        
        Name = name;
        MarkAsUpdated();
    }

    public Purchase BuyPackage(int quantity, DateTimeOffset purchaseDate)
    {
        if (quantity != 25 && quantity != 50)
            throw new ArgumentException("Permitido compras somente pacote de 25 ou 50");

        Balance += quantity;
        var purchase = new Purchase(Id, quantity, purchaseDate);
        return purchase;
    }


    public PrintJob PrintWork(int quantity, DateTimeOffset printDate)
    {
        if (Balance < quantity)
            throw new InvalidOperationException("Saldo insuficiente para realizar impressões");

        Balance -= quantity;

        var printJob = new PrintJob(Id, quantity, printDate);
        PrintJobs.Add(printJob);

        return printJob;
    }

    
    public override string ToString() =>
        $"Código: {Id} |  Estudante: {Name} | Saldo de impressões: {Balance}";
}