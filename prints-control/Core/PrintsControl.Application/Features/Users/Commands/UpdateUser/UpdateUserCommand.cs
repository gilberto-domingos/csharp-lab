using MediatR;
using PrintsControl.Application.Dtos.Users;

namespace PrintsControl.Application.Features.Users.Commands.UpdateUser;

public sealed record UpdateUserCommand(Guid Id, string Email, string Password) : IRequest<UpdateUserResponse>;