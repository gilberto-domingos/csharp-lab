namespace PrintsControl.Application.Dtos.Users;

public sealed record GetAllUserResponse(Guid Id, string Email, string Password);