using MediatR;
using PrintsControl.Application.Dtos.Students;

namespace PrintsControl.Application.Features.Students.Queries.GetByIdStudent;

public sealed record GetByIdStudentQuery(Guid Id): IRequest<StudentDto>;