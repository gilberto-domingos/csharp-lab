using AutoMapper;
using PrintsControl.Application.Dtos.Users;
using PrintsControl.Application.Features.Users.Commands.UpdateUser;
using PrintsControl.Domain.Entities;

namespace PrintsControl.Application.Shared.Mappings.Users;

public sealed class UpdateUserMapper : Profile
{
    public UpdateUserMapper()
    {
        CreateMap<UpdateUserCommand, User>();
        CreateMap<User, UpdateUserResponse>();
    }
}