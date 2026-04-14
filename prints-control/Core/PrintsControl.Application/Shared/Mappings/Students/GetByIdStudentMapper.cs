using AutoMapper;
using PrintsControl.Application.Dtos.Students;
using PrintsControl.Domain.Entities;

namespace PrintsControl.Application.Shared.Mappings.Students;

public sealed class GetByIdStudentMapper : Profile
{
    public GetByIdStudentMapper()
    {
        CreateMap<Student, StudentDto>();
    }
}