using MediatR;
using PrintsControl.Application.Dtos.Students;

namespace PrintsControl.Application.Features.Students.Commands.CreateStudent;

public sealed record CreateStudentCommand(string Name, int PrintBalance, DateTimeOffset CreatedAt) : IRequest<CreateStudentResponse>;