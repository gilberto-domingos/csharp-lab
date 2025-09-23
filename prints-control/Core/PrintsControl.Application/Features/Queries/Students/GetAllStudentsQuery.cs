using MediatR;
using PrintsControl.Application.Dtos.Students;

namespace PrintsControl.Application.Features.Queries.Students;

public sealed record GetAllStudentsQuery() : IRequest<List<StudentDto>>;