var hourlyEmp = new HourlyEmployee
{
    Id = 1,
    FullName = "Jane Deaux",
    Department = "Sales",
    PayRate = 50.00m
};

var salariedEmp = new SalariedEmployee
{
    Id = 2,
    FullName = "William Jackson",
    Department = "Technology",
    Salary = 60000.00m
};

Console.WriteLine("Before Pay Adjustment:");
Console.WriteLine(hourlyEmp);
Console.WriteLine(salariedEmp);

// ajuste salarial de 10%
hourlyEmp.AdjustPay(10);
salariedEmp.AdjustPay(5);

Console.WriteLine("\nAfter Pay Adjustment:");
Console.WriteLine(hourlyEmp);
Console.WriteLine(salariedEmp);

