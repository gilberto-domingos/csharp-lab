using AutoMapper;
using MediatR;
using PrintsControl.Application.Dtos.Users;
using PrintsControl.Domain.Interfaces;

namespace PrintsControl.Application.Features.Users.Queries.GetByIdUser;

public sealed class GetByIdUserQueryHandler : IRequestHandler<GetByIdUserQuery, GetByIdUserResponse>
{
   private readonly IUserRepository _userRepository;
   private readonly IMapper _mapper;

   public GetByIdUserQueryHandler(IUserRepository userRepository, IMapper mapper)
   {
      _userRepository = userRepository;
      _mapper = mapper;
   }

   public async Task<GetByIdUserResponse> Handle(GetByIdUserQuery request, CancellationToken cancellationToken)
   {
      var user = await _userRepository.GetByIdAsync(request.Id, cancellationToken);
      return _mapper.Map<GetByIdUserResponse>(user);
   }
}