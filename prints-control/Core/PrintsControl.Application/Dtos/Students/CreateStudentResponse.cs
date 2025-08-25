namespace PrintsControl.Application.Dtos.Students;

public sealed record CreateStudentResponse(int StudentId, string Name, int Balance, DateTimeOffset CreatedAt);   