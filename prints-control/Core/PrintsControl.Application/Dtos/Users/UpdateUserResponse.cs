namespace PrintsControl.Application.Dtos.Users;

public sealed record UpdateUserResponse(Guid Id, string Email, string Password);
