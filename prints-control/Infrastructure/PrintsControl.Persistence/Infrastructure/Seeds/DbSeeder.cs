using System;
using System.Collections.Generic;
using System.Linq;
using PrintsControl.Domain.Entities;
using PrintsControl.Persistence.Context;

namespace PrintsControl.Persistence.Infrastructure.Seeds
{
    public static class DbSeeder
    {
        public static void Seed(AppDbContext context)
        {
            if (context.Students.Any()) return;

            var studentNames = new List<string>
            {
                "Roberto Pires",
                "Alan Vemuth",
                "Mariana Lima",
                "João Silva",
                "Dilara Domingos",
                "Roberto Schmidt",
                "Suzana Pereira",
                "Elenor Silva",
                "Carlos Andrade",
                "Bruna Ferreira",
                "Fábio Costa",
                "Ana Beatriz"
            };

            var purchasePattern = new[] { 50, 50, 25, 25, 50 };
            var printPattern = new[] { 10, 10, 10, 10, 10 };

            var students = new List<Student>();

            foreach (var name in studentNames)
            {
                var totalPurchases = purchasePattern.Sum();
                var totalPrints = printPattern.Sum();
                var balance = totalPurchases - totalPrints;
                var student = new Student(name, balance);
                students.Add(student);
            }

            context.Students.AddRange(students);
            context.SaveChanges();

            var purchases = new List<Purchase>();
            var printJobs = new List<PrintJob>();

            var purchasesBaseDate = new DateTimeOffset(2025, 8, 1, 9, 0, 0, TimeSpan.Zero);
            var printsBaseDate = new DateTimeOffset(2025, 8, 2, 14, 30, 0, TimeSpan.Zero);

            for (int i = 0; i < students.Count; i++)
            {
                var student = students[i];

                for (int j = 0; j < purchasePattern.Length; j++)
                {
                    var qty = purchasePattern[j];
                    var purchaseDate = purchasesBaseDate.AddDays(i * 7 + j);
                    var purchase = new Purchase(student.Id, qty, purchaseDate);

                    purchases.Add(purchase);
                    student.Purchases.Add(purchase);
                }

                for (int j = 0; j < printPattern.Length; j++)
                {
                    var qty = printPattern[j];
                    var printDate = printsBaseDate.AddDays(i * 7 + j);
                    var printJob = new PrintJob(student.Id, qty, printDate);

                    printJobs.Add(printJob);
                    student.PrintJobs.Add(printJob);
                }
            }

            context.Purchases.AddRange(purchases);
            context.PrintJobs.AddRange(printJobs);
            context.SaveChanges();

            var random = new Random();

            foreach (var student in students)
            {
                for (int k = 0; k < 2; k++)
                {
                    var deletedPurchase = new Purchase(
                        student.Id,
                        random.Next(10, 50),
                        DateTimeOffset.UtcNow.AddDays(-random.Next(1, 30))
                    );
                    deletedPurchase.MarkAsDeleted();
                    context.Purchases.Add(deletedPurchase);
                    student.Purchases.Add(deletedPurchase);
                }

                for (int k = 0; k < 2; k++)
                {
                    var deletedPrintJob = new PrintJob(
                        student.Id,
                        random.Next(5, 20),
                        DateTimeOffset.UtcNow.AddDays(-random.Next(1, 30))
                    );
                    deletedPrintJob.MarkAsDeleted();
                    context.PrintJobs.Add(deletedPrintJob);
                    student.PrintJobs.Add(deletedPrintJob);
                }
            }

            context.SaveChanges();
        }
    }
}
