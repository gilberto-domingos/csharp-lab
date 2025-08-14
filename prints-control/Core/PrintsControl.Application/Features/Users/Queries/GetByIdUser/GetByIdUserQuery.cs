using MediatR;
using PrintsControl.Application.Dtos.Users;

namespace PrintsControl.Application.Features.Users.Queries.GetByIdUser;

public sealed record GetByIdUserQuery(Guid Id) : IRequest<GetByIdUserResponse>;