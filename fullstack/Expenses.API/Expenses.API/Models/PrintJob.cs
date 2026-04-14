using System.ComponentModel.DataAnnotations;
using Expenses.API.Models.Base;

namespace Expenses.API.Models;

public class PrintJob 
{ 
    [Key]                     
    public int PrintJobId { get; set; }
    public int Quantity { get; set; } 
    public DateTime PrintDate { get; set; } = DateTime.UtcNow;

    public int StudentId { get; set; }
    public Student? Student { get; set; } = null!;
}