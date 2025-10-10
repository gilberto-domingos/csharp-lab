namespace PrintsControl.Application.Dtos.Students;

public sealed record StudentUpdateNameDto(Guid Id, string Name, DateTimeOffset UpdatedAt);