public class Employee {
    public Guid Id { get; init; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    
    public string Department { get; set; } = string.Empty;
    
    public Employee() {}

    public Employee(Guid id, string firstname, string lastName, string dept)
    {
        Id = id;
        FirstName = firstname;
        LastName = lastName;
        Department = dept;
    }
    
    public override string ToString() => $"{FirstName} {LastName}, ID:{Id} in {Department}";
}
