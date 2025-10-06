using PrintsControl.Domain.Entities;
using PrintsControl.Persistence.Context;


namespace PrintsControl.Persistence.Infrastructure.Seeds;

public static class DbSeeder
{
    public static void Seed(AppDbContext context)
    {
        if (context.Students.Any()) return; 
        
        var students = new List<Student>
        {
            new Student("Roberto Pires", 50),
            new Student("Alan Vemuth", 25),
            new Student("Mariana Lima", 75),
            new Student("Joao Silva", 50),
            new Student("Dilara Domingos", 25),
            new Student("Roberto Shimdth", 75),
            new Student("Susan Pereira", 25),
            new Student("Eleonor Silva", 0)
        };

        context.Students.AddRange(students);
        context.SaveChanges();

        var purchases = new List<Purchase>
        {
            new Purchase(students[0].Id, 25, new DateTimeOffset(2025, 8, 7, 16, 45, 0, TimeSpan.Zero)),
            new Purchase(students[1].Id, 25, new DateTimeOffset(2025, 8, 3, 9, 10, 0, TimeSpan.Zero)),
            new Purchase(students[2].Id, 25, new DateTimeOffset(2025, 8, 3, 9, 10, 0, TimeSpan.Zero)),
        };

        context.Purchases.AddRange(purchases);
        context.SaveChanges();

        var printJobs = new List<PrintJob>
        {
            new PrintJob(students[0].Id, 25, new DateTimeOffset(2025, 9, 1, 17, 3, 10, TimeSpan.Zero))
        };

        context.PrintJobs.AddRange(printJobs);
        context.SaveChanges();
    }
}