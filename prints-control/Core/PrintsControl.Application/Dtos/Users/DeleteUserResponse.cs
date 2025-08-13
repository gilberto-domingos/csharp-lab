namespace PrintsControl.Application.Dtos.Users;

public sealed record DeleteUserResponse(Guid Id, string Email, string Password);
