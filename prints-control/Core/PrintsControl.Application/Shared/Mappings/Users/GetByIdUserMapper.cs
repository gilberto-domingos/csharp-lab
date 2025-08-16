using AutoMapper;
using PrintsControl.Application.Dtos.Users;
using PrintsControl.Domain.Entities;

namespace PrintsControl.Application.Shared.Mappings.Users;

public sealed class GetByIdUserMapper : Profile
{
    public GetByIdUserMapper()
    {
        CreateMap<User, GetByIdUserResponse>();
    }
}