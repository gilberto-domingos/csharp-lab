namespace PrintsControl.Application.Dtos.Students;

public sealed record StudentDto(Guid Id, string Name, int Balance, DateTimeOffset CreatedAt);
