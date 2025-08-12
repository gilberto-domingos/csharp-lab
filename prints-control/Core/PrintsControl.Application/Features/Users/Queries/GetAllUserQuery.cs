using MediatR;

namespace PrintsControl.Application.Features.Users.Queries;

public sealed record GetAllUserQuery() : IRequest<List<GetAllUserResponse>>;