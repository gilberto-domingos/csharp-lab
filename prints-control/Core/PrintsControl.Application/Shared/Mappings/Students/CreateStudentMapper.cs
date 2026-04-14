using AutoMapper;
using PrintsControl.Domain.Entities;
using PrintsControl.Application.Dtos.Students;
using PrintsControl.Application.Features.Commands.Students;

namespace PrintsControl.Application.Shared.Mappings.Students;

public sealed class CreateStudentMapper : Profile
{
    public CreateStudentMapper()
    {
        CreateMap<Student, StudentDto>();
        CreateMap<CreateStudentCommand, Student>();
    }
}