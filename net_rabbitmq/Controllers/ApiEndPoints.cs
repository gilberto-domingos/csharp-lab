namespace RabbitMQ.Controllers;

internal static class ApiEndPoints
{
  public static void AddApiEndPoints(this WebApplication app)
  {
    app.MapGet("hello-world", () => new { saudacao = "hello world !" });
  }
    
}