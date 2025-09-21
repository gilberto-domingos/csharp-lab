using MediatR;
using PrintsControl.Application.Dtos.Students;

namespace PrintsControl.Application.Features.Commands.Students;

public sealed record UpdateStudentCommand(Guid Id, string Name, int PrintBalance, DateTimeOffset UpdatedAt) : IRequest<StudentDto>;