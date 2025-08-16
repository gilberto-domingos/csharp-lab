namespace PrintsControl.Application.Dtos.Students;

public sealed record UpdateStudentResponse(Guid Id, string Name, int PrintBalance, DateTimeOffset UpdatedAt);