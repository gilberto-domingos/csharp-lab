using MediatR;
using PrintsControl.Application.Dtos.Users;

namespace PrintsControl.Application.Features.Users.Commands.CreateUser;

public sealed record CreateUserCommand(string Email, string Password) : IRequest<CreateUserResponse>;