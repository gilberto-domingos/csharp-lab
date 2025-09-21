using MediatR;
using PrintsControl.Application.Dtos.Students;

namespace PrintsControl.Application.Features.Commands.Students;

public sealed record CreateStudentCommand(string Name, int PrintBalance) : IRequest<StudentDto>;