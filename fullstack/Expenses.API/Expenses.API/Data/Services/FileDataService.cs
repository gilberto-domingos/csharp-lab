using System.Globalization;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;
using Expenses.API.Models;

namespace Expenses.API.Data.Services;

public class FileDataService
{
    private readonly string _basePath;
    private readonly CsvConfiguration _csvConfig;

    public FileDataService()
    {
        _basePath = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "Data", "CsvFiles");
        Directory.CreateDirectory(_basePath);

        _csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = true,
            Encoding = Encoding.UTF8,
            HeaderValidated = null, 
            MissingFieldFound = null 
        };

        CreateInitialFiles();
    }

    private string GetFilePath(string fileName) => Path.Combine(_basePath, fileName);

    private void CreateInitialFiles()
    {
        
        var studentsFile = GetFilePath("students.csv");
        if (!File.Exists(studentsFile))
        {
            File.WriteAllText(studentsFile,
                "Id,Name,Balance\n" +
                "1,Ana Souza,50\n" +
                "2,Carlos Pereira,25\n" +
                "3,Mariana Lima,75\n" +
                "4,João Silva,25\n" +
                "5,Susan Pereira,50\n" +
                "6,Roberto Shimdth,50\n" +
                "7,Anderson Puller,75\n" +
                "8,Oliver Junior,25\n");
        }

        var purchasesFile = GetFilePath("purchases.csv");
        if (!File.Exists(purchasesFile))
        {
            File.WriteAllText(purchasesFile,
                "PurchaseId,Quantity,PurchaseDate,StudentId\n" +
                $"1,25,{DateTime.UtcNow.AddDays(-5):O},1\n" +
                $"2,50,{DateTime.UtcNow.AddDays(-4):O},2\n" +
                $"3,25,{DateTime.UtcNow.AddDays(-5):O},3\n" +
                $"4,50,{DateTime.UtcNow.AddDays(-4):O},4\n" +
                $"5,25,{DateTime.UtcNow.AddDays(-5):O},5\n" +
                $"6,50,{DateTime.UtcNow.AddDays(-4):O},6\n" +
                $"7,50,{DateTime.UtcNow.AddDays(-4):O},7\n" +
                $"8,25,{DateTime.UtcNow.AddDays(-3):O},8\n");
        }

        var printJobsFile = GetFilePath("printjobs.csv");
        if (!File.Exists(printJobsFile))
        {
            File.WriteAllText(printJobsFile,
                "PrintJobId,Quantity,PrintDate,StudentId\n" +
                $"1,25,{DateTime.UtcNow.AddDays(-5):O},1\n" +
                $"2,50,{DateTime.UtcNow.AddDays(-4):O},2\n" +
                $"3,25,{DateTime.UtcNow.AddDays(-5):O},3\n" +
                $"4,50,{DateTime.UtcNow.AddDays(-4):O},4\n" +
                $"5,25,{DateTime.UtcNow.AddDays(-5):O},5\n" +
                $"6,50,{DateTime.UtcNow.AddDays(-4):O},6\n" +
                $"7,50,{DateTime.UtcNow.AddDays(-4):O},7\n" +
                $"8,25,{DateTime.UtcNow.AddDays(-3):O},8\n");
        }
    }

    public List<Student> LoadStudents()
    {
        var filePath = GetFilePath("students.csv");
        Console.WriteLine($"[FileDataService] Loading Students CSV from: {filePath}");

        if (!File.Exists(filePath))
            return new List<Student>();

        using var reader = new StreamReader(filePath, Encoding.UTF8);
        using var csv = new CsvReader(reader, _csvConfig);
        return csv.GetRecords<Student>().ToList();
    }

    public void SaveStudents(List<Student> students)
    {
        var filePath = GetFilePath("students.csv");
        using var writer = new StreamWriter(filePath, false, Encoding.UTF8);
        using var csv = new CsvWriter(writer, _csvConfig);
        csv.WriteRecords(students);
    }

    public List<Purchase> LoadPurchases()
    {
        var filePath = GetFilePath("purchases.csv");
        Console.WriteLine($"[FileDataService] Loading Purchases CSV from: {filePath}");

        if (!File.Exists(filePath))
            return new List<Purchase>();

        using var reader = new StreamReader(filePath, Encoding.UTF8);
        using var csv = new CsvReader(reader, _csvConfig);
        return csv.GetRecords<Purchase>().ToList();
    }

    public void SavePurchases(List<Purchase> purchases)
    {
        var filePath = GetFilePath("purchases.csv");
        using var writer = new StreamWriter(filePath, false, Encoding.UTF8);
        using var csv = new CsvWriter(writer, _csvConfig);
        csv.WriteRecords(purchases);
    }

    // ---------- PRINT JOBS ----------
    public List<PrintJob> LoadPrintJobs()
    {
        var filePath = GetFilePath("printjobs.csv");
        Console.WriteLine($"[FileDataService] Loading PrintJobs CSV from: {filePath}");

        if (!File.Exists(filePath))
            return new List<PrintJob>();

        using var reader = new StreamReader(filePath, Encoding.UTF8);
        using var csv = new CsvReader(reader, _csvConfig);
        return csv.GetRecords<PrintJob>().ToList();
    }

    public void SavePrintJobs(List<PrintJob> printJobs)
    {
        var filePath = GetFilePath("printjobs.csv");
        using var writer = new StreamWriter(filePath, false, Encoding.UTF8);
        using var csv = new CsvWriter(writer, _csvConfig);
        csv.WriteRecords(printJobs);
    }
}
