using AutoMapper;
using MediatR;
using PrintsControl.Domain.Interfaces;

namespace PrintsControl.Application.Features.Users.Queries;

public sealed class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery,List<GetAllUserResponse>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    
    public async Task<List<GetAllUserResponse>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAllAsync(cancellationToken);
        return _mapper.Map<List<GetAllUserResponse>>(users);
    }
}