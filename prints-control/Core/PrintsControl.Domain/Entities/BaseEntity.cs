namespace PrintsControl.Domain.Entities;

public class BaseEntity
{
    public Guid Id { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; } 
}