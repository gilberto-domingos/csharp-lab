using Expenses.API.Models.Base;

namespace Expenses.API.Models;

public class Student 
{
    public int Id { get; set; } 
    public string Name { get; set; } = string.Empty;
    public int Balance { get; set; } = 0; // saldo de impressões

    public ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
    public ICollection<PrintJob> PrintJobs { get; set; } = new List<PrintJob>();
}