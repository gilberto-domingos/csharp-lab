using MediatR;
using PrintsControl.Application.Dtos;

namespace PrintsControl.Application.Features.Queries.Students;

public sealed record GetAllStudentHistoryQuery():IRequest<List<StudentHistoryDto>>;