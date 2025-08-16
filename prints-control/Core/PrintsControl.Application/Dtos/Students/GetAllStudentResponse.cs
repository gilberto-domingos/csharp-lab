namespace PrintsControl.Application.Dtos.Students;

public sealed record GetAllStudentResponse(Guid Id, string Name, int PrintBalance, DateTimeOffset CreatedAt);