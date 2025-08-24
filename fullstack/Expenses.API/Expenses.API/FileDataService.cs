using System.Globalization;

public class FileDataService
{
    private readonly string _filePath = "data.csv";

    public FileDataService()
    {
        if (!File.Exists(_filePath))
        {
            File.WriteAllText(_filePath, "Id,Name,Amount\n");
        }
    }

    public List<Expense> GetAll()
    {
        var lines = File.ReadAllLines(_filePath).Skip(1); // pula cabeçalho
        return lines.Select(line =>
        {
            var parts = line.Split(',');
            return new Expense
            {
                Id = int.Parse(parts[0]),
                Name = parts[1],
                Amount = decimal.Parse(parts[2], CultureInfo.InvariantCulture)
            };
        }).ToList();
    }

    public void Add(Expense expense)
    {
        var nextId = GetAll().Count + 1;
        expense.Id = nextId;
        File.AppendAllText(_filePath, $"{expense.Id},{expense.Name},{expense.Amount.ToString(CultureInfo.InvariantCulture)}\n");
    }
}

public class Expense
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Amount { get; set; }
}