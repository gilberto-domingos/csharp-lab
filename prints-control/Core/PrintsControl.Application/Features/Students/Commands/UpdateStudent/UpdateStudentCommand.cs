using MediatR;
using PrintsControl.Application.Dtos.Students;

namespace PrintsControl.Application.Features.Students.Commands.UpdateStudent;

public sealed record UpdateStudentCommand(Guid Id, string Name, int PrintBalance, DateTimeOffset UpdatedAt) : IRequest<UpdateStudentResponse>;