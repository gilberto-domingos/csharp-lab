using AutoMapper;
using PrintsControl.Domain.Entities;

namespace PrintsControl.Application.UseCases.CreateUser;

public sealed class CreateUserMapper : Profile
{
    public CreateUserMapper()
    {
        CreateMap<CreateUserCommand, User>();
        CreateMap<User, CreateUserResponse>();
    }
}