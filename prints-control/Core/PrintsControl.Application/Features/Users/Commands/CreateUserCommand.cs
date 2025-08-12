using MediatR;

namespace PrintsControl.Application.Features.Users.Commands;

public sealed record CreateUserCommand(string Email, string Password) : IRequest<CreateUserResponse>;