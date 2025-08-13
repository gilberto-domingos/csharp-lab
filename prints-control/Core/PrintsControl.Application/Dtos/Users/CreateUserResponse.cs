namespace PrintsControl.Application.Dtos.Users;

public sealed record CreateUserResponse(Guid Id, string Email, string Password);
