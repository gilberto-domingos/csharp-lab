namespace PrintsControl.Application.Dtos.Students;

public record GetByIdStudentResponse(Guid Id, string Name, int PrintBalance, DateTimeOffset CreatedAt);