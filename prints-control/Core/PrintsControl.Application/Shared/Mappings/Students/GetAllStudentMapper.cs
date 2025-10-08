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
            .ConstructUsing(student => new StudentHistoryDto(
                student.Id,
                student.Name,
                student.Balance,

                student.Purchases.Sum(p => p.Quantity),
                student.PrintJobs.Sum(pj => pj.Quantity),

                student.Purchases.Select(p => p.PurchaseDate).ToList(),
                student.Purchases.Select(p => p.CreatedAt).ToList(),
                student.Purchases.Select(p => p.UpdatedAt).ToList(),
                student.Purchases.Select(p => p.DeletedAt ?? DateTimeOffset.MinValue)
                    .Where(d => d != DateTimeOffset.MinValue).ToList(),

                student.PrintJobs.Select(pj => pj.PrintDate).ToList(),
                student.PrintJobs.Select(pj => pj.CreatedAt).ToList(),
                student.PrintJobs.Select(pj => pj.UpdatedAt).ToList(),
                student.PrintJobs.Select(pj => pj.DeletedAt ?? DateTimeOffset.MinValue)
                    .Where(d => d != DateTimeOffset.MinValue).ToList()
            ));



        CreateMap<GetAllStudentsQuery, Student>();
    }
}