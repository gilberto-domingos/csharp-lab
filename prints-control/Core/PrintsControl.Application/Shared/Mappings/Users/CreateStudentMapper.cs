using AutoMapper;
using PrintsControl.Application.Dtos.Students;
using PrintsControl.Application.Features.Users.Commands.CreateUser;
using PrintsControl.Domain.Entities;

namespace PrintsControl.Application.Shared.Mappings.Users;

public class CreateStudentMapper : Profile
{
    public CreateStudentMapper()
    {
        CreateMap<CreateUserCommand, Student>();
        CreateMap<Student, CreateStudentResponse>();
    }
}