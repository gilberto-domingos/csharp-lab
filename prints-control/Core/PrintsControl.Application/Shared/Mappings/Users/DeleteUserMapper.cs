using AutoMapper;
using PrintsControl.Application.Dtos.Users;
using PrintsControl.Application.Features.Users.Commands.DeleteUser;
using PrintsControl.Domain.Entities;

namespace PrintsControl.Application.Shared.Mappings.Users;

public sealed class DeleteUserMapper : Profile
{
    public DeleteUserMapper()
    {
        CreateMap<DeleteUserCommand, User>();
        CreateMap<User, DeleteUserResponse>();
    }
}