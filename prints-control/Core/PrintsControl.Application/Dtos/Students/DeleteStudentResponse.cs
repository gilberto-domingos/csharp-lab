namespace PrintsControl.Application.Dtos.Students;

public sealed record DeleteStudentResponse(Guid Id, string Name, int PrintBalance, DateTimeOffset DeletedAt);