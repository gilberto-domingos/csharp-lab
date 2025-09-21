using AutoMapper;
using PrintsControl.Application.Dtos.Students;
using PrintsControl.Domain.Entities;

namespace PrintsControl.Application.Shared.Mappings.Students;

public sealed class GetAllStudentMapper : Profile
{
    public GetAllStudentMapper()
    {
        CreateMap<Student, StudentDto>();
    }
}