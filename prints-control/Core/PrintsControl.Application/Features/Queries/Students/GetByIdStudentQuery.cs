using MediatR;
using PrintsControl.Application.Dtos.Students;

namespace PrintsControl.Application.Features.Queries.Students;
public sealed record GetByIdStudentQuery(Guid Id): IRequest<StudentDto>;