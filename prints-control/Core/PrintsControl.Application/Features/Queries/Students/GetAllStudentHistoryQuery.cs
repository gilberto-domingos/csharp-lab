using MediatR;
using PrintsControl.Application.Dtos;

namespace PrintsControl.Application.Features.Queries.Students;

public sealed record GetAllStudentHistoryQuery(Guid StudentId, string Name, int Balance, int TotalPurchase, DateTimeOffset PurchaseDates, int TotalPrints,DateTimeOffset PrintsDates):IRequest<StudentHistoryDto>;