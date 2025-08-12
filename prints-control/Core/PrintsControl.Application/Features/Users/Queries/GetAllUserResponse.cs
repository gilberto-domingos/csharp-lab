namespace PrintsControl.Application.Features.Users.Queries;

public sealed record GetAllUserResponse(Guid Id, string Email, string Password);