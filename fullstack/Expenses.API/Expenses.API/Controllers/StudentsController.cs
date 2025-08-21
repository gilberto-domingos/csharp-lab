using Expenses.API.Data.Services;
using Expenses.API.Dtos;
using Expenses.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Expenses.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    private readonly IStudentService _studentService;

    public StudentsController(IStudentService studentService)
    {
        _studentService = studentService;
    }   
    
    [HttpPost("Create")]
    public IActionResult CreateStudent([FromBody] PostStudentDto dto)
    {
        var student = _studentService.AddStudent(dto);
        return Ok(student);
    }

    [HttpGet("All")]
    public IActionResult GetAll()
    {
        var students = _studentService.GetAllStudentsWithDetails();
        return Ok(students);
    }
    
    [HttpGet("Print")]
    public IActionResult GetPrintDocuments()
    {
        var prints = _studentService.GetAllPrintDocuments();
        return Ok(prints);  
    }

    [HttpPost("Purchase")]
    public IActionResult PurchasePrints([FromBody] PostPurchaseDto dto)
    {
        var purchase = _studentService.PurchasePrints(dto);
        if (purchase == null)
        {
            return BadRequest("Invalid purchase. Only 25 or 50 are allowed.");
        }

        return Ok(purchase);
    }
    
    [HttpGet("Purchases")]
    public ActionResult<List<Purchase>> GetAllPurchases()
    {
        return Ok(_studentService.GetAllPurchases());
    }


    [HttpPost("Print")]
    public IActionResult PrintDocuments([FromBody] PostPrintJobDto dto)
    {
        var print = _studentService.PrintDocuments(dto);
        
        if (print == null)
            return BadRequest("Houve problema ao tentar salvar impressão");
        return Ok(print);
    }
    
    
    [HttpGet("Details/{id}")]
    public IActionResult GetStudent(int id)
    {
        var student = _studentService.GetStudentWithDetails(id);
        if (student == null)
            return NotFound("Estudante não encontrado");

        return Ok(student);
    }
    
    [HttpPut("Update/{id}")]
    public IActionResult UpdateStudent(int id, [FromBody] PostStudentDto dto)
    {
        var updated = _studentService.UpdateStudent(id, dto);
        if (updated == null) return NotFound("Estudante não encontrado");
        return Ok(updated);
    }
    
    
    [HttpDelete("Delete/{id}")]
    public IActionResult DeleteStudent(int id)
    {
        var deleted = _studentService.DeleteStudent(id);
        if (!deleted)
            return NotFound("Estudante não encontrado");

        return NoContent();
    }
}