using MediatR;
using PrintsControl.Application.Dtos.Students;

namespace PrintsControl.Application.Features.Queries.Student;

public record GetByNameStudentQuery(string Name) : IRequest<StudentDto>;