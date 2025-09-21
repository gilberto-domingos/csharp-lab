using AutoMapper;
using PrintsControl.Application.Dtos.Students;
using PrintsControl.Application.Features.Commands.Students;
using PrintsControl.Domain.Entities;

namespace PrintsControl.Application.Shared.Mappings.Students;

public sealed class UpdateStudentMapper : Profile
{
    public UpdateStudentMapper()
    {
        CreateMap<UpdateStudentCommand, Student>();
        CreateMap<Student, StudentDto>();
    }
}