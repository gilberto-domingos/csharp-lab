using AutoMapper;
using PrintsControl.Application.Features.Users;
using PrintsControl.Application.Features.Users.Commands;
using PrintsControl.Domain.Entities;

namespace PrintsControl.Application.Shared.Mappings;

public sealed class CreateUserMapper : Profile
{
    public CreateUserMapper()
    {
        CreateMap<CreateUserCommand, User>();
        CreateMap<User, CreateUserResponse>();
    }
}