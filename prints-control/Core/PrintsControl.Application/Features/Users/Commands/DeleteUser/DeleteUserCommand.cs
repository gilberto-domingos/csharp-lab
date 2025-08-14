using MediatR;
using PrintsControl.Application.Dtos.Users;

namespace PrintsControl.Application.Features.Users.Commands.DeleteUser;

public sealed record DeleteUserCommand(Guid Id) : IRequest<DeleteUserResponse>;