using MediatR;
using PrintsControl.Application.Dtos.Users;

namespace PrintsControl.Application.Features.Users.Queries.GetAllUsers;

public sealed record GetAllUserQuery() : IRequest<List<GetAllUserResponse>>;