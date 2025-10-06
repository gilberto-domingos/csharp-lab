using AutoMapper;
using PrintsControl.Application.Dtos;
using PrintsControl.Application.Dtos.Students;
using PrintsControl.Application.Features.Queries.Students;
using PrintsControl.Domain.Entities;

namespace PrintsControl.Application.Shared.Mappings.Students;

public sealed class GetAllStudentMapper : Profile
{
    public GetAllStudentMapper()
    {
        CreateMap<Student, StudentDto>();
        CreateMap<Student, StudentHistoryDto>()
            .ConstructUsing(s => new StudentHistoryDto(
                s.Id,
                s.Name,
                s.Balance,
                s.Purchases.Sum(p => p.Quantity),
                s.PrintJobs.Sum(p => p.Quantity),
                s.Purchases.Select(p => p.PurchaseDate).ToList(),
                s.PrintJobs.Select(p => p.PrintDate).ToList()
            ));
        CreateMap<GetAllStudentsQuery, Student>();
    }
}