using MediatR;

namespace PrintsControl.Application.UseCases.CreateUser;

public sealed record CreateUserCommand(string Email, string Password) : IRequest<CreateUserResponse>;