namespace PrintsControl.Application.Dtos.Students;

public sealed record CreateStudentResponse(Guid Id, string Name, int PrintBalance, DateTimeOffset CreatedAt);   