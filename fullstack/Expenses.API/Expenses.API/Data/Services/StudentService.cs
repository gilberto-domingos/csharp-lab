using System.Runtime.CompilerServices;
using Expenses.API.Dtos;
using Expenses.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Expenses.API.Data.Services;

public interface IStudentService
{
    Student AddStudent(PostStudentDto dto);
    Student? GetStudent(int id);
    
    bool DeleteStudent(int id);
    
    Student? UpdateStudent(int id, PostStudentDto dto);
    List<Student> GetAllStudents();

    List<PrintJob> GetAllPrintDocuments();

    Purchase? PurchasePrints(PostPurchaseDto dto);
    
    List<Purchase> GetAllPurchases();

    PrintJob? PrintDocuments(PostPrintJobDto dto);

    Student? GetStudentWithDetails(int id);
    
    

    List<Student> GetAllStudentsWithDetails();  
}



public class StudentService(AppDbContext context) : IStudentService
{
    
    
    public Student? GetStudentWithDetails(int id)
    {
        return context.Students
            .Include(s => s.Purchases)
            .Include(s => s.PrintJobs)
            .FirstOrDefault(s => s.Id == id);
    }

    public List<Student> GetAllStudentsWithDetails()
    {
        return context.Students
            .Include(s => s.Purchases)
            .Include(s => s.PrintJobs)
            .ToList();
    }

    public Student? GetStudent(int id)
    {
        return context.Students.FirstOrDefault(s => s.Id == id);
    }
    
    public Student AddStudent(PostStudentDto dto)
    {
        var student = new Student { Name = dto.Name, Balance = 0 };
        context.Students.Add(student);
        context.SaveChanges();
        return student;
    }

    public Student? UpdateStudent(int id, PostStudentDto dto)
    {
        var student = context.Students.FirstOrDefault((s => s.Id == id));

        if (student == null)
            return null;

        student.Name = dto.Name;

        context.SaveChanges();
        return student;

    }

    public List<Student> GetAllStudents()
    {
        return context.Students.ToList();
    }

    public List<PrintJob> GetAllPrintDocuments()
    {
        return context.PrintJobs.ToList();
    }

    public Purchase? PurchasePrints(PostPurchaseDto dto)
    {
        if (dto.Quantity != 25 && dto.Quantity != 50)
            return null; // validação

        var student = context.Students.FirstOrDefault(s => s.Id == dto.StudentId);
        if (student == null) return null;

        var purchase = new Purchase
        {
            StudentId = student.Id,
            Quantity = dto.Quantity,
            PurchaseDate = DateTime.UtcNow
        };

        int balanceBefore = student.Balance;
        student.Balance += dto.Quantity;

        

        context.Purchases.Add(purchase);
        context.SaveChanges();

        return purchase;
    }

    public List<Purchase> GetAllPurchases()
    {
        return context.Purchases.ToList();
    }   

    public PrintJob? PrintDocuments(PostPrintJobDto dto)
    {
        var student = context.Students.FirstOrDefault(s => s.Id == dto.StudentId);
        if (student == null) return null;

        if (student.Balance < dto.Quantity)
            return null; // saldo insuficiente

        var print = new PrintJob
        {
            StudentId = student.Id,
            Quantity = dto.Quantity,
            PrintDate = DateTime.UtcNow
        };

        int balanceBefore = student.Balance;
        student.Balance -= dto.Quantity;

        

        context.PrintJobs.Add(print);
        context.SaveChanges();

        return print;
    }

    
    
    public bool DeleteStudent(int id)
    {
       var student = context.Students
           .FirstOrDefault(s => s.Id == id);
        if (student == null)
            return false;

        context.Students.Remove(student);
        context.SaveChanges();
        return true;
    }


}       