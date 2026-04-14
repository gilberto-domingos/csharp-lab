public class Employee
{
    private static int _employeeCount = 0;
    protected static int IdStart;

    static Employee()
    {
        IdStart = 1000;
    }

    public Employee()
    {
        ID = IdStart + _employeeCount;
       _employeeCount++;
    }

    public static int EmployeeCount => _employeeCount;
    public int ID { get; init; }
    public required string FullName { get; set; }
    public required string Department { get; set; }

    

    public override string ToString() => $"{ID}:{FullName}, {Department} ";
    public virtual void AdjustPay(decimal percentage) { }
}



public class HourlyEmployee : Employee
{
    public HourlyEmployee() {}

    public decimal PayRate { get; set; }

    public override void AdjustPay(decimal percentage)
    {
        PayRate += (PayRate * percentage);
    }
}


public class SalariedEmployee : Employee
{
    public SalariedEmployee() {}

    public decimal Salary { get; set; }

    public override void AdjustPay(decimal percentage)
    {
        Salary += (Salary * percentage);
    }
}
