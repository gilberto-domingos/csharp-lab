public abstract class Employee
{
    public required int Id { get; init; }
    public required string Department { get; set; } = string.Empty;
    public required string FullName { get; set; } = string.Empty;

    public abstract void AdjustPay(decimal percentage);

    public override string ToString() => $"{FullName}, ID: {Id}, Department: {Department}";
}


public class HourlyEmployee : Employee
{
    public decimal PayRate { get; set; }

    public override void AdjustPay(decimal percentage)
    {
        PayRate += PayRate * (percentage / 100);
    }

    public override string ToString() =>
        $"{base.ToString()}, Hourly PayRate: {PayRate:C}";
}

// Funcionário assalariado
public class SalariedEmployee : Employee
{
    public decimal Salary { get; set; }

    public override void AdjustPay(decimal percentage)
    {
        Salary += Salary * (percentage / 100);
    }

    public override string ToString() =>
        $"{base.ToString()}, Salary: {Salary:C}";
}