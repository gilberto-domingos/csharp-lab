namespace PrintsControl.Application.Features.Users;

public sealed record CreateUserResponse(Guid Id, string Email, string Password);
