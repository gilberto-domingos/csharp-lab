using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

public class Employee {
    public Guid Id { get; init; }
    public required string FirstName { get; set; } = string.Empty;
    public required string LastName { get; set; } = string.Empty;
    public required string Department { get; set; } = string.Empty;
    
    public Employee() {}

    [SetsRequiredMembers]
    public Employee(Guid id, string firstname, string lastName, string dept)
    {
        Id = id;
        FirstName = firstname;
        LastName = lastName;
        Department = dept;
    }
    
    public override string ToString() => $"{FirstName} {LastName}, ID:{Id} in {Department}";
}