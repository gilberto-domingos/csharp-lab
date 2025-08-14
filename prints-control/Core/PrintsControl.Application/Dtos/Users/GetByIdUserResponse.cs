namespace PrintsControl.Application.Dtos.Users;

public record GetByIdUserResponse(Guid Id, string Email, string Password);