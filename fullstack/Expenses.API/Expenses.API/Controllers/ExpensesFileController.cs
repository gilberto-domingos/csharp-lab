using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ExpensesFileController : ControllerBase
{
    private readonly FileDataService _service = new();

    [HttpGet("GetTeste")]
    public IActionResult GetAll()
    {
        var expenses = _service.GetAll();
        return Ok(expenses);
    }

    [HttpPost("Teste")]
    public IActionResult Add([FromBody] Expense expense)
    {
        _service.Add(expense);
        return Ok(expense);
    }
}