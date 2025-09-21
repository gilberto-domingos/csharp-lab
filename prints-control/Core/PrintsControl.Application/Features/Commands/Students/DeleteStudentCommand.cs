using MediatR;
using PrintsControl.Application.Dtos.Students;

namespace PrintsControl.Application.Features.Commands.Students;

public sealed record DeleteStudentCommand(Guid Id) : IRequest<StudentDto>;