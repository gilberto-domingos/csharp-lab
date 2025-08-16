using MediatR;
using PrintsControl.Application.Dtos.Students;

namespace PrintsControl.Application.Features.Students.Commands.DeleteStudent;

public sealed record DeleteStudentCommand(Guid Id) : IRequest<DeleteStudentResponse>;