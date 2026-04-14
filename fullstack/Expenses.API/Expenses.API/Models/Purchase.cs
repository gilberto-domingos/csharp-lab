using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Expenses.API.Models.Base;

namespace Expenses.API.Models;

public class Purchase 
{
    [Key]                     
    public int PurchaseId { get; set; }
    public int Quantity { get; set; } 
    public DateTime PurchaseDate { get; set; } = DateTime.UtcNow;

    public int StudentId { get; set; }
    
    [JsonIgnore]
    public Student? Student { get; set; } = null!;
}