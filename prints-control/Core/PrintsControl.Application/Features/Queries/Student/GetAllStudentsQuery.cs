using MediatR;
using PrintsControl.Application.Dtos.Students;

namespace PrintsControl.Application.Features.Students.Queries.GetAllStudents;

public sealed record GetAllStudentsQuery() : IRequest<List<StudentDto>>;