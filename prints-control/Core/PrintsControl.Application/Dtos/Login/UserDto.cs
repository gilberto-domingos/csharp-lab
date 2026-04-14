namespace PrintsControl.Application.Dtos.Students;

public sealed record UserDto(Guid Id, string Email, string Password, DateTimeOffset CreatedAt);

   

