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


// AppDbContext context,
public class StudentService( FileDataService _fileDataService ) : IStudentService
{
    
    
    public Student? GetStudentWithDetails(int id)
    {
        
        /*   return context.Students
               .Include(s => s.Purchases)
               .Include(s => s.PrintJobs)
               .FirstOrDefault(s => s.Id == id); */
        var students = _fileDataService.LoadStudents();
        var purchases = _fileDataService.LoadPurchases();
        var printJobs = _fileDataService.LoadPrintJobs();

        var student = students.FirstOrDefault(s => s.Id == id);
        if (student != null)
        {
            student.Purchases = purchases.Where(p => p.StudentId == id).ToList();
            student.PrintJobs = printJobs.Where(pj => pj.StudentId == id).ToList();
        }
        
        return student;
    }

    public List<Student> GetAllStudentsWithDetails()
    {
       /* return context.Students
            .Include(s => s.Purchases)
            .Include(s => s.PrintJobs)
            .ToList(); */
       var students = _fileDataService.LoadStudents();
       var purchases = _fileDataService.LoadPurchases();
       var printJobs = _fileDataService.LoadPrintJobs();

       // Atribui manualmente as compras e printJobs para cada estudante
       foreach (var student in students)
       {
           student.Purchases = purchases.Where(p => p.StudentId == student.Id).ToList();
           student.PrintJobs = printJobs.Where(pj => pj.StudentId == student.Id).ToList();
       }

       return students;
    }

    public Student? GetStudent(int id)
    {
        // return context.Students.FirstOrDefault(s => s.Id == id);
        
        var students = _fileDataService.LoadStudents();
        var purchases = _fileDataService.LoadPurchases();
        var printJobs = _fileDataService.LoadPrintJobs();

        var student = students.FirstOrDefault(s => s.Id == id);

        if (student != null)
        {
            student.Purchases = purchases.Where(p => p.StudentId == student.Id).ToList();
            student.PrintJobs = printJobs.Where(pj => pj.StudentId == student.Id).ToList();
        }

        return student;
    }
    
    public Student AddStudent(PostStudentDto dto)
    {
       /* var student = new Student { Name = dto.Name, Balance = 0 };
        context.Students.Add(student);
        context.SaveChanges();
        return student; */
       
       if (string.IsNullOrWhiteSpace(dto.Name))
           throw new ArgumentException("O nome é obrigatório", nameof(dto.Name));

       if (dto.Name.Length < 3)
           throw new ArgumentException("O nome deve ter mais do que 3 caracteres", nameof(dto.Name));
       
       var students = _fileDataService.LoadStudents();

       int newId = students.Any() ? students.Max(s => s.Id) + 1 : 1;

       var student = new Student
       {
           Id = newId,
           Name = dto.Name,
           Balance = 0,
           Purchases = new List<Purchase>(),
           PrintJobs = new List<PrintJob>()
       };

       students.Add(student);
       _fileDataService.SaveStudents(students);

       return student;
    }

    public Student? UpdateStudent(int id, PostStudentDto dto)
    {
      /*  var student = context.Students.FirstOrDefault((s => s.Id == id));

        if (student == null)
            return null;

        student.Name = dto.Name;

        context.SaveChanges();
        return student; */
      
      var students = _fileDataService.LoadStudents();
      var student = students.FirstOrDefault(s => s.Id == id);

      if (student == null)
          return null;

      student.Name = dto.Name;

      _fileDataService.SaveStudents(students);

      return student;

    }

    public List<Student> GetAllStudents()
    {
       // return context.Students.ToList();
       return _fileDataService.LoadStudents();
    }

    public List<PrintJob> GetAllPrintDocuments()
    {
       // return context.PrintJobs.ToList();
       return _fileDataService.LoadPrintJobs();
    }

    
    public Purchase? PurchasePrints(PostPurchaseDto dto)
    {
        if (dto.Quantity != 25 && dto.Quantity != 50)
            throw new ArgumentException("Somente pacotes de 25 ou 50 impressões são permitidas");
            
           // return null; // validação

        var students = _fileDataService.LoadStudents();
        var student = students.FirstOrDefault(s => s.Id == dto.StudentId);
        if (student == null) return null;

        var purchase = new Purchase
        {
            StudentId = student.Id,
            Quantity = dto.Quantity,
            PurchaseDate = DateTime.UtcNow
        };

        // Atualiza saldo do estudante
        student.Balance += dto.Quantity;

        // Salva alterações nos CSV
        _fileDataService.SaveStudents(students);

        var purchases = _fileDataService.LoadPurchases();
        purchases.Add(purchase);
        _fileDataService.SavePurchases(purchases);

        return purchase;
    }

   /* public Purchase? PurchasePrints(PostPurchaseDto dto)
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
    } */
   
   
    public List<Purchase> GetAllPurchases()
    {
        //return context.Purchases.ToList();
        return _fileDataService.LoadPurchases();
    }   

    /*
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
*/
    
    public PrintJob? PrintDocuments(PostPrintJobDto dto)
    {
        var student = _fileDataService.LoadStudents()
            .FirstOrDefault(s => s.Id == dto.StudentId);
        if (student == null) return null;

        if (student.Balance < dto.Quantity)
            throw new ArgumentException("Saldo insuficiente!");
            
            //  return null; // saldo insuficiente

        var print = new PrintJob
        {
            StudentId = student.Id,
            Quantity = dto.Quantity,
            PrintDate = DateTime.UtcNow
        };

        student.Balance -= dto.Quantity;

        // Atualiza arquivos CSV
        _fileDataService.SaveStudents(
            _fileDataService.LoadStudents()
                .Select(s => s.Id == student.Id ? student : s)
                .ToList()
        );

        var printJobs = _fileDataService.LoadPrintJobs();
        printJobs.Add(print);
        _fileDataService.SavePrintJobs(printJobs);

        return print;
    }

    
  /*  
    public bool DeleteStudent(int id)
    {
       var student = context.Students
           .FirstOrDefault(s => s.Id == id);
        if (student == null)
            return false;

        context.Students.Remove(student);
        context.SaveChanges();
        return true;
    } */
  
  public bool DeleteStudent(int id)
  {
      var students = _fileDataService.LoadStudents();
      var student = students.FirstOrDefault(s => s.Id == id);
      if (student == null)
          return false;

      // Remove o estudante da lista
      students.Remove(student);
      _fileDataService.SaveStudents(students);

      // Remove compras e impressões relacionadas
      var purchases = _fileDataService.LoadPurchases()
          .Where(p => p.StudentId != id)
          .ToList();
      _fileDataService.SavePurchases(purchases);

      var printJobs = _fileDataService.LoadPrintJobs()
          .Where(p => p.StudentId != id)
          .ToList();
      _fileDataService.SavePrintJobs(printJobs);

      return true;
  }
}       