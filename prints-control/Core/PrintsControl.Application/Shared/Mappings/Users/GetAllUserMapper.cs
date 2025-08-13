using AutoMapper;
using PrintsControl.Application.Dtos.Users;
using PrintsControl.Application.Features.Users.Queries.GetAllUsers;
using PrintsControl.Domain.Entities;

namespace PrintsControl.Application.Shared.Mappings.Users;

public sealed class GetAllUserMapper : Profile  
{
    public GetAllUserMapper()
    {
        CreateMap<User, GetAllUserResponse>();
    }
}