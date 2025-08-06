namespace PrintsControl.Domain.Entities;

public class Transaction : BaseEntity
{
    private string _type;
    private double _amount;
    private string _category;
    
    public int? UserId { get; }
    public User User { get; set; } = null!;  
}