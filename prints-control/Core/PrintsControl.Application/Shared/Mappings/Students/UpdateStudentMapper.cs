using AutoMapper;
using PrintsControl.Application.Dtos.Students;
using PrintsControl.Application.Features.Students.Commands.UpdateStudent;
using PrintsControl.Domain.Entities;

namespace PrintsControl.Application.Shared.Mappings.Students;

public sealed class UpdateStudentMapper : Profile
{
    public UpdateStudentMapper()
    {
        CreateMap<UpdateStudentCommand, Student>();
        CreateMap<Student, UpdateStudentResponse>();
    }
}